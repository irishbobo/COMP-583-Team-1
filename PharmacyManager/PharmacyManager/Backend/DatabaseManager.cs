using PharmacyManager.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PharmacyManager.Backend
{
    class DatabaseManager
    {
        // Constants
        private const int MAX_RETRIEVE_SIZE = 10;
        private const string LOCAL_CONNECTION_STRING = @"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=true";

        // Fields - Singleton
        private static DatabaseManager _instance;

        // Methods - Instance Control
        public static List<T> GetRows<T>(string tableName,
                                         string sortColumnName,
                                         int startRange = 0, 
                                         int count = MAX_RETRIEVE_SIZE) where T : IDatabaseParesable, new()        
        {
            List<T> values = new List<T>();

            // Open the connection to the database.
            using (SqlConnection dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            {
                // Connect to the database.
                dbConnection.Open();


                // Get the size of the database.
                int databaseSize = -1;
                string countQuery = 
                    $"SELECT COUNT(*) " +
                    $"FROM dbo.{tableName}";
                using (SqlCommand countCommand = new SqlCommand(countQuery, dbConnection))
                {
                    databaseSize = (int) countCommand.ExecuteScalar();
                }

                // Limit the query count to only as many values are in the database.
                count = Math.Min(count, databaseSize);


                // Create the query command to get all values in the range between startRange and endRange.
                string queryString = 
                        $"SELECT *\n" +
                        $"FROM dbo.{tableName}\n" +
                        $"ORDER BY {sortColumnName}\n" +
                        $"OFFSET {startRange} ROWS\n" +
                        $"FETCH NEXT {count} ROWS ONLY\n";
                using (SqlCommand queryCommand = new SqlCommand(queryString, dbConnection))
                {
                    // Create an SQL Data Reader to iterate the data.
                    using (SqlDataReader reader = queryCommand.ExecuteReader())
                    {
                        // Read each row.
                        while (reader.Read())
                        {
                            // Create the new value to store.
                            T newValue = new T();
                            newValue.ParseFromReader(reader);

                            // Parse each row to the drugs list.
                            values.Add(newValue);
                        }
                    }
                }

                // End the connection with the database.
                dbConnection.Close();
            }

            // Return the retrieved drugs.
            return values;
        }
    }
}
