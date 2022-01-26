using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    interface IHighestSpenderRepository
    {
        public List<CustomerSpender> GetHighestSpenders();
    }
}
