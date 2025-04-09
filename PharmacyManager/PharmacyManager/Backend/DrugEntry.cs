using PharmacyManager.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
