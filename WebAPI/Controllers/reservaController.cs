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
    public class ReservaController : ApiController
    {
        private actividad_turisticaEntities db = new actividad_turisticaEntities();

        // GET: api/reserva
        public IQueryable<reserva> Getreserva()
        {
            return db.reserva;
        }

        // GET: api/reserva/5
        [ResponseType(typeof(reserva))]
        public async Task<IHttpActionResult> Getreserva(int id)
        {
            reserva reserva = await db.reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        // PUT: api/reserva/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putreserva(int id, reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reserva.idReserva)
            {
                return BadRequest();
            }

            db.Entry(reserva).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservaExists(id))
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

        // POST: api/reserva
        [ResponseType(typeof(reserva))]
        public async Task<IHttpActionResult> Postreserva(reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reserva.Add(reserva);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reserva.idReserva }, reserva);
        }

        // DELETE: api/reserva/5
        [ResponseType(typeof(reserva))]
        public async Task<IHttpActionResult> Deletereserva(int id)
        {
            reserva reserva = await db.reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            db.reserva.Remove(reserva);
            await db.SaveChangesAsync();

            return Ok(reserva);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool reservaExists(int id)
        {
            return db.reserva.Count(e => e.idReserva == id) > 0;
        }
    }
}