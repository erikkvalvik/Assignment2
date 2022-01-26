using Assignment2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    class HighestSpenderRepository : IHighestSpenderRepository
    {
        /// <summary>
        /// Finds each customers sum of Invoice.Total, ordered by thehighest sum in descending order
        /// Adds each entry to a list.
        /// Using "TOP(50)PERCENT" As Customer Requirement 8. States HIGHEST, meaning the lowest
        /// half is not wanted.
        /// </summary>
        /// <returns>List of top 10 spending customers</returns>
        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> spenderList = new List<CustomerSpender>();
            string sql = "SELECT TOP(50)PERCENT Customer.CustomerId, Customer.FirstName, Customer.LastName, " +
                "(SELECT SUM(Total) FROM Invoice AS c WHERE c.CustomerId = Customer.CustomerId) AS TotalSum " +
                "FROM Customer ORDER BY TotalSum DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender temp = new CustomerSpender();
                                temp.CustomerID = reader.GetString(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.SumTotal = reader.GetString(3);
                                
                                spenderList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log to console
            }
            return spenderList;
        }
    }
}
