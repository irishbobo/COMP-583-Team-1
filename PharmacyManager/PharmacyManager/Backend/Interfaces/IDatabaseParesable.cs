using System.Data.SqlClient;

namespace PharmacyManager.Backend.Interfaces
{
    interface IDatabaseParesable
    {
        void ParseFromReader(SqlDataReader reader);
    }
}
