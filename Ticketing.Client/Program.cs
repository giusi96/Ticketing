using System;
using Ticketing.Client.Model;

namespace Ticketing.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();
            Console.WriteLine("---Ticket Management---");
            bool quit = false;

            do
            {
                Console.WriteLine("Comando:");
                string command = Console.ReadLine();
                Console.WriteLine();
                switch (command)
                {
                    case "q":
                        quit = true;
                        break;

                    case "a":
                        //ADD
                        Ticket ticket = new Ticket();
                        ticket.Title=GetData("Titolo");
                        ticket.Description = GetData("Descrizione");
                        ticket.Category = GetData("Categoria");
                        ticket.Priority = GetData("Priorità");
                        ticket.Requestor = "Giusi Balsamo";
                        ticket.State = "New";
                        ticket.IssueDate = DateTime.Now;
                        //codice per recuperare i dati di un ticket
                        var result= dataService.Add(ticket);
                        Console.WriteLine($"Operation" + (result ? "completed" : "Failed!"));
                        break;

                    case "n":
                        //ADD NOTE
                        var ticketId = GetData("Ticket ID");
                        int.TryParse(ticketId, out int tId);
                        var comment = GetData("Cooment?");
                        Note newNote = new Note
                        {
                            TicketId = tId,
                            Comment = comment
                        };
                        var noteResult = dataService.Addnote(newNote);
                        Console.WriteLine($"Operation" + (noteResult ? "completed" : "Failed!"));
                        break;

                    case "L":
                        //list
                        Console.WriteLine("---TICKET LIST---");
                        foreach (var t in dataService.ListEager())
                        {
                            Console.WriteLine($"[{t.Id}] {t.Title}");
                            foreach (var n in t.Notes)
                            {
                                Console.WriteLine($"\t{n.Comment}");
                            }
                        }
                        Console.WriteLine("----------------------");

                        dataService.ListEager();
                        break;
                    case "x":
                        var ticketId2 = GetData("Ticket ID");
                        int.TryParse(ticketId2, out int tId2);
                        var ticket2 = dataService.GetTicketById(tId2);
                        Console.WriteLine(ticket2!=null ? ticket2.Description: "");
                        break;
                    case "e":
                        //EDIT
                        break;

                    case "d":
                        //Delete
                        break;

                    default:
                        Console.WriteLine("Comando sconosciuto ");
                        break;
                }
            } while (!quit);

            Console.WriteLine("---Bye Bye ---");
        }

        private static string GetData(string message)
        {
            Console.Write(message + ": ");
            var value= Console.ReadLine();
            return value;
        }
    }
}
