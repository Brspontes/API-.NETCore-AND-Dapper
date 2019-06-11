using BrsPontes.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BrsPontes.Infra.StoreContext.DataContext
{
    public class SQLDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public SQLDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
