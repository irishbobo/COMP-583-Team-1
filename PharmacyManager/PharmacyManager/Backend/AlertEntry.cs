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
        public int AlertID { get; set; }
        public int DrugID { get; set; }
        public AlertType AlertType { get; set; }
        public DateTime AlertTime { get; set; }
        public bool Acknowledged { get; set; }

        public void ParseFromReader(SqlDataReader reader)
        {
            AlertID = reader.GetInt32(0);
            DrugID = reader.GetInt32(1);
            AlertType = (reader.GetString(2) == "DrugExpiration")
                            ? AlertType.DrugExpiration
                            : AlertType.LowStock;
            AlertTime = reader.GetDateTime(3);
            Acknowledged = reader.GetBoolean(4);
        }
    }
}
