using PharmacyManager.Backend.Interfaces;
using System;
using System.Data.SqlClient;

namespace PharmacyManager.Backend
{
    public enum AlertType
    {
        DrugExpiration,
        LowStock
    }
    class AlertEntry : IDatabaseParesable
    {
        public int alertID;
        public int drugID;
        public AlertType alertType;
        public DateTime alertTime;
        public bool acknowledged;

        public void ParseFromReader(SqlDataReader reader)
        {
            alertID = reader.GetInt32(0);
            drugID = reader.GetInt32(1);
            alertType = (reader.GetString(2) == "DrugExpiration")
                            ? AlertType.DrugExpiration
                            : AlertType.LowStock;
            alertTime = reader.GetDateTime(3);
            acknowledged = reader.GetBoolean(4);
        }
    }
}
