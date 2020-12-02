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
                        var comment = GetData("Comment?");
                        Note newNote = new Note
                        {
                            TicketId = tId,
                            Comment = comment
                        };
                        var noteResult = dataService.Addnote(newNote);
                        Console.WriteLine($"Operation" + (noteResult ? "completed" : "Failed!"));
                        break;

                    case "l":
                        //list->Eager loading
                        Console.WriteLine("---TICKET LIST Eager---");
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
                        var ticket2 = dataService.GetTicketByIdStp(tId2);
                        Console.WriteLine(ticket2!=null ? ticket2.Description: "");
                        break;

                    case "z":
                        //List->Lazy loading
                        dataService.ListLazy();
                        break;

                    case "e":
                        //EDIT
                        var ticketId3 = GetData("Ticket ID");
                        int.TryParse(ticketId3, out int tId3);
                        var ticket3 = dataService.GetTicketById(tId3);

                        ticket3.Title = GetData("Titolo", ticket3.Title);
                        ticket3.Description = GetData("Descrizione", ticket3.Description);
                        ticket3.Category = GetData("Categoria", ticket3.Category);
                        ticket3.Priority = GetData("Priorità", ticket3.Priority);
                        ticket3.State =GetData("Stato", ticket3.State);

                        var editResult = dataService.Edit(ticket3);
                        Console.WriteLine($"Operation" + (editResult ? "completed" : "Failed!"));
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

        //overloading di getData-> mi serve per capire in edit cosa sto andando a modificare, ovvero quale è il valore di riferimento
        private static string GetData(string message, string initialValue)
        {
            Console.Write(message + $"({initialValue}): ");
            var value = Console.ReadLine();
            return string.IsNullOrEmpty(value) ? initialValue : value; //se non gli passo nulla mi lascia il valore iniziale, se gli inserisco un valore allora mettte il nuovo valore
        }
    }
}
