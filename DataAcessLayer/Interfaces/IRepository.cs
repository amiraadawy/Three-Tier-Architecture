using DataAcessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add( T Ent);
        void UpdateCustomer(Customer customer);
        //Task DeleteCustomer(int id);


    }
}
