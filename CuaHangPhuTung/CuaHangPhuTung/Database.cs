using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CuaHangPhuTung
{
    class Database
    {
        private SqlConnection connect;
        private SqlDataAdapter adt;

        private static Database singleton = null;

        public static Database Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new Database();
                }
                return singleton;
            }
        }

        private Database()
        {
            string stringConnect = @"Data Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True";
            this.connect = new SqlConnection(stringConnect);
        }

        public DataTable LoadData(string sql)
        {
            DataTable table = new DataTable();
            adt = new SqlDataAdapter(sql, this.connect);
            adt.Fill(table);
            return table;
        }

    }
}
