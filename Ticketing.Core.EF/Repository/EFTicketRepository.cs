using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticketing.Core.EF.Context;
using TicketingCore.Model;
using TicketingCore.Repository;

namespace Ticketing.Core.EF.Repository
{
    public class EFTicketRepository : ITicketRepository //tutti i metodi di IRepository comuni a ticket e note, più i metodi propri  di ITicketRepository
    {
        private TicketContext _ctx = new TicketContext();
        public bool Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get(Func<Ticket, bool> filter = null)
        {
            using(var _ctx= new TicketContext())
            {
                if (filter != null)
                {
                    return _ctx.Tickets.Where(filter);
                }
                return _ctx.Tickets;
            }
            
        }

        public Ticket GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketByTitle(string title) //metodo proprio
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
