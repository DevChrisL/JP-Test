using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportNewLeadsHourly
{
    public class lead
    {
        public int id { get; set; }
        public DateTime joinDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public decimal phoneNumber { get; set; }
        public int companyID { get; set; }
        public int employeeID { get; set; }
        public int categoryID { get; set; }
        public lead() { }
    }

    public class company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int revenue { get; set; }
        public int employees { get; set; }
        public int categoryID { get; set; }
        public company() { }
    }

    public class database
    {
        // Function to create new lead audit log entry
        public static void CreateAuditLogEntry(string newLeadEntry)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO AuditLog(NewLeadsOutput) VALUES (\'" + newLeadEntry + "\');";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
        }

        public static int GetNewCompanyID()
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT MAX(CompanyID) From Company;";
                    int newCompanyID = 0;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                newCompanyID = reader.GetInt32(0) + 1;
                            }
                        }
                    }
                    connection.Close();
                    return newCompanyID;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return 0;
        }

        public static int GetNewLeadID()
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT MAX(ClientID) From Client;";
                    int newLeadID = 0;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                newLeadID = reader.GetInt32(0) + 1;
                            }
                        }
                    }
                    connection.Close();
                    return newLeadID;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return 0;
        }

        public static void CreateCompany(company company)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Company(CompanyID, CompanyName, CompanyRevenue, CatagoryID, employees) VALUES (@CompanyID, @CompanyName, @CompanyRevenue, @CatagoryID, @Employees);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompanyID", company.id);
                        command.Parameters.AddWithValue("@CompanyName", company.name);
                        command.Parameters.AddWithValue("@CompanyRevenue", company.revenue);
                        command.Parameters.AddWithValue("@CatagoryID", company.categoryID);
                        command.Parameters.AddWithValue("@Employees", company.employees);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
        }

        public static void CreateLead(lead lead)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Client(ClientID, Email, fName, lName, CompanyID, PhoneNum, EmpID, CatagoryID, JoinDate, inactive) VALUES (@ClientID, @Email, @fName, @lName, @CompanyID, @PhoneNum, @EmpID, @CatagoryID, @JoinDate, 0);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", lead.id);
                        command.Parameters.AddWithValue("@Email", lead.email);
                        command.Parameters.AddWithValue("@fName", lead.firstName);
                        command.Parameters.AddWithValue("@lName", lead.lastName);
                        command.Parameters.AddWithValue("@CompanyID", lead.companyID);
                        command.Parameters.AddWithValue("@PhoneNum", lead.phoneNumber);
                        command.Parameters.AddWithValue("@EmpID", lead.employeeID);
                        command.Parameters.AddWithValue("@CatagoryID", lead.categoryID);
                        command.Parameters.AddWithValue("@JoinDate", lead.joinDate);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return;
        }

        // Sanitizing input for new lead data
        public static string Escape(string input)
        {
            string ret = "";
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c != '\'' && c != '#' && c != '\"')
                    ret += c.ToString();
            }
            return ret;
        }
    }
}