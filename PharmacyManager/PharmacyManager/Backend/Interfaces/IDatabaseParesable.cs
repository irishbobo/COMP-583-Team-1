using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager.Backend.Interfaces
{
    interface IDatabaseParesable
    {
        void ParseFromReader(SqlDataReader reader);
    }
}
