using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingCore.Repository
{
    public interface IRepository<T> where T: class // metodi di accesso al dato
    {
        IEnumerable<T> Get(Func<T, bool> filter =null); //la func mi restituisce tutti gli oggettti che hanno una certà proprietà
                                                        //repository.Get()-> mi resituisce tutti gli oggetti
                                                        //repository.Get(t=>y.Name == 'Roberto')-> mi restituisce tutti gli oggetti la cui proprità nome è uguale a roberto
                                                        //null è il valore di default
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool DeleteById(int id);
            
    }
}
