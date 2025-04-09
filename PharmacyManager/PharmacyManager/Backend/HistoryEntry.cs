using PharmacyManager.Backend.Interfaces;
using System;
using System.Data.SqlClient;

namespace PharmacyManager.Backend
{
    class HistoryEntry : IDatabaseParesable
    {
        public int historyID;
        public int drugID;
        public DateTime historyTime;
        public int beforeAmount;
        public int afterAmount;

        public void ParseFromReader(SqlDataReader reader)
        {
            historyID = reader.GetInt32(0);
            drugID = reader.GetInt32(1);
            historyTime = reader.GetDateTime(2);
            beforeAmount = reader.GetInt32(3);
            afterAmount = reader.GetInt32(4);
        }
    }
}
