using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T10_P1_2_start.Repositories;
using System.Linq;
using T10_P1_2_start.Models;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

namespace T10_P1_2_start.Tests.Controllers
{
    /// <summary>
    /// Summary description for UsersControllerTest
    /// </summary>
    [TestClass]
    public class UsersControllerTest
    {
        private List<int> usersIds;

        private UnitOfWork GetUnitOfWork()
        {
            DataAccessContext dac = new DataAccessContext();
            UnitOfWork db = new UnitOfWork(dac);
            db.AddressesRepository = new GenericRepository<Address>(dac);
            db.UsersRepository = new GenericRepository<User>(dac);

            return db;
        }

        [TestInitialize()]
        public void Setup()
        {
            UnitOfWork db = GetUnitOfWork();

            db.UsersRepository.Insert(new Models.User() { Id = 1, Name = "Petar", Email = "petar@example" });
            db.UsersRepository.Insert(new Models.User() { Id = 2, Name = "John", Email = "john@example" });
            db.UsersRepository.Insert(new Models.User() { Id = 3, Name = "Paul", Email = "paul@example" });

            db.Save();

            usersIds = db.UsersRepository.Get().Select(x => x.Id).ToList();
            db.Dispose();

        }

        [TestCleanup()]
        public void Cleanup()
        {
            using (UnitOfWork db = GetUnitOfWork())
            {
                foreach (User u in db.UsersRepository.Get())
                {
                    db.UsersRepository.Delete(u);
                }

                db.Save();
            }
        }

        [TestMethod]
        public async Task UserServiceNotFound()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var result = await server.HttpClient.GetAsync("api/userss");

                Assert.IsFalse(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            }
        }

        [TestMethod]
        public async Task UserServiceFound()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var result = await server.HttpClient.GetAsync("api/users");

                string content = await result.Content.ReadAsStringAsync();

                Assert.IsTrue(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            }
        }

        [TestMethod]
        public async Task ReadSingleUser()
        {
            using (var server = TestServer.Create<Startup>())
            {
                int expectedId = usersIds.First();
                var result = await server.HttpClient.GetAsync($"api/users/{expectedId}");
                string content = await result.Content.ReadAsStringAsync();


                Assert.IsTrue(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

                User user = JsonConvert.DeserializeObject<User>(content);
                Assert.AreEqual(expectedId, user.Id);
            }
        }

        [TestMethod]
        public async Task ReadAllUsers()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var result = await server.HttpClient.GetAsync("api/users");
                string content = await result.Content.ReadAsStringAsync();


                Assert.IsTrue(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

                List<User> users = JsonConvert.DeserializeObject<List<User>>(content);
                Assert.AreEqual(3, users.Count);
                Assert.IsTrue(usersIds.SequenceEqual(users.Select(x => x.Id).ToList()));
            }
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            using (var server = TestServer.Create<Startup>())
            {
                int userId = usersIds.First();
                var result = await server.HttpClient.DeleteAsync($"api/users/{userId}");
                string content = await result.Content.ReadAsStringAsync();


                Assert.IsTrue(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

                using (UnitOfWork db = GetUnitOfWork())
                {
                    var deletedUser = db.UsersRepository.GetByID(userId);

                    Assert.IsNull(deletedUser);
                }
            }
        }

        [TestMethod]
        public async Task AddUser()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(new { Name = "Vladimir", Email = "vladimir@mail" }), Encoding.UTF8, "application/json");
                var result = await server.HttpClient.PostAsync($"api/users", stringContent);
                string content = await result.Content.ReadAsStringAsync();


                Assert.IsTrue(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

                User createdUser = JsonConvert.DeserializeObject<User>(content);
                Assert.IsNotNull(createdUser);
                Assert.AreEqual("Vladimir", createdUser.Name);

                using (UnitOfWork db = GetUnitOfWork())
                {
                    var dbUser = db.UsersRepository.GetByID(createdUser.Id);

                    Assert.IsNotNull(dbUser);
                    Assert.AreEqual(dbUser.Name, createdUser.Name);
                    Assert.AreEqual(dbUser.Email, createdUser.Email);
                }


            }
        }


        [TestMethod]
        public async Task UpdateUser()
        {
            using (var server = TestServer.Create<Startup>())
            {
                int userId = usersIds.First();
                var stringContent = new StringContent(JsonConvert.SerializeObject(new { Id = userId, Name = "Vladimir", Email = "vladimir@mail" }), Encoding.UTF8, "application/json");
                var result = await server.HttpClient.PutAsync($"api/users/{userId}", stringContent);
                string content = await result.Content.ReadAsStringAsync();


                Assert.IsTrue(result.IsSuccessStatusCode);
                Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);

                using (UnitOfWork db = GetUnitOfWork())
                {
                    var dbUser = db.UsersRepository.GetByID(userId);

                    Assert.IsNotNull(dbUser);
                    Assert.AreEqual("Vladimir", dbUser.Name);
                    Assert.AreEqual("vladimir@mail", dbUser.Email);
                }
            }
        }
    }
}
