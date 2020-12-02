using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing.Client.Model;
using Ticketing.Client.Model.Configuration;
using Ticketing.Helpers;
using TicketingCore.Model;

namespace Ticketing.Core.EF.Context
{
    public sealed class TicketContext: DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Note> Notes{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connString= Config.GetConnectionString("TicketDb");
            //oppure
            //string connString = config.GetSection("ConnectionStrings")["TicketDb"];
            optionBuilder.UseLazyLoadingProxies(); //Lazy Loading
            optionBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ticket>(new TicketConfiguration());
            modelBuilder.ApplyConfiguration<Note>(new NoteConfiguration());
        }
    }
}
