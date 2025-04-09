using PharmacyManager.Backend.Interfaces;
using System;
using System.Data.SqlClient;

namespace PharmacyManager.Backend
{
    class DrugEntry : IDatabaseParesable
    {
        public int drugID;
        public string name;
        public DateTime expirationDate;
        public int amount;

        public void ParseFromReader(SqlDataReader reader)
        {
            drugID = reader.GetInt32(0);
            name = reader.GetString(1);
            expirationDate = reader.GetDateTime(2);
            amount = reader.GetInt32(3);
        }
    }
}
