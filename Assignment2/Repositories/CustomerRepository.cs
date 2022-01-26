using Assignment2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Adds new customer to database. Checks if query executes successfully.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(CustomerId, FirstName, LastName, Country, PostalCode, " +
                "Phone, Email) VALUES(@CustomerId, @FirstName, @LastName, @Country, @PostalCode, " +
                "@Phone, @Email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch(SqlException ex)
            {
                //Log to console
            }
            return success;
        }

        public bool DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads and displays ID, First and Last name, Country, Postal code, phone number
        /// and Email of all the customers in the database.Returns them as a list.
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email" +
                " FROM Customer";
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerID = reader.GetString(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(7);
                                temp.PostalCode = reader.GetString(8);
                                temp.PhoneNumber = reader.GetString(9);
                                temp.Email = reader.GetString(11);
                                customerList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                //Log to console
            }
            return customerList;
            
        }
        /// <summary>
        /// Reads a specific customer by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email" +
                " FROM Customer WHERE CustomerId = @CustomerId";
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerID = reader.GetString(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(7);
                                customer.PostalCode = reader.GetString(8);
                                customer.PhoneNumber = reader.GetString(9);
                                customer.Email = reader.GetString(11);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                
                //Log to console
            }
            return customer;
        }
        /// <summary>
        /// Reads a specific customer by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer GetCustomerByName(string name)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email" +
                "  FROM Customer WHERE FirstName LIKE @FirstName";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerID = reader.GetString(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(7);
                                customer.PostalCode = reader.GetString(8);
                                customer.PhoneNumber = reader.GetString(9);
                                customer.Email = reader.GetString(11);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log to error
            }
            return customer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer SET CustomerId = @CustomerId, FirstName = @FirstName, " +
                "LastName = @LastName, Country = @Country, PostalCode = @PostalCode, " +
                "Phone = @Phone, Email = @Email";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch(SqlException ex)
            {
                //Log to console
            }
            return success;
        }
    }
}
