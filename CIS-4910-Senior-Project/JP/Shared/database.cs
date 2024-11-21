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

    public class employee
    {
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int otherNumber { get; set; }
        public employee(int _id, string _email, string _firstName, string _lastName, int _otherNumber)
        {
            id = _id;
            email = _email;
            firstName = _firstName;
            lastName = _lastName;
            otherNumber = _otherNumber;
        }
    }

    public class product
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int category { get; set; }
        public string categoryName { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public product(int _id, string _name, int _price, int _category, DateTime _date, string _description)
        {
            id = _id;
            name = _name;
            price = _price;
            category = _category;
            categoryName = category == 0 ? "NULL" :
                category == 1 ? "Construction" :
                category == 2 ? "Retail" :
                category == 3 ? "Professional Services" :
                category == 4 ? "Personal Services" :
                category == 5 ? "Business to Business" :
                category == 6 ? "Restaurants & Quick-Serve Restaurants" :
                "Other";
            date = _date;
            description = _description;
        }
    }

    public class category
    {
        public int id { get; set; }
        public string name { get; set; }
        public category(int _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }

    public class company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int revenue { get; set; }
        public int categoryID { get; set; }
        public int employees { get; set; }
        public company() { }
        public company(int _id, string _name, int _revenue, int _categoryID)
        {
            id = _id;
            name = _name;
            revenue = _revenue;
            categoryID = _categoryID;
        }
    }

    public class account
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public account(int _id, string _username, string _password, string _type)
        {
            id = _id;
            username = _username;
            password = _password;
            type = _type;
        }
    }

    public class client
    {
        public DateTime joinDate { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyID { get; set; }
        public decimal phoneNumber { get; set; }
        public int employeeID { get; set; }
        public string categoryID { get; set; }
        public int inactive { get; set; }
        public int companyemployees { get; set; }
        public int companyrevenue { get; set; }
        public client() { }
        public client(int _id, string _email, string _firstName, string _lastName, string _companyID, decimal _phoneNumber, int _employeeID, string _categoryID, DateTime _joinDate, int _inactive, int _companyemployees, int _companyrevenue)
        {
            id = _id;
            email = _email;
            firstName = _firstName;
            lastName = _lastName;
            companyID = _companyID;
            phoneNumber = _phoneNumber;
            employeeID = _employeeID;
            categoryID = _categoryID;
            joinDate = _joinDate;
            inactive = _inactive;
            companyemployees = _companyemployees;
            companyrevenue = _companyrevenue;
        }
        // Overloaded function to be referenced with code that has specific functionality
        public client(int _id, string _email, string _firstName, string _lastName, string _companyID, decimal _phoneNumber, int _employeeID, string _categoryID, DateTime _joinDate)
        {
            id = _id;
            email = _email;
            firstName = _firstName;
            lastName = _lastName;
            companyID = _companyID;
            phoneNumber = _phoneNumber;
            employeeID = _employeeID;
            categoryID = _categoryID;
            joinDate = _joinDate;
        }
    }

    public class meeting
    {
        public int id { get; set; }
        public string time { get; set; }
        public DateTime date { get; set; }
        public decimal clientID { get; set; }
        public decimal employeeID { get; set; }
        public string clientName { get; set; }
        public string company { get; set; }
        public meeting(int _id, string _time, DateTime _date, decimal _clientID, decimal _employeeID, string _clientName, string _company)
        {
            id = _id;
            time = _time;
            date = _date;
            clientID = _clientID;
            employeeID = _employeeID;
            clientName = _clientName;
            company = _company;
        }
    }

    public class sale
    {
        public DateTime date { get; set; }
        public string companyName { get; set; }
        public string clientfName { get; set; }
        public string clientlName { get; set; }
        public string employeefName { get; set; }
        public string employeelName { get; set; }
        public string productName { get; set; }
        public string categoryName { get; set; }
        public int clientID { get; set; }
        public int fk_dealID { get; set; }
        public int revenue { get; set; }
        public sale(DateTime _date, string _companyName, string  _clientfName, string _clientlName, string _employeefName, string _employeelName, string _productName, string _categoryName, int _clientID, int _fk_dealID, int _revenue)
        {
            date = _date;
            companyName = _companyName;
            clientfName = _clientfName;
            clientlName = _clientlName;
            employeefName = _employeefName;
            employeelName = _employeelName;
            productName = _productName;
            categoryName = _categoryName;
            clientID = _clientID;
            fk_dealID = _fk_dealID;
            revenue = _revenue;
        }
    }

    public class note
    {
        public int id { get; set; }
        public int employeeID { get; set; }
        public string name { get; set; }
        public string contents { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public note(int _id, int _employeeID, string _name, string _contents, int _categoryID, string _categoryName)
        {
            id = _id;
            employeeID = _employeeID;
            name = _name;
            contents = _contents;
            categoryID = _categoryID;
            categoryName = _categoryName;
        }
    }

    public class task
    {
        public int id { get; set; }
        public string name { get; set; }
        public int employeeID { get; set; }
        public task(int _id, string _name, int _employeeID)
        {
            id = _id;
            name = _name;
            employeeID = _employeeID;
        }
    }

    public class deal
    {
        public DateTime date { get; set; }
        public string companyName { get; set; }
        public string clientfName { get; set; }
        public string clientlName { get; set; }
        public string employeefName { get; set; }
        public string employeelName { get; set; }
        public string productName { get; set; }
        public string categoryName { get; set; }
        public int clientID { get; set; }
        public deal() { }
        public deal(DateTime _date, string _companyName, string _clientfName, string _clientlName, string _employeefName, string _employeelName, string _productName, string _categoryName, int _clientID)
        {
            date = _date;
            companyName = _companyName;
            clientfName = _clientfName;
            clientlName = _clientlName;
            employeefName = _employeefName;
            employeelName = _employeelName;
            productName = _productName;
            categoryName = _categoryName;
            clientID = _clientID;
        }
    }

    public class recommended
    {
        public string productname { get; set; }
        public recommended(string _productname)
        {
            productname = _productname;
        }
    }

    public class leaddealsale
    {
        public string leadName { get; set; }
        public string leadCompanyName { get; set; }
        public DateTime leadJoinDate { get; set; }
        public string leadEmployeeName { get; set; }
        public string dealCategoryName { get; set; }
        public string dealProductName { get; set; }
        public DateTime dealDate { get; set; }
        public string saleProductName { get; set; }
        public DateTime saleDate { get; set; }
        public int saleRevenue { get; set; }
        public leaddealsale(sale _sale)
        {
            client lead = database.GetClientFromID(_sale.clientID);
            deal deal = database.GetDealFromID(_sale.fk_dealID);
            sale sale = _sale;

            leadName = lead.firstName + " " + lead.lastName;
            leadCompanyName = lead.companyID;
            leadJoinDate = lead.joinDate;
            leadEmployeeName = deal.employeefName + " " + deal.employeelName;
            dealCategoryName = deal.categoryName;
            dealProductName = deal.productName;
            dealDate = deal.date;
            saleProductName = sale.productName;
            saleDate = sale.date;
            saleRevenue = sale.revenue;
        }
    }

    public class auditLogEntry
    {
        public string entry { get; set; }
        public auditLogEntry(string _entry)
        {
            entry = _entry;
        }
    }

    public class database
    {
        // Input sanitization to prevent SQL injection
        // Example usage:   Tuple<bool, string> data = inputSanitization("Hello World.");
        //                  if (data.Item1) { string myData = data.Item2; } else { /* Ouput error message */ }
        public static Tuple<bool, string> inputSanitization(string input)
        {
            // Only accepting input that is alphanumeric with spaces, underscores, periods, and new lines
            return Tuple.Create(Regex.Match(input, "^[a-zA-Z0-9\\s\\n_.]+$").Success, input);
        }

        public static int GetEmpID(int accountID)
        {
            int empID = 1;
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT EmpID FROM Employee WHERE AccountID=@accountID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@accountID", accountID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empID = reader.GetInt32(0);
                            }
                        }
                    }
                    connection.Close();
                    return empID;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return empID;
        }

        public static account AttemptLogin(string username, string password)
        {
            List<account> accounts = GetAccounts();
            foreach (account acc in accounts)
            {
                if (acc.username == username && acc.password == password)
                {
                    return acc;
                }
            }
            return null;
        }

        public static List<employee> GetEmployees()
        {
            List<employee> employees = new List<employee>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM employee;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Employee ID, Email, First Name, Last Name, Account ID
                                employees.Add(new employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                            }
                        }
                    }
                    connection.Close();
                    return employees;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return employees;
        }

        public static List<product> GetProducts(int category = 0, string searchTerm = "") // Optional parameter is set to 0 by default
        {
            List<product> products = new List<product>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM product";
                    if (searchTerm != "")
                    {
                        query = "SELECT * FROM product WHERE ProductDescription LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR ProductName LIKE  \'%" + searchTerm.Replace("+", " ") + "%\' OR " +
                                                            "ProductID LIKE \'%" + searchTerm.Replace("+", " ") + "%' OR ProductPrice LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR " +
                                                            "CreateDate LIKE \'%" + searchTerm.Replace("+", " ") + "%\';";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Product ID, Name, Price, Category ID, Create Date, Description
                                products.Add(new product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetString(5)));
                            }
                        }
                    }
                    connection.Close();
                    // Removing products that don't match the category. 
                    // 0 is for all products
                    if (category > 0)
                    {
                        products.RemoveAll(p => p.category != category);
                    }
                    return products;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return products;
        }

        public static List<category> GetCategories()
        {
            List<category> categories = new List<category>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM catagory;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Category ID, Name
                                categories.Add(new category(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                    }
                    connection.Close();
                    return categories;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return categories;
        }

        public static List<company> GetCompanies()
        {
            List<company> companies = new List<company>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM company;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Company ID, Name, Revenue, CategoryID
                                companies.Add(new company(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                            }
                        }
                    }
                    connection.Close();
                    return companies;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return companies;
        }

        public static List<account> GetAccounts()
        {
            List<account> accounts = new List<account>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM account;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Account ID, Username, Password
                                accounts.Add(new account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                            }
                        }
                    }
                    connection.Close();
                    return accounts;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return accounts;
        }

		public static void DeleteAccount(int accountID)
		{
			try
			{
				var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var query = "DELETE FROM Account WHERE AccountID=@accountID;";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@accountID", accountID);
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

		public static void EditAccount(int accountID, string username, string password, string accountType)
		{
			try
			{
				var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var query = "UPDATE Account SET Username=@username, Password=@password, AccountType=@accountType WHERE AccountID=@accountID;";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@accountID", accountID);
						command.Parameters.AddWithValue("@username", username);
						command.Parameters.AddWithValue("@password", password);
						command.Parameters.AddWithValue("@accountType", accountType);
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

        public static void CreateAccount(string username, string password, string accountType)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Account(Username, Password, AccountType) VALUES (@username, @password, @accountType);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@accountType", accountType);
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

        public static List<client> GetLeads(string searchTerm = "")
		{
			List<client> clients = new List<client>();
			try
			{
				var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					var query = "select client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate, Client.inactive, Company.employees, Company.Companyrevenue From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID where EmpID=6;";
					if (searchTerm != "")
					{
						query = "SELECT client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate, Client.inactive, Company.employees, Company.Companyrevenue From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID WHERE client.ClientID LIKE '%" + searchTerm + "%' OR client.Email LIKE  '%" + searchTerm + "%' OR " +
														   "client.fName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR client.lName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR " +
															"client.PhoneNum LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR client.EmpID LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR " +
															"company.CompanyName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR client.CatagoryID LIKE \'%" + searchTerm.Replace("+", " ") + "%\' AND EmpID=6;";
					}

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								// Client ID, Email, First Name, Last Name, Company Name, Phone Number, Employee ID, Category Name, Client Join Date, Client Inactive, Company employees, Company revenue
								clients.Add(new client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetString(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11)));
							}
						}
					}
					clients.RemoveAll(p => p.employeeID != 6);
                    clients.RemoveAll(p => p.inactive == 1);
					connection.Close();
					return clients;
				}
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.ToString());
			}
			Console.ReadLine();
			return clients;
		}

        public static List<client> GetInactiveLeads()
        {
            List<client> clients = new List<client>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "select client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate, Client.inactive, Company.employees, Company.Companyrevenue From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID where EmpID=6;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Client ID, Email, First Name, Last Name, Company Name, Phone Number, Employee ID, Category Name, Client Join Date, Client Inactive, Company employees, Company revenue
                                clients.Add(new client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetString(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11)));
                            }
                        }
                    }
                    clients.RemoveAll(p => p.inactive == 0);
                    connection.Close();
                    return clients;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return clients;
        }

        // Function to set leads as inactive using the clientID as input
        public static void InactivateLead(int clientID)
        {
            UpdateLeadInactive(clientID, 1);
            return;
        }

        // Function to set leads as active using the clientID as input
        public static void ReactivateLead(int clientID)
        {
            UpdateLeadInactive(clientID, 0);
            return;
        }

        // Function to hide or unhide leads using the clientID as input
        public static void UpdateLeadInactive(int clientID, int inactiveStatus)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "UPDATE Client SET inactive=@inactiveStatus WHERE ClientID=@clientID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@inactiveStatus", inactiveStatus);
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

        public static void addClient(int clientID, int empID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "UPDATE Client SET EmpID=@empID WHERE ClientID=@clientID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@empID", empID);
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


        public static List<client> GetClients(int employeeID = 0, string searchTerm = "") // Default value of 0 to receive all clients (non-leads) in the system
        {
            List<client> clients = new List<client>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "select client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate, Client.inactive, Company.employees, Company.Companyrevenue From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID;";
                    if (searchTerm != "")
                    {
                        query = "SELECT client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate, Client.inactive, Company.employees, Company.Companyrevenue From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID WHERE client.ClientID LIKE '%" + searchTerm + "%' OR client.Email LIKE  '%" + searchTerm + "%' OR " +
                                                           "client.fName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR client.lName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR " +
                                                            "client.PhoneNum LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR client.EmpID LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR " +
                                                            "company.CompanyName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR client.CatagoryID LIKE \'%" + searchTerm.Replace("+", " ") + "%\';";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Client ID, Email, First Name, Last Name, Company Name, Phone Number, Employee ID, Category Name, Client Join Date
                                clients.Add(new client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetString(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11)));
                            }
                        }
                    }
                    connection.Close();
                    if (employeeID > 0) // If employeeID == 6, display all leads. If employeeID > 0, display clients owned by the logged-in salesperson
                    {
                        clients.RemoveAll(p => p.employeeID != employeeID);
                        clients.RemoveAll(p => p.inactive == 1);
                    }
                    else if (employeeID == 0) // Displaying all clients in the system, and not displaying leads
                    {
                        clients.RemoveAll(p => p.employeeID == 6);
                        clients.RemoveAll(p => p.inactive == 1);
                    }
                    return clients;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return clients;
        }

        public static client GetClientFromID(int clientID)
        {
            var client = new client();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "select client.ClientID, client.email, client.fName, client.lName, company.CompanyName, client.PhoneNum, client.EmpID, Catagory.CatagoryName, Client.JoinDate, Client.inactive, Company.employees, Company.Companyrevenue From company inner join client on Company.CompanyID = client.CompanyID inner join catagory on client.CatagoryID = Catagory.CatagoryID " +
                        "WHERE ClientID='"+clientID+"';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Client ID, Email, First Name, Last Name, Company Name, Phone Number, Employee ID, Category Name, Client Join Date, Client Inactive
                                client = new client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDecimal(5), reader.GetInt32(6), reader.GetString(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11));
                            }
                        }
                    }
                    connection.Close();
                    return client;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return client;
        }

        public static deal GetDealFromID(int dealID)
        {
            var deal = new deal();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT Deal.DealDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID FROM Deal INNER JOIN Client on Deal.ClientID = Client.ClientID INNER JOIN Employee on Deal.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Deal.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID " +
                        "WHERE DealID='" + dealID + "';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Deal ID, Date, Company Name, Client First Name, Client Last Name, Employee First Name, Employee Last Name, Product Name, Category Name, Client ID
                                deal = new deal(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8));
                            }
                        }
                    }
                    connection.Close();
                    return deal;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return deal;
        }

        public static int GetEmpIDFromAccID(int accID)
        {
            int empID = 0;
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM employee WHERE AccountID='" + accID + "';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empID = reader.GetInt32(0);
                            }
                        }
                    }
                    connection.Close();
                    return empID;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return empID;
        }

        // Function to remove client from an employee using the clientID as input
        public static void RemoveClient(int clientID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "UPDATE Client SET EmpID=6 WHERE ClientID=@clientID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientID", clientID);
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

        // Function to edit client
        public static void EditClient(int clientID, string email, string fName, string lName, decimal phone, string catID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "UPDATE Client SET Email=@email, fName=@fName, lName=@lName, PhoneNum=@phone, CatagoryID=@catID, inactive=0 WHERE ClientID=@clientID;";

                    // Convert catID into integer
                    int intCatID;
                    switch(catID)
                    {
                        case "Restaurants & Quick-Serve Restaurants": 
                            intCatID = 6; 
                            break;
						case "Retail":
							intCatID = 2;
							break;
						case "Professional Services":
							intCatID = 3;
							break;
						case "Personal Services":
							intCatID = 4;
							break;
						case "Construction":
							intCatID = 1;
							break;
						case "Business to Business":
							intCatID = 5;
							break;
                        default:
                            intCatID = 7;
                            break;
					}

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@fName", fName);
                        command.Parameters.AddWithValue("@lName", lName);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@catID", intCatID);
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

        public static List<meeting> GetMeetings(int userID)
        {
            List<meeting> meetings = new List<meeting>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT meeting.meetingid, meeting.meetingtime, meeting.meetingdate, meeting.clientid, meeting.empid, client.fname, company.companyname from meeting inner join client on meeting.clientid = client.ClientID inner join company on client.companyid = company.companyID " +
                                "WHERE meeting.EmpID=" + userID + ";";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Meeting ID, Time, Date, Client ID, Employee ID
                                meetings.Add(new meeting(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6)));
                            }
                        }
                    }
                    connection.Close();
                    return meetings;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return meetings;
        }
        
        public static List<sale> GetSales(string searchTerm = "")
        {
            List<sale> sales = new List<sale>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT Sale.SaleDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID, Sale.fk_DealID, Sale.SaleRevenue FROM Sale INNER JOIN Client on Sale.ClientID = Client.ClientID INNER JOIN Employee on Sale.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Sale.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID;";

                    if (searchTerm != "")
                    {
                        query = "SELECT Sale.SaleDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID, Sale.fk_DealID, Sale.SaleRevenue FROM Sale INNER JOIN Client on Sale.ClientID = Client.ClientID INNER JOIN Employee on Sale.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Sale.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID WHERE " +
                                                         "Sale.SaleDate LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR Company.CompanyName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR CONCAT(Client.fName, ' ', Client.lName) LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR " +
                                                         "CONCAT(Employee.fName, ' ', Employee.lName) LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR Product.ProductName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR Catagory.CatagoryName LIKE \'%" + searchTerm.Replace("+", " ") + "%\';";
                    }
                    

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Sale Date, Company Name, Client First Name, Client Last Name, Employee First Name, Employee Last Name, Product Name, Category Name, Client ID, Associated Deal ID
                                sales.Add(new sale(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetInt32(10)));
                            }
                        }
                    }
                    connection.Close();
                    sales.Sort((s1, s2) => DateTime.Compare(s2.date, s1.date));
                    return sales;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return sales;
        }

        public static List<sale> CreateSale(int empID, DateTime date, string fName, string lName, string prodName, int revenue)
        {
            List<sale> sales = new List<sale>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the ClientID
                    string clientIDQuery = "SELECT ClientID FROM Client WHERE (fname=@fName AND lName=@lName);";
                    int clientID;
                    using (SqlCommand command = new SqlCommand(clientIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@fName", fName);
                        command.Parameters.AddWithValue("@lName", lName);
                        clientID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Get the ProductID
                    string productIDQuery = "SELECT ProductID FROM Product WHERE ProductName=@prodName;";
                    int productID;
                    using (SqlCommand command = new SqlCommand(productIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@prodName", prodName);
                        productID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Get the CategoryID
                    string categoryIDQuery = "SELECT CatagoryID FROM Product WHERE ProductID=@productID;";
                    int categoryID;
                    using (SqlCommand command = new SqlCommand(categoryIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@productID", productID);
                        categoryID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Get the saleID
                    string saleIDQuery = "SELECT MAX(SaleID) FROM Sale;";
                    int saleID;
                    using (SqlCommand command = new SqlCommand(saleIDQuery, connection))
                    {
                        saleID = Convert.ToInt32(command.ExecuteScalar());
                        saleID += 1;
                    }

                    // Get the dealID
                    string dealIDQuery = "SELECT DealID FROM Deal WHERE EmpID=@empID AND ClientID=@clientID AND ProductID=@productID;";
                    int dealID;
                    using (SqlCommand command = new SqlCommand(dealIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@empID", empID);
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@productID", productID);
                        dealID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Insert into Sale table
                    string query = "INSERT INTO Sale(SaleID, EmpID, SaleDate, ClientID, ProductID, CatagoryID, Alert, fk_DealID, SaleRevenue) VALUES (@saleID, @empID, @date, @clientID, @prodID, @categoryID, 0, @dealID, @revenue);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@saleID", saleID);
                        command.Parameters.AddWithValue("@empID", empID);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@prodID", productID);
                        command.Parameters.AddWithValue("@revenue", revenue);
                        command.Parameters.AddWithValue("@categoryID", categoryID);
                        command.Parameters.AddWithValue("@dealID", dealID);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return sales;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return sales;
        }

        public static List<note> GetNotes(int employeeID = 0, string searchTerm = "") // Specify the employeeID parameter to receive notes from a specific employee
        {
            List<note> notes = new List<note>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "Select Notes.NoteId, Notes.EmpID, Notes.NoteName, Notes.Contents, Catagory.CatagoryID, Catagory.CatagoryName FROM Notes INNER JOIN Catagory on Notes.CatagoryID = Catagory.CatagoryID;";
                    if (searchTerm != "")
                    {
                        query = "Select Notes.NoteId, Notes.EmpID, Notes.NoteName, Notes.Contents, Catagory.CatagoryID, Catagory.CatagoryName FROM Notes INNER JOIN Catagory on Notes.CatagoryID = Catagory.CatagoryID WHERE NoteName LIKE \'%" + searchTerm.Replace("+", " ") + "%\' OR Contents LIKE  \'%" + searchTerm.Replace("+", " ") + "%\'" +
                                                           " OR CatagoryID LIKE \'%" + searchTerm.Replace("+", " ") + "%\';";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Note ID, Employee ID, Name, Contents, Category ID, Category Name
                                notes.Add(new note(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5)));
                            }
                        }
                    }
                    connection.Close();
                    if (employeeID > 0) // Displaying only notes owned by the logged-in salesperson
                    {
                        notes.RemoveAll(p => p.employeeID != employeeID);
                    }
                    return notes;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return notes;
        }

        // Function to create note
        public static void CreateNote(int EmpID, string NoteName, string Contents, int catID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "INSERT INTO Notes(EmpID, NoteName, Contents, CatagoryID) VALUES (@EmpID, @NoteName, @Contents, @catID);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", EmpID);
                        command.Parameters.AddWithValue("@NoteName", NoteName);
                        command.Parameters.AddWithValue("@Contents", Contents);
                        command.Parameters.AddWithValue("@catID", catID);
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

        // Function to delete note using the noteID as input
        public static void DeleteNote(int noteID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "DELETE FROM Notes WHERE NoteID=@noteID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@noteID", noteID);
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

        // Function to edit note using the noteID as input
        public static void EditNote(int noteID, string NoteName, string Contents, int CatagoryID)
        {
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "UPDATE Notes SET NoteName=@NoteName, Contents=@Contents, CatagoryID=@CatagoryID WHERE NoteID=@noteID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@noteID", noteID);
                        command.Parameters.AddWithValue("@NoteName", NoteName);
                        command.Parameters.AddWithValue("@Contents", Contents);
                        command.Parameters.AddWithValue("@CatagoryID", CatagoryID);
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

        // Function to retrieve new lead audit log entries
        public static List<auditLogEntry> GetAuditLogEntries()
        {
            List<auditLogEntry> auditLogEntries = new List<auditLogEntry>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM AuditLog;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Audit log entry
                                auditLogEntries.Add(new auditLogEntry(reader.GetString(0)));
                            }
                        }
                    }
                    connection.Close();
                    return auditLogEntries;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return auditLogEntries;
        }

        public static List<task> GetTasks(int userID)
        {
            List<task> tasks = new List<task>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT * FROM task WHERE task.EmpID=" + userID + ";";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Task ID, Name, Employee ID
                                tasks.Add(new task(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                            }
                        }
                    }
                    connection.Close();
                    return tasks;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return tasks;
        }

        public static List<deal> GetDeals(int empID, string searchTerm)
        {
            List<deal> deals = new List<deal>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT Deal.DealDate, Company.CompanyName, Client.fName, Client.lName, Employee.fName, Employee.lName, Product.ProductName, Catagory.CatagoryName, Client.ClientID FROM Deal INNER JOIN Client on Deal.ClientID = Client.ClientID INNER JOIN Employee on Deal.EmpID = Employee.EmpID INNER JOIN Product on Product.ProductID = Deal.ProductID INNER JOIN Catagory on Catagory.CatagoryID = Client.CatagoryID INNER JOIN Company on Company.CompanyID = Client.CompanyID WHERE Employee.EmpID=@empID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@empID", empID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Deal Date, Company Name, Client First Name, Client Last Name, Employee First Name, Employee Last Name, Product Name, Category Name, Client ID
                                deals.Add(new deal(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8)));
                            }
                        }
                    }
                    connection.Close();
                    return deals;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return deals;
        }

        public static List<deal> CreateDeal(int empID, DateTime date, string fName, string lName, string prodName)
        {
            List<deal> deals = new List<deal>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the ClientID
                    string clientIDQuery = "SELECT ClientID FROM Client WHERE (fname=@fName AND lName=@lName);";
                    int clientID;
                    using (SqlCommand command = new SqlCommand(clientIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@fName", fName);
                        command.Parameters.AddWithValue("@lName", lName);
                        clientID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Get the ProductID
                    string productIDQuery = "SELECT ProductID FROM Product WHERE ProductName=@prodName;";
                    int productID;
                    using (SqlCommand command = new SqlCommand(productIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@prodName", prodName);
                        productID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Insert into Deal table
                    string query = "INSERT INTO Deal(EmpID, DealDate, ClientID, ProductID) VALUES (@empID, @date, @clientID, @prodID);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@empID", empID);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@prodID", productID);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return deals;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return deals;
        }

        public static List<deal> EditDeal(int empID, DateTime newDate, DateTime oldDate, string fName, string lName, string prodName)
        {
            List<deal> deals = new List<deal>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the ClientID
                    string clientIDQuery = "SELECT ClientID FROM Client WHERE (fname=@fName AND lName=@lName);";
                    int clientID;
                    using (SqlCommand command = new SqlCommand(clientIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@fName", fName);
                        command.Parameters.AddWithValue("@lName", lName);
                        clientID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Get the ProductID
                    string productIDQuery = "SELECT ProductID FROM Product WHERE ProductName=@prodName;";
                    int productID;
                    using (SqlCommand command = new SqlCommand(productIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@prodName", prodName);
                        productID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Get the CategoryID
                    string categoryIDQuery = "SELECT CatagoryID FROM Product WHERE ProductID=@productID;";
                    int categoryID;
                    using (SqlCommand command = new SqlCommand(categoryIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@productID", productID);
                        categoryID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Insert into Deal table
                    var query = "UPDATE Deal SET DealDate=@newDate, ClientID=@clientID, ProductID=@prodID, CatagoryID=@categoryID WHERE (DealDate=@oldDate AND EmpID=@empID);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@empID", empID);
                        command.Parameters.AddWithValue("@newDate", newDate);
                        command.Parameters.AddWithValue("@oldDate", oldDate);
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@prodID", productID);
                        command.Parameters.AddWithValue("@categoryID", categoryID);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return deals;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return deals;
        }

        public static List<deal> DeleteDeal(int empID, DateTime date, string clientfName, string clientlName, string productName)
        {
            List<deal> deals = new List<deal>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the ClientID
                    string clientIDQuery = "SELECT ClientID FROM Client WHERE (fname=@fName AND lName=@lName);";
                    int clientID;
                    using (SqlCommand command = new SqlCommand(clientIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@fName", clientfName);
                        command.Parameters.AddWithValue("@lName", clientlName);
                        clientID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Get the ProductID
                    string productIDQuery = "SELECT ProductID FROM Product WHERE ProductName=@prodName;";
                    int productID;
                    using (SqlCommand command = new SqlCommand(productIDQuery, connection))
                    {
                        command.Parameters.AddWithValue("@prodName", productName);
                        productID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Delete from Deal table
                    var query = "DELETE FROM Deal WHERE EmpID=@empID AND DealDate=@date AND ClientID=@clientID AND ProductID=@prodID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@empID", empID);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@clientID", clientID);
                        command.Parameters.AddWithValue("@prodID", productID);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return deals;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            return deals;
        }

        public static List<recommended> GetRecommendeds(string catname)
        {
            List<recommended> recommendeds = new List<recommended>();
            try
            {
                var connectionString = @"Server=tcp:jp-morgan.database.windows.net,1433;Initial Catalog=JP-Morgan;Persist Security Info=False;User ID=JPMorgan;Password=SeniorProject#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = "SELECT product.ProductName FROM Product INNER JOIN sale ON Product.ProductID = sale.ProductID INNER JOIN client ON client.clientid = sale.clientid INNER JOIN Catagory ON Catagory.CatagoryID = Client.CatagoryID WHERE Catagory.CatagoryName LIKE @Category;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Category", "%" + catname + "%");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recommendeds.Add(new recommended(reader.GetString(0)));
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

        public static List<leaddealsale> GetLeadDealSales()
        {
            List<leaddealsale> leaddealsales = new List<leaddealsale>();
            List<sale> sales = GetSales();

            foreach(sale s in sales)
            {
                leaddealsales.Add(new leaddealsale(s));
            }
            leaddealsales.Sort((lds1, lds2) => DateTime.Compare(lds2.saleDate, lds1.saleDate));
            return leaddealsales;
        }

    }
}