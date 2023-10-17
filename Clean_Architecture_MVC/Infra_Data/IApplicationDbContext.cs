using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra_Data
{
    interface IApplicationDbContext
    {
        public MySqlConnection GetConnection();
        public string getConnectionString();
    }
}
