using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing.Client.Model;
using Ticketing.Helpers;

namespace Ticketing.Client.Context
{
    public class TicketContext: DbContext
    {
        DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connString= Config.GetConnectionString("TicketDb");
            //oppure
            //string connString = config.GetSection("ConnectionStrings")["TicketDb"];

            optionBuilder.UseSqlServer(connString);
        }
    }
}
