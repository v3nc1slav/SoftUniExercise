using System;
using System.Data.SqlClient;
using Introduction_to_DB_Apps;

namespace Problem02
{
    public class SartUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionDatabase))
            {
                connection.Open();

                string Problem02 = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v 
    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name   HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(Problem02, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} - {age}");
                        }
                    }
                }
            }
        }
    }
}
