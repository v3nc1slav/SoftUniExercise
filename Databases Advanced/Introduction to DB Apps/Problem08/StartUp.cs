using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Introduction_to_DB_Apps;


namespace Problem08
{
    public class StartUp
    {
       public  static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionDatabase))
            {
                connection.Open();

                List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

                string minionQuery = @" UPDATE Minions   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id = @Id";
                string print = @"SELECT Name, Age FROM Minions";

                for (int i = 0; i < input.Count ; i++)
                {
                    using (SqlCommand command = new SqlCommand(minionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", input[i]);

                        command.ExecuteNonQuery();
                    }
                }
                using (SqlCommand command = new SqlCommand(print, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }

            }
        }
    }
}
