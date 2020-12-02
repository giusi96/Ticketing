using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Client.Model.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            // per abbreviare
             //var ticketModel = modelBuilder.Entity<Ticket>(); non ci serve più

            //modelBuilder.Entity<Ticket>()
            //    .HasKey(t => t.Id); //non è necessario se si rispettono le convenzioni
            //modelBuilder.Entity<Ticket>().Property(t => t.Title).HasMaxLength(100);

            //Fluent API
           builder.HasKey(t => t.Id);
           builder.Property(t => t.Title).HasMaxLength(100).IsRequired(); //isrequired; le voglio obbligatoriamente
           builder.Property(t => t.Description).HasMaxLength(500);
           builder.Property(t => t.Category).IsRequired();

           builder.Property(t => t.Requestor).HasMaxLength(50).IsRequired();//proprietà in ticket aggiunata dopo, quindi qui aggiunto dopo e devo rifare una migrations per aggiornare il db

            builder.Property(t => t.RowVersion).IsRowVersion();

            //una classe ticket ha molte note; dall'altra parte ogni nota è attaccata ad un ticket tramite la navigation property 
            builder.HasMany(t => t.Notes).WithOne(n => n.Ticket).HasForeignKey(n => n.TicketId)
                .HasConstraintName("FK_Ticket_Notes").OnDelete(DeleteBehavior.Cascade); //cascade->  se io cancello un ticket si cancella anche la nota associata
        }
    }
}
