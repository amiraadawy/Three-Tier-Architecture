using BusinessLogicLayer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Queries.Customers
{
    public class GetCustomersQuery : IRequest<IEnumerable<CustomerDTO>>
    {
    }
}
