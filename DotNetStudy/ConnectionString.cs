using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy
{
    internal class ConnectionString
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetRevision",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
    };
}
