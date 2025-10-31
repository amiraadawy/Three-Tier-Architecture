using BusinessLogicLayer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Commends.Custmers
{
    public  record AddCustomerCommand(string Name, string Email, string Phone, string Address):IRequest<CustomerDTO>
    {

    }
}
