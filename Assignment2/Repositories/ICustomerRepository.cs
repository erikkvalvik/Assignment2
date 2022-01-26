using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(string id);
        public Customer GetCustomerByName(string name);
        public List<Customer> GetAllCustomers();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string id);

        //Return a page of customers from the database. SHould take in limit and offset as parameters.

        //Return number of customers in each counry, desc

        //Return highest spenders, ordered descending

        //Return given customers most popular genre, display both if tie
        //(most tracks from invoices associated to that customer)
    }
}
