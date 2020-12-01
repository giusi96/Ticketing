using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Ticketing.Helpers
{
    public class Config
    {
        private static IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(); //forzo il configbuilder ad andare a cercare il programma nella currentdirectory

        public static string GetConnectionString(string connStringName)
        {
             return config.GetConnectionString(connStringName);
             //oppure
             //string connString = config.GetSection("ConnectionStrings")["TicketDb"];
        }

        public static IConfigurationSection GetSection(string sectionName)
        {
            return config.GetSection(sectionName);
        }
       
    }
}
