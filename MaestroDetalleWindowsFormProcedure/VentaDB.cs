using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MaestroDetalleWindowsFormProcedure
{
    public class VentaDB
    {
        private string connectionString =
            "Data Source=localhost; initial Catalog=MaestroDetalleProcedimiento;" +
            "User=sa;Password=7GbE6:cX1NQG";

        public void Add(string Cliente, List<>)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente", Cliente);
                command.Parameters.AddWithValue("@fecha", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
