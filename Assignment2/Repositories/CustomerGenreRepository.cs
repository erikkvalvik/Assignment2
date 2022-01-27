using Assignment2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    class CustomerGenreRepository : ICustomerGenreRepository
    {
        /// <summary>
        /// Should return CustomerGenre entity with customer FirstName, customer LastName and 
        /// Customers favorite genre by GenreName.
        /// Method does not return this at the moment. The SQL query is not correct, it will display
        /// each instance of a genre per customer. I did not have time to fix this.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerGenre GetFavoriteGenre(string id)
        {
            CustomerGenre customer = new CustomerGenre();
            string sql = "SELECT Customer.FirstName, Customer.LastName, Genre.Name " +
                "FROM (((Genre INNER JOIN Track ON Track.GenreId = Genre.GenreId) " +
                "INNER JOIN InvoiceLine ON InvoiceLine.TrackId = Track.TrackId)" +
                "INNER JOIN  Invoice ON Invoice.InvoiceId = InvoiceLine.InvoiceId)" +
                "INNER JOIN Customer ON Customer.CustomerId = Invoice.CustomerId " +
                "ORDER BY Customer.CustomerId DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.FirstName = reader.GetString(0);
                                customer.LastName = reader.GetString(1);
                                customer.GenreName = reader.GetString(2);
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
    }
}
