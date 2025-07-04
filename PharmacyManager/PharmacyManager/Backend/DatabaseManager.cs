﻿using PharmacyManager.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
        public static List<DrugEntry> SearchDrugs(int count, SortOrder sortOrder, 
                                                  string name = null, 
                                                  DateTime? expirationDateStart = null, 
                                                  DateTime? expirationDateEnd = null, 
                                                  int? id = null)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));

            // Determine which ordering to use.
            string orderByClause;            
            switch (sortOrder)
            {
                case SortOrder.ExpRecent:
                    orderByClause = "ORDER BY ExpirationDate DESC";
                    break;

                case SortOrder.ExpOldest:
                    orderByClause = "ORDER BY ExpirationDate ASC";
                    break;

                case SortOrder.IDDesc:
                    orderByClause = "ORDER BY DrugId DESC";
                    break;

                default:
                case SortOrder.IDAsc:
                    orderByClause = "ORDER BY DrugId ASC";
                    break;
            };

            // Put together the where-condition based on what's provided.
            var filters = new List<string>();
            if (string.IsNullOrWhiteSpace(name) == false)
                filters.Add("Name = @Name");
            if (expirationDateStart.HasValue)
                filters.Add("ExpirationDate >= @ExpirationDateStart");
            if (expirationDateEnd.HasValue)
                filters.Add("ExpirationDate <= @ExpirationDateEnd");
            if (id.HasValue)
                filters.Add("DrugId = @DrugId");

            string whereClause = filters.Count > 0
                               ? "WHERE " + string.Join(" AND ", filters)
                               : string.Empty;

            string query = $@"
                SELECT *
                FROM dbo.Drug
                {whereClause}
                {orderByClause}
                OFFSET 0 ROWS
                FETCH NEXT @Count ROWS ONLY;";

            var drugs = new List<DrugEntry>();

            using (var dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            {
                using (var command = new SqlCommand(query, dbConnection))
                {
                    // Only add parameters that will actually appear in the query
                    if (string.IsNullOrWhiteSpace(name) == false)
                        command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;

                    if (expirationDateStart.HasValue)
                        command.Parameters.Add("@ExpirationDateStart", SqlDbType.DateTime).Value = expirationDateStart.Value;
                    if (expirationDateEnd.HasValue)
                        command.Parameters.Add("@ExpirationDateEnd", SqlDbType.DateTime).Value = expirationDateEnd.Value;

                    if (id.HasValue)
                        command.Parameters.Add("@DrugId", SqlDbType.Int).Value = id.Value;

                    command.Parameters.Add("@Count", SqlDbType.Int).Value = count;

                    dbConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var drug = new DrugEntry();
                            drug.ParseFromReader(reader);
                            drugs.Add(drug);
                        }
                    }
                }
            }

            return drugs;
        }

        public static List<HistoryEntry> GetHistoryEntries(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException($"{nameof(startDate)} must be ≤ {nameof(endDate)}.");

            const string query = @"
        SELECT *
        FROM dbo.History
        WHERE HistoryTime BETWEEN @StartDate AND @EndDate
        ORDER BY HistoryTime ASC;";

            var historyEntries = new List<HistoryEntry>();

            using (var dbConnection = new SqlConnection(LOCAL_CONNECTION_STRING))
            using (var command = new SqlCommand(query, dbConnection))
            {
                command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entry = new HistoryEntry();
                        entry.ParseFromReader(reader);
                        historyEntries.Add(entry);
                    }
                }
            }

            return historyEntries;
        }

        public static Dictionary<int, string> GetDrugNamesForHistory(List<HistoryEntry> historyEntries)
        {
            if (historyEntries == null)
                throw new ArgumentNullException(nameof(historyEntries));

            var drugIds = historyEntries
                          .Select(h => h.drugID)
                          .Distinct()
                          .ToList();

            // No IDs – nothing to look up.
            if (drugIds.Count == 0)
                return new Dictionary<int, string>();

            // Build a parameterised IN-list: @id0, @id1, …
            var paramNames = drugIds
                             .Select((_, idx) => $"@id{idx}")
                             .ToArray();

            string query = $@"
            SELECT DrugId, Name
            FROM   dbo.Drug
            WHERE  DrugId IN ({string.Join(", ", paramNames)});";

            var result = new Dictionary<int, string>();

            using (var db = new SqlConnection(LOCAL_CONNECTION_STRING))
            using (var cmd = new SqlCommand(query, db))
            {
                for (int i = 0; i < drugIds.Count; i++)
                    cmd.Parameters.Add(paramNames[i], SqlDbType.Int).Value = drugIds[i];

                db.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        result[id] = name;
                    }
                }
            }

            return result;
        }

        public static List<ReportEntry> GenerateWeeklyAdjustmentReports(List<HistoryEntry> historyEntries, IDictionary<int, string> drugIdToName)
        {
            if (historyEntries == null) throw new ArgumentNullException(nameof(historyEntries));
            if (drugIdToName == null) throw new ArgumentNullException(nameof(drugIdToName));

            List<ReportEntry> report = new List<ReportEntry>();

            foreach (IGrouping<string, HistoryEntry> drugGroup in historyEntries.GroupBy(h => drugIdToName[h.drugID]))
            {
                // Resolve the friendly name (fallback if missing).
                string drugName = drugGroup.Key;

                // Work with the rows in chronological order.
                var ordered = drugGroup.OrderBy(h => h.historyTime).ToList();
                int totalDelta = ordered.Sum(h => h.afterAmount - h.beforeAmount);

                DateTime first = ordered.First().historyTime;
                DateTime last = ordered.Last().historyTime;
                double days = (last - first).TotalDays;

                // Treat any span shorter than a week as exactly one week.
                double weeks = Math.Max(days / 7.0, 1.0);

                int weeklyAverage = (int)Math.Round(totalDelta / weeks,
                                                 MidpointRounding.AwayFromZero);

                report.Add(new ReportEntry
                {
                    DrugName = drugName,
                    RecommendedWeeklySupply = weeklyAverage
                });
            }

            return report;
        }

    }
}
