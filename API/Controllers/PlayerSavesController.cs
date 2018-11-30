using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.DbContext;
using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Controllers
{
    public class PlayerSavesController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/PlayerSaves
        public List<SaveHeadDto> GetPlayerSaves()
        {
            var entities = db.PlayerSaves.Include(x => x.Player).ToList();
            var dtos = Mapper.Map<List<PlayerSave>, List<SaveHeadDto>>(entities);
            return dtos;
        }

        // GET: api/PlayerSaves/5
        [ResponseType(typeof(string))]
        public IHttpActionResult GetPlayerSave(int id)
        {
            PlayerSave playerSave = db.PlayerSaves.Find(id);
            if (playerSave == null)
            {
                return NotFound();
            }



            return Ok(playerSave.Save);
        }

        // PUT: api/PlayerSaves/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerSave(int id, PlayerSave playerSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerSave.Id)
            {
                return BadRequest();
            }

            db.Entry(playerSave).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerSaveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PlayerSaves
        [ResponseType(typeof(PlayerSave))]
        public IHttpActionResult PostPlayerSave(PlayerSaveCreateModel playerSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PlayerSave entity = new PlayerSave();
            entity.CreatedDate = DateTime.Now;
            entity.Save = playerSave.Save;
            entity.SaveName = playerSave.SaveName;
            entity.Player = db.Users.Find(playerSave.Id);

            db.PlayerSaves.Add(entity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playerSave.Id }, playerSave);
        }

        // DELETE: api/PlayerSaves/5
        [ResponseType(typeof(PlayerSave))]
        public IHttpActionResult DeletePlayerSave(int id)
        {
            PlayerSave playerSave = db.PlayerSaves.Find(id);
            if (playerSave == null)
            {
                return NotFound();
            }

            db.PlayerSaves.Remove(playerSave);
            db.SaveChanges();

            return Ok(playerSave);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerSaveExists(int id)
        {
            return db.PlayerSaves.Count(e => e.Id == id) > 0;
        }
    }
}