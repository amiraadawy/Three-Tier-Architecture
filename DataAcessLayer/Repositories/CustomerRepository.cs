using DataAcessLayer.Data;
using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repositories
{
    internal class CustomerRepository : IRepository<Customer>
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(int id)
        { 
            return await _context.Customers.FirstOrDefaultAsync(c=>c.Id==id);

        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            IEnumerable<Customer> customers = _context.Customers.ToList();
            return customers;
        }
        //Other methods For CRUD operations can be implemented here
    }
}
