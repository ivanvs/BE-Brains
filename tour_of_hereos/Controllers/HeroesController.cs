﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using tour_of_hereos.Models;
using tour_of_hereos.Repositories;

namespace tour_of_hereos.Controllers
{
    public class HeroesController : ApiController
    {
        private IUnitOfWork db;

        public HeroesController(IUnitOfWork db)
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

        [ResponseType(typeof(Hero))]
        public IHttpActionResult PostHero(Hero hero)
        {
            db.HeroesRepository.Insert(hero);
            return Ok(hero);
        }

        [ResponseType(typeof(Hero))]
        public IHttpActionResult PutHero(int id, Hero hero)
        {
            var loadedHero = db.HeroesRepository.GetByID(id);
            loadedHero.Name = hero.Name;
            db.HeroesRepository.Update(hero);

            return Ok(hero);
        }

        [ResponseType(typeof(Hero))]
        public IHttpActionResult DeleteHero(int id)
        {
            var heroDb = db.HeroesRepository.GetByID(id);
            db.HeroesRepository.Delete(id);
            return Ok(heroDb);
        }
    }
}
