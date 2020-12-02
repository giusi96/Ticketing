using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model
{
    public class Note
    {
        //costruttore
        //public Note()
        //{
        //    Ticket = new Ticket();
        //}
        public int Id { get; set; }
        public string Comment { get; set; }

        public int TicketId { get; set; } //Foreign key=>Ticket
        public Byte[] RowVersion { get; set; }
        public virtual Ticket Ticket { get; set; } //scrivendola anche qui, rendo la navigation property bidirezionale: una nota è associata ticket e un ticket può avere diverse note
    }
}
