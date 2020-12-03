using System;
using System.Collections.Generic;
using System.Text;
using TicketingCore.Model;
using TicketingCore.Repository;

namespace Ticketing.Core.Mock.Repository
{
    public class MockTicketRepository : ITicketRepository
    {
        #region Mock Data
        private List<Ticket> _tickets = new List<Ticket>
        {
            new Ticket{Id=1, Title="Mock ticket 1", Description="Desc mock 1", IssueDate=DateTime.Now, Category="Systems", Priority="Alta", State="new"},
            new Ticket{Id=2, Title="Mock ticket 2", Description="Desc mock 2", IssueDate=DateTime.Now, Category="Dev", Priority="Alta", State="new"},
            new Ticket{Id=3, Title="Mock ticket 3", Description="Desc mock 3", IssueDate=DateTime.Now, Category="Dev", Priority="Bassa", State="new"},
            new Ticket{Id=4, Title="Mock ticket 4", Description="Desc mock 4", IssueDate=DateTime.Now, Category="Systems", Priority="Alta", State="new"},
            new Ticket{Id=5, Title="Mock ticket 5", Description="Desc mock 5", IssueDate=DateTime.Now, Category="Systems", Priority="Normale", State="new"},
        };
        #endregion
        public bool Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get(Func<Ticket, bool> filter = null)
        {
            return _tickets;
        }

        public Ticket GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
