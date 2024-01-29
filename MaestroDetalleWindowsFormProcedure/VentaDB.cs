using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroDetalleWindowsFormProcedure
{
    public class VentaDB
    {
        private string connectionString =
            "Data Source=localhost; initial Catalog=MaestroDetalleProcedimiento;" +
            "User=DESKTOP-KA53HTR;Password=";

        public void Add(string Cliente)
        {
            string query = "insert into venta(cliente) values(@cliente)";
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente", Cliente);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
