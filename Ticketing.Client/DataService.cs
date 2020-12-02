using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing.Client.Context;
using Ticketing.Client.Model;
using TicketingCore.Model;

namespace Ticketing.Client
{
    public class DataService
    {
        public List<Ticket> ListLazy()
        {
            using var ctx = new TicketContext();

            //return ctx.Tickets.ToList();
            //le navigation property in letttura non sono popolate-> è una caratteristica di EF: cerca di ridurre il traffico di informazioni.
            //devo indicare esplicitamente le navigation property

           

            //Lazy loading
            Console.WriteLine("---TICKET LIST---");
            foreach (var t in ctx.Tickets)
            {
                Console.WriteLine($"[{t.Id}] {t.Title}");
                foreach (var n in t.Notes)
                {
                    Console.WriteLine($"\t{n.Comment}");
                }

/**/
            }
            Console.WriteLine("----------------------");
            return ctx.Tickets.ToList();
        }
        public List<Ticket> ListEager()
        {
            using var ctx = new TicketContext();
            //Eager Loading
            return ctx.Tickets
                .Include(t => t.Notes)
                .ToList();
        }

        public bool Add(Ticket ticket)
        {
            try
            {
                using var ctx = new TicketContext();
                if (ticket != null)
                {
                    ctx.Tickets.Add(ticket);
                    ctx.SaveChanges();
                }
                else
                    Console.WriteLine("Ticket non può essere nullo!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
            
        }

        public bool Addnote(Note newNote)
        {
            try
            { //Bisogna fare così perchè ho una relaione tra ticket e note con la navigation property che è vuota
                using var ctx = new TicketContext();
                if (newNote != null)
                {
                    var ticket = ctx.Tickets.Find(newNote.TicketId);
                    if (ticket != null)
                    {
                        ticket.Notes.Add(newNote);
                        ctx.SaveChanges();
                    }
                    ////Oppure
                    //newNote.Ticket = ticket;
                    //ctx.Notes.Add(newNote);
                    //ctx.SaveChanges();
                }
                else
                    Console.WriteLine("Nota non può essere nulla!");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }

        public Ticket GetTicketByIdStp(int id) //richiamam la stored procedure creata in sql
        {
            using var ctx = new TicketContext();
            SqlParameter idParam = new SqlParameter("@Id", id);
            var result = ctx.Tickets.FromSqlRaw("exec stpGetTicketById @Id", idParam).AsEnumerable();
            return result.FirstOrDefault();
;        }

        public Ticket GetTicketById(int id)
        {
            using var ctx = new TicketContext();
            if (id > 0)
                return ctx.Tickets.Find(id);

            return null;           
        }

        public bool Edit(Ticket ticket)
        {
            using var ctx = new TicketContext();
            bool saved = false;
            do
            {
                try //Gestione della Concorrenza
                {
                    if (ticket == null)
                        return false;

                    Console.WriteLine("Smandrappa il ticket e poi premi enter");
                    Console.ReadKey(); //simulazione della concorrenza

                    ctx.Entry<Ticket>(ticket).State = EntityState.Modified;
                    ctx.SaveChanges();

                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    //..
                    Console.WriteLine("Errore:" + ex.Message);
                    saved= false;
                }
            } while (!saved);

            return true;
        }
    }
}