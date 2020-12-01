using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Comment).HasMaxLength(1000).IsRequired();

            //builder.HasOne(n => n.Ticket).WithMany(t => t.Notes); //questa cosa è la stessa che ho scritta in ticketconfiguration: una nota è associata ad un ticket, un ticket può avere diverse note. 
            //                                                        //si tratta di una relazione uno a molti
        }
    }
}
