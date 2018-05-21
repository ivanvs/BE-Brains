using System.Data.Entity;

namespace T7_P1_2.Models
{
    public class InitializeWithDefaultUsers : DropCreateDatabaseIfModelChanges<SecurityDataContext>
    {
        protected override void Seed(SecurityDataContext context)
        {
            Role adminRole = new Role() { Name = "admins" };
            adminRole = context.Roles.Add(adminRole);

            User u1 = new User();
            u1.FirstName = "Ivan";
            u1.LastName = "Vasiljevic";
            u1.Email = "ivan@example.com";
            u1.Password = "pass";
            u1.Role = adminRole;
            u1 = context.Users.Add(u1);


            User u2 = new User();
            u2.FirstName = "Mladen";
            u2.LastName = "Kanostrevac";
            u2.Email = "mladen@example.com";
            u2.Password = "pass";
            u2.Role = adminRole;
            u2 = context.Users.Add(u2);

            context.SaveChanges();
        }
    }
}