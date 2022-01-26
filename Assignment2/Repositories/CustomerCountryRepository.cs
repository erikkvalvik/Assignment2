using Assignment2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    class CustomerCountryRepository : ICustomerCountryRepository
    {
        public List<CustomerCountry> GetCustomerCountries()
        {
            List<CustomerCountry> countryList = new List<CustomerCountry>();
            string sql = "SELECT Country, SUM(CustomerId) as AmountOfCustomers FROM Customer " +
                "GROUP BY Country ORDER BY AmountOfCustomers DESC";
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
                                CustomerCountry temp = new CustomerCountry();
                                temp.CustomerID = reader.GetString(0);
                                temp.Country = reader.GetString(7);
                                countryList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log to console
            }
            return countryList;
        }
    }
}
