using PharmacyManager.Backend.Interfaces;
using System;
using System.Data.SqlClient;

namespace PharmacyManager.Backend
{
    struct DrugEntry : IDatabaseParesable
    {
        public int DrugID { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Amount { get; set; }

        public void ParseFromReader(SqlDataReader reader)
        {
            DrugID = reader.GetInt32(0);
            Name = reader.GetString(1);
            ExpirationDate = reader.GetDateTime(2);
            Amount = reader.GetInt32(3);
        }
    }
}
