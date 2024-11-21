using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Xml.Linq;
using JP.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.VisualBasic;
using Radzen.Blazor;
using static Azure.Core.HttpHeader;
using static JP.Shared.leaddealsale;



namespace JP.Shared
{
    public class RecommendedProduct
    {
        public string productname { get; set; }
        public RecommendedProduct(string _productname)
        {
            productname = _productname;
        }
    }
    public class database2
    {

        public static List<RecommendedProduct> GetRecommendeds(string catname, int employee, int revenue)
        {
            int employee1 = 0;
            int employee2 = 0;
            int revenue1 = 0;
            int revenue2 = 0;

            if (employee == 0)
            {
                employee1 = 0;
                employee2 = 100000;
            }
            else if (employee >= 1 && employee < 500)
            {
                employee1 = 1;
                employee2 = 499;
            }
            else if (employee >= 500 && employee < 1000)
            {
                employee1 = 500;
                employee2 = 1000;
            }
            else if (employee >= 1000 && employee < 2500)
            {
                employee1 = 1000;
                employee2 = 2499;
            }
            else if (employee >= 2500 && employee < 5000)
            {
                employee1 = 2500;
                employee2 = 4999;
            }
            else 
            {
                employee1 = 5000;
                employee2 = 100000;
            }

            if (revenue == 0)
            {
                revenue1 = 0;
                revenue2 = 100000;
            }
            else if (revenue >= 1 && revenue < 100000)
            {
                revenue1 = 1;
                revenue2 = 99999;
            }
            else if (revenue >= 100000 && revenue < 500000)
            {
                revenue1 = 100000;
                revenue2 = 499999;
            }
            else if (revenue >= 500000 && revenue < 1000000)
            {
                revenue1 = 500000;
                revenue2 = 999999;
            }
            else if (revenue >= 1000000 && revenue < 5000000)
            {
                revenue1 = 1000000;
                revenue2 = 4999999;
            }
            else if (revenue >= 5000000 && revenue < 10000000)
            {
                revenue1 = 5000000;
                revenue2 = 9999999;
            }
            else if (revenue >= 10000000 && revenue < 20000000)
            {
                revenue1 = 10000000;
                revenue2 = 19999999;
            }
            else if (revenue >= 20000000 && revenue < 50000000)
            {
                revenue1 = 20000000;
                revenue2 = 49999999;
            }
            else
            {
                revenue1 = 50000000;
                revenue2 = 100000000;
            }
           


            List<RecommendedProduct> recommendeds = new List<RecommendedProduct>();
            try
            {
                

                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT TOP 3 product.ProductName, COUNT(*) as ProductCount FROM Product INNER JOIN sale ON Product.ProductID = sale.ProductID INNER JOIN client ON client.clientid = sale.clientid INNER JOIN Catagory ON Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company ON Client.CompanyID = Company.CompanyID WHERE Catagory.CatagoryName LIKE @Category AND Company.employees BETWEEN @Employee1 AND @Employee2  AND Company.CompanyRevenue BETWEEN @Revenue1 AND @Revenue2 group by product.ProductName order by ProductCount DESC;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@Category", "%" + catname + "%");
                        command.Parameters.AddWithValue("@Employee1", employee1);
                        command.Parameters.AddWithValue("@Employee2", employee2);
                        command.Parameters.AddWithValue("@Revenue1", revenue1);
                        command.Parameters.AddWithValue("@Revenue2", revenue2);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recommendeds.Add(new RecommendedProduct(reader.GetString(0)));
                            }
                        }
                    }
                    connection.Close();
                    return recommendeds;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return recommendeds;
        }

    }
}




