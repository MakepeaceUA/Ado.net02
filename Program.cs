using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=ARSEN;Initial Catalog=VegetableFruits;Integrated Security=True";

            using (SqlConnection sql_connect = new SqlConnection(connectionString))
            {
                try
                {
                    sql_connect.Open();
                    Console.WriteLine("Подключение к базе данных успешно.");
                    Console.WriteLine($"Сервер: {sql_connect.DataSource}");
                    Console.WriteLine($"База данных: {sql_connect.Database}\n");

                    Console.WriteLine("Все овощи и фрукты:");
                    using (SqlCommand command = new SqlCommand("SELECT * FROM VegFruTable ", sql_connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["ID"]}, Название: {reader["Name"]}, Калорийность: {reader["Calories"]}");
                        }
                    }
                    Console.WriteLine();

                    using (SqlCommand command = new SqlCommand("SELECT Calories FROM VegFruTable  ORDER BY Calories ASC", sql_connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Минимальная калорийность: " + reader["Calories"]);
                        }
                    }
                    Console.WriteLine();

                    int Count = 0;
                    using (SqlCommand command = new SqlCommand("SELECT Type FROM VegFruTable  WHERE Type = 'Vegetable'", sql_connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Count++;
                        }
                    }
                    Console.WriteLine("Количество овощей: " + Count);
                    Console.WriteLine();

                    int threshold = 50;
                    Console.WriteLine($"Овощи и фрукты с калорийностью ниже {threshold}: ");
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM VegFruTable  WHERE Calories < @Threshold", sql_connect))
                    {
                        cmd.Parameters.AddWithValue("@Threshold", threshold);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["ID"]}, Название: {reader["Name"]}, Калорийность: {reader["Calories"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                finally
                {
                    sql_connect.Close();
                    Console.WriteLine("Подключение закрыто.");
                }
            }
            Console.ReadLine();
        }
    }
}
