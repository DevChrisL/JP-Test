using System;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using static ImportNewLeadsHourly.Program;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.Intrinsics.Arm;

namespace ImportNewLeadsHourly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Start importing new leads ====");
            ImportNewLeads();
            Console.WriteLine("=============== End ===============");
        }

        private static void ImportNewLeads()
        {
            // Download CSV file from Google Forms
            string url = @"https://docs.google.com/spreadsheets/d/e/2PACX-1vSYvFPiq8ADTswNMOfe9OEwBTgazcnsE48OEl1kRv9FvCqYvWLB-zrXySdkIioYmSFkzWItYhKqmoIM/pub?output=csv";
            string saveFileName = "NewLeads.csv";
            new System.Net.WebClient().DownloadFile(url, saveFileName);

            // Determining the line to start reading from so we can avoid duplicate data
            string fileLineNumber = "LineNumber.txt";

            // Creating file if it does not exist
            if (!File.Exists(fileLineNumber))
            {
                using (StreamWriter sw = File.AppendText(fileLineNumber))
                {
                    // Default line to read after the file is created
                    sw.WriteLine('2');
                    sw.Close();
                }
            }

            // Reading from the file
            StreamReader sr = new StreamReader(fileLineNumber);
            string line = sr.ReadLine();
            int lineContinue = Convert.ToInt32(line);
            sr.Close();

            // Parsing the CSV file
            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser("./" + saveFileName))
            {
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] fields;
                List<string> newLeadsInfo = new List<string>();
                int newLeadCounter = 0;
                // Read a line each time we iterate through this loop
                while (!parser.EndOfData)
                {
                    if ((int)parser.LineNumber >= lineContinue)
                    {
                        lineContinue = (int)parser.LineNumber + 1;
                        System.IO.File.WriteAllText(fileLineNumber, Convert.ToString(lineContinue));

                        // Reading fields sequentially
                        fields = parser.ReadFields();
                        int counter = 0;
                        lead lead = new lead();
                        company company = new company();
                        Console.WriteLine("\n");
                        try
                        {
                            foreach (string field in fields)
                            {
                                switch (counter)
                                {
                                    // Determining which field we're reading from the row
                                    case 0:
                                        Console.WriteLine($"[{counter}] {field}");
                                        lead.joinDate = Convert.ToDateTime(field);
                                        break;
                                    case 1:
                                        Console.WriteLine($"[{counter}] {field}");
                                        lead.firstName = database.Escape(Convert.ToString(field));
                                        break;
                                    case 2:
                                        Console.WriteLine($"[{counter}] {field}");
                                        lead.lastName = database.Escape(Convert.ToString(field));
                                        break;
                                    case 3:
                                        Console.WriteLine($"[{counter}] {field}");
                                        lead.email = database.Escape(Convert.ToString(field));
                                        break;
                                    case 4:
                                        Console.WriteLine($"[{counter}] {field}");
                                        lead.phoneNumber = Convert.ToDecimal(field);
                                        break;
                                    case 5:
                                        Console.WriteLine($"[{counter}] {field}");
                                        company.name = database.Escape(Convert.ToString(field));
                                        break;
                                    case 6:
                                        Console.WriteLine($"[{counter}] {field}");
                                        company.revenue = Convert.ToInt32(field);
                                        break;
                                    case 7:
                                        Console.WriteLine($"[{counter}] {field}");
                                        company.employees = Convert.ToInt32(field);
                                        break;
                                    case 8:
                                        Console.WriteLine($"[{counter}] {field}");
                                        string categoryName = Convert.ToString(field);
                                        // Using nested ternary statements to find the category ID for the lead's selection
                                        company.categoryID = categoryName.IndexOf("Construction") != -1 ? 1 :
                                        categoryName.IndexOf("Retail") != -1 ? 2 :
                                        categoryName.IndexOf("Professional Services") != -1 ? 3 :
                                        categoryName.IndexOf("Personal Services") != -1 ? 4 :
                                        categoryName.IndexOf("Business to Business") != -1 ? 5 :
                                        categoryName.IndexOf("Restaurants & Quick-Serve Restaurants") != -1 ? 6 :
                                        categoryName.IndexOf("Other") != -1 ? 7 : 7;
                                        lead.categoryID = company.categoryID;
                                        // Insert lead and company into database after the last item
                                        company.id = database.GetNewCompanyID();
                                        lead.id = database.GetNewLeadID();
                                        lead.companyID = company.id;
                                        lead.employeeID = 6; // New Lead
                                        database.CreateCompany(company);
                                        database.CreateLead(lead);
                                        newLeadsInfo.Add($"{(lead.firstName)} {lead.lastName} represents {company.name}. Company category = {categoryName}, revenue = {company.revenue}, number of employees = {company.employees}");
                                        newLeadCounter++;
                                        break;
                                    default:
                                        break;
                                }
                                counter++;
                            }
                        }
                        catch (Exception e) { Console.WriteLine(e); }
                    }
                    else
                    {
                        fields = parser.ReadFields();
                        continue;
                    }
                }

                switch (newLeadCounter)
                {
                    case 1:
                        Console.WriteLine("" + DateTime.Now.ToString() + " - " + newLeadCounter.ToString() + " new lead and company were added to the database.");
                        database.CreateAuditLogEntry("" + DateTime.Now.ToString() + " - " + newLeadCounter.ToString() + " new lead and company were added to the database.");
                        break;
                    default:
                        Console.WriteLine("" + DateTime.Now.ToString() + " - " + newLeadCounter.ToString() + " new leads and companies were added to the database.");
                        database.CreateAuditLogEntry("" + DateTime.Now.ToString() + " - " + newLeadCounter.ToString() + " new leads and companies were added to the database.");
                        break;
                }

                if (newLeadsInfo.Count > 0)
                {
                    foreach (string newLeadInfo in newLeadsInfo)
                    {
                        Console.WriteLine(newLeadInfo);
                        database.CreateAuditLogEntry(newLeadInfo);
                    }
                }

                // Sleep for 1 hour
                Thread.Sleep(3600000);

                // Recursion
                ImportNewLeads();
            }
        }
    }
}
