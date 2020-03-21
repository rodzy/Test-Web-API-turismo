using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ActividadController : ApiController
    {
        private actividad_turisticaEntities db = new actividad_turisticaEntities();

        // GET: api/actividad
        public IQueryable<actividad> Getactividad()
        {
            return db.actividad.AsQueryable();
        }

        // GET: api/actividad/5
        [ResponseType(typeof(actividad))]
        public async Task<IHttpActionResult> Getactividad(int id)
        {
            actividad actividad = await db.actividad.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            return Ok(actividad);
        }

        // PUT: api/actividad/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putactividad(int id, actividad actividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actividad.idActividad)
            {
                return BadRequest();
            }

            db.Entry(actividad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!actividadExists(id))
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

        // POST: api/actividad
        [ResponseType(typeof(actividad))]
        public async Task<IHttpActionResult> Postactividad(actividad actividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.actividad.Add(actividad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = actividad.idActividad }, actividad);
        }

        // DELETE: api/actividad/5
        [ResponseType(typeof(actividad))]
        public async Task<IHttpActionResult> Deleteactividad(int id)
        {
            actividad actividad = await db.actividad.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            db.actividad.Remove(actividad);
            await db.SaveChangesAsync();

            return Ok(actividad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool actividadExists(int id)
        {
            return db.actividad.Count(e => e.idActividad == id) > 0;
        }
    }
}