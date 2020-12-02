using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model
{
    public class Ticket
    {
        //public Ticket() //costruttore
        //{
        //    Notes = new List<Note>();
        //}
        //posso fare anche qui quello che ho fatto in onmodelcreating con le dataannotation: se le metto entrambi-> prima ha precedenza
        //le fluent api, poi le data annotations, poi le convenzioni. per le dataannotantion va aggiunta lo using
        //[Key]
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string Title { get; set; }
        //[MaxLength(500)]       
        public string Description { get; set; }

        public string Requestor { get; set; }
        //[Required]
        public string Category { get; set; }
        public string Priority { get; set; }
        public string State { get; set; }

        public Byte[] RowVersion { get; set; }

        //navigation property mono direzionale
        public virtual List<Note> Notes { get; set; }
    }
}
