using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using tour_of_hereos.Models;
using tour_of_hereos.Repositories;

namespace tour_of_hereos.Controllers
{
    public class HeroController : ApiController
    {
        private IUnitOfWork db;

        public HeroController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IHttpActionResult GetAll()
        {
            return Ok(db.HeroesRepository.Get());
        }

        [ResponseType(typeof(Hero))]
        public IHttpActionResult GetById(int id)
        {
            return Ok(db.HeroesRepository.GetByID(id));
        }

        [Route("heroes")]
        public IHttpActionResult GetByName(string name)
        {
            return Ok(db.HeroesRepository.Get(x => x.Name.Contains(name)));
        }

        [ResponseType(typeof(Hero))]
        public IHttpActionResult PostHero(Hero hero)
        {
            db.HeroesRepository.Insert(hero);
            db.Save();
            return Ok(hero);
        }

        [ResponseType(typeof(Hero))]
        public IHttpActionResult PutHero(int id, Hero hero)
        {
            var loadedHero = db.HeroesRepository.GetByID(id);
            loadedHero.Name = hero.Name;
            db.HeroesRepository.Update(loadedHero);
            db.Save();

            return Ok(hero);
        }

        [ResponseType(typeof(Hero))]
        public IHttpActionResult DeleteHero(int id)
        {
            var heroDb = db.HeroesRepository.GetByID(id);
            db.HeroesRepository.Delete(heroDb);
            db.Save();

            return Ok(heroDb);
        }
    }
}
