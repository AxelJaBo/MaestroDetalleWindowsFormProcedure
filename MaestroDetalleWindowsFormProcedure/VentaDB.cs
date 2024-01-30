using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MaestroDetalleWindowsFormProcedure
{
    public class VentaDB
    {
        private string connectionString =
            "Data Source=localhost; initial Catalog=MaestroDetalleProcedimiento;" +
            "User=sa;Password=7GbE6:cX1NQG";

        public void Add(string Cliente, List<Concepto> lst)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Precio");

            int i = 1;
            foreach(var oElement in lst)
            {
                dt.Rows.Add(i, oElement.Cantidad, oElement.Nombre, oElement.Precio);
                i++;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spGuardaVenta", connection);
                var parametroLista = new SqlParameter("@lstConceptos", SqlDbType.Structured);
                parametroLista.TypeName = "dbo.Detail";
                parametroLista.Value = dt;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(parametroLista);
                command.Parameters.AddWithValue("@cliente", Cliente);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
