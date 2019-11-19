using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace clientMessaging
{
    class connection
    {

        public static SqlConnection startConn()
        {

            SqlConnection conn;
            string connectionString = "Data Source =tolmount.abertay.ac.uk; Initial Catalog =sql1704807; User ID = sql1704807; Password =HwaXA9jPKd";
            conn = new SqlConnection(connectionString);
            return conn;


        }

    }
}
