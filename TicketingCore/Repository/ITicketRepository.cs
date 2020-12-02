using System;
using System.Collections.Generic;
using System.Text;
using TicketingCore.Model;

namespace TicketingCore.Repository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Ticket GetTicketByTitle(string title); //questo appartiene solo al ticket che ha oltre ai metodi di IRepository, anche questo.
                                               //INote non ce l'ha perchè nonn gli serve. Ha solo i metodi di Irepository (per ora)
                                               // o quelli relativi solo alle note (cioè metodi propri)
    }
}
