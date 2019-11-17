using System;
using System.Data.SqlClient;
using Introduction_to_DB_Apps;

namespace Problem09
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionDatabase))
            {
                connection.Open();

                int input = int.Parse(Console.ReadLine());

                string execQuery = @"EXEC usp_GetOlder @id";
                string print = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(execQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", input);

                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(print, connection))
                {
                    command.Parameters.AddWithValue("@id", input);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} – {age} years old");
                    }
                }
            }
        }
    }
}
