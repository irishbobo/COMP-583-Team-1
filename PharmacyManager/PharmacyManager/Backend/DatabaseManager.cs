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

        public static int AddRow(string tableName, Dictionary<string, object> columnValues)
        {
            int rowsAffected = 0;

            using (SqlConnection dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            {
                dbConnection.Open();

                // Prepare lists for the column names and parameter placeholders.
                List<string> columns = new List<string>();
                List<string> parameters = new List<string>();

                // Create the SqlCommand and add parameters dynamically.
                using (SqlCommand insertCommand = new SqlCommand())
                {
                    insertCommand.Connection = dbConnection;

                    int paramIndex = 0;
                    foreach (var pair in columnValues)
                    {
                        // Collect the column name.
                        columns.Add(pair.Key);

                        // Create a parameter name like "@param0", "@param1", etc.
                        string parameterName = $"@param{paramIndex}";
                        parameters.Add(parameterName);

                        // Add the parameter and its corresponding value.
                        insertCommand.Parameters.AddWithValue(parameterName, pair.Value);
                        paramIndex++;
                    }

                    // Join the columns and parameters into comma-separated lists.
                    string columnsJoined = string.Join(", ", columns);
                    string parametersJoined = string.Join(", ", parameters);

                    // Create the INSERT query.
                    string insertQuery = $"INSERT INTO dbo.{tableName} ({columnsJoined}) VALUES ({parametersJoined});";
                    insertCommand.CommandText = insertQuery;

                    // Execute the command.
                    rowsAffected = insertCommand.ExecuteNonQuery();
                }

                dbConnection.Close();
            }

            return rowsAffected;
        }

        public static int UpdateRowValue(string tableName, string keyColumn, object keyValue, string updateColumn, object newValue)
        {
            int rowsAffected = 0;

            using (SqlConnection dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            {
                dbConnection.Open();

                // Build the UPDATE query.
                string updateQuery = $"UPDATE dbo.{tableName} SET {updateColumn} = @newValue WHERE {keyColumn} = @keyValue;";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, dbConnection))
                {
                    // Add parameters to the command.
                    updateCommand.Parameters.AddWithValue("@newValue", newValue);
                    updateCommand.Parameters.AddWithValue("@keyValue", keyValue);

                    // Execute the query.
                    rowsAffected = updateCommand.ExecuteNonQuery();
                }

                dbConnection.Close();
            }

            return rowsAffected;
        }

        public static int DeleteRow(string tableName, string keyColumn, object keyValue)
        {
            int rowsAffected = 0;

            // Open the connection to the database.
            using (SqlConnection dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            {
                dbConnection.Open();

                // Build the DELETE query with a parameter for the key value.
                string deleteQuery = $"DELETE FROM dbo.{tableName} WHERE {keyColumn} = @keyValue;";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, dbConnection))
                {
                    // Add the parameter value to the command.
                    deleteCommand.Parameters.AddWithValue("@keyValue", keyValue);

                    // Execute the DELETE command.
                    rowsAffected = deleteCommand.ExecuteNonQuery();
                }

                // Close the connection.
                dbConnection.Close();
            }

            return rowsAffected;
        }

        public static List<string> GetUniqueDrugNames()
        {
            List<string> uniqueNames = new List<string>();

            using (SqlConnection dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            {
                dbConnection.Open();

                // Query to select distinct drug names.
                string query = "SELECT DISTINCT Name FROM dbo.Drug ORDER BY Name;";

                using (SqlCommand command = new SqlCommand(query, dbConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Since 'Name' is defined as NOT NULL, we can directly convert to string.
                            uniqueNames.Add(reader["Name"].ToString());
                        }
                    }
                }

                dbConnection.Close();
            }

            return uniqueNames;
        }

        public enum SortOrder
        {
            ExpRecent,
            ExpOldest,
            IDAsc,
            IDDesc
        }
        public static List<DrugEntry> SearchDrugs(string name, int count, SortOrder sortOrder)
        {
            List<DrugEntry> drugs = new List<DrugEntry>();

            // Determine the ORDER BY clause based on the sortOrder parameter.
            // "ExpRecent": Order by ExpirationDate descending (most recent first).
            // "ExpOldest": Order by ExpirationDate ascending (oldest/earliest first).
            // "IDAsc": Order by DrugID in ascending order.
            // "IDDesc": Order by DrugID in descending order.
            string orderByClause;
            switch (sortOrder)
            {
                case SortOrder.ExpRecent:
                    orderByClause = "ORDER BY ExpirationDate DESC";
                    break;
                case SortOrder.ExpOldest: 
                    orderByClause = "ORDER BY ExpirationDate ASC";
                    break;
                case SortOrder.IDAsc: 
                    orderByClause = "ORDER BY DrugID ASC";
                    break;
                case SortOrder.IDDesc: 
                    orderByClause = "ORDER BY DrugID DESC";
                    break;
                default:
                    orderByClause = "ORDER BY DrugID ASC";
                    break;
            };

            using (SqlConnection dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            {
                dbConnection.Open();

                // Build the SQL query:
                // - It filters rows by Name.
                // - It sorts the results as determined by orderByClause.
                // - It returns only the first "count" rows using SQL Server's OFFSET-FETCH syntax.
                string query = $@"
            SELECT *
            FROM dbo.Drug
            WHERE Name = @Name
            {orderByClause}
            OFFSET 0 ROWS
            FETCH NEXT @Count ROWS ONLY;";

                using (SqlCommand command = new SqlCommand(query, dbConnection))
                {
                    // Add parameters to help prevent SQL injection.
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Count", count);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create a new Drug instance and populate it via your ParseFromReader method.
                            DrugEntry drug = new DrugEntry();
                            drug.ParseFromReader(reader);
                            drugs.Add(drug);
                        }
                    }
                }

                dbConnection.Close();
            }

            return drugs;
        }


    }
}
