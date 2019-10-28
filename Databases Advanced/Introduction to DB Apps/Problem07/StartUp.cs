using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Introduction_to_DB_Apps;

namespace Problem07
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionDatabase))
            {
                connection.Open();

                List<string> printName = new List<string>();

                string minionQuery = @"SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(minionQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            printName.Add((string)reader[0]);
                        }

                        for (int i = 0; i < (printName.Count - 1) / 2; i++)
                        {
                            Console.WriteLine(printName[i]);
                            Console.WriteLine(printName[printName.Count - 1 - i]);
                        }
                    }
                }
            }
        }
    }
}
