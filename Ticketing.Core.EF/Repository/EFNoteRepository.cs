﻿using System;
using System.Collections.Generic;
using System.Text;
using TicketingCore.Model;
using TicketingCore.Repository;

namespace Ticketing.Core.EF.Repository
{
    public class EFNoteRepository : INoteRepository
    {
        public bool Add(Note item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> Get(Func<Note, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Note GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Note item)
        {
            throw new NotImplementedException();
        }
    }
}