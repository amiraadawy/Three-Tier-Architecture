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
        Task<IEnumerable<T>> GetCustomers();
        //Task<Customer> GetCustomerById(int id);
        //Task AddCustomer(Customer customer);
        //Task UpdateCustomer(Customer customer);
        //Task DeleteCustomer(int id);


    }
}
