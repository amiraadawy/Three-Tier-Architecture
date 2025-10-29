using BusinessLogicLayer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Queries.Customers
{
    public class GetCustomerQuery : IRequest<CustomerDTO>
    {
        public int id
        {
            get; set;
        }
        public GetCustomerQuery(int customerId)
        {
            id = customerId;
        }
        public GetCustomerQuery()
        {
        }
    }
}
