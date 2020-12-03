using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketing.Core.EF.Context;
using TicketingCore.BL;
using TicketingCore.Model;

namespace Ticketing.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private DataService dataservice;
        public TicketController(DataService service)
        {
            this.dataservice = service;
        }
        [HttpGet]
        public IEnumerable<Ticket> Get() //restituisce la lista di ticket
        {
            //DataService dataservice = new DataService();
            //using var _ctx = new TicketContext();

            //var result= _ctx.Tickets
            //    //.Include(t=>t.Notes)
            //    .ToList();
            //return result;

            var result = dataservice.List();
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) //restiuisce il ticket in base all'id
        {

            //using var _ctx = new TicketContext();
            //var ticket = _ctx.Tickets.SingleOrDefault(t => t.Id == id);
            var ticket = dataservice.GetTicketById(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult Post(Ticket ticket)//<= model Binding
            //inseriemnto di un nuovo ticket            
        {
            //using var _ctx = new TicketContext();
            if (ticket != null)
            {
                //_ctx.Tickets.Add(ticket);
                //_ctx.SaveChanges();
                var result = dataservice.Add(ticket);
                if(result)
                    return Ok();              
            }

            return BadRequest("Invalid ticket");           
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Ticket ticket)//<= doppio model Binding: meccanismo che permette di semplificare il passaggio di parametri quando sei in una condizione mista
              //modifica di un ticket            
        {
            using var _ctx = new TicketContext();
            if (ticket != null && id==ticket.Id)
            {
                var result = dataservice.Edit(ticket);

                if (result)
                    return Ok();


                //bool saved = false;
                //do
                //{
                //    try
                //    {
                //        _ctx.Entry<Ticket>(ticket).State = EntityState.Modified;
                //        _ctx.SaveChanges();

                //        saved = true;
                //    }
                //    catch (DbUpdateConcurrencyException ex)
                //    {
                //        foreach (var entity in ex.Entries)
                //        {
                //            var dbValues = entity.GetDatabaseValues();
                //            entity.OriginalValues.SetValues(dbValues);
                //        }
                //    }; 
                //} while (!saved);
            }

            return BadRequest("Error updating Ticket");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //cancella in base all'id e salva sul database.
                                            //IAction-> esito dell'operazione come metodi
        {
            //using var _ctx = new TicketContext();
            //var ticket = _ctx.Tickets.SingleOrDefault(t => t.Id == id);

            //if (ticket != null)
            //{
            //    _ctx.Tickets.Remove(ticket);
            //    _ctx.SaveChanges();
            //}
            //else
            //    return NotFound();

            var result = dataservice.Delete(id);
            
            if(result)
                return Ok();

            return BadRequest("Cannot delete Ticket");
        }
    }
}
