using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaestroDetalleWindowsFormProcedure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Cantidad = txtCantidad.Text;
            string Nombre = txtNombre.Text;
            string Precio = txtPrecio.Text;
            dgvConceptos.Rows.Add(new object[]
            {
                Cantidad, Nombre, Precio, "Eliminar"
            });

            txtCantidad.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<Concepto> lst = new List<Concepto>();

                // Llenado de elementos detalles
                foreach(DataGridViewRow dr in dgvConceptos.Rows)
                {
                    Concepto oConcepto = new Concepto();
                    oConcepto.Cantidad = int.Parse(dr.Cells[0].Value.ToString());
                    oConcepto.Nombre = dr.Cells[1].Value.ToString();
                    oConcepto.Precio = decimal.Parse(dr.Cells[2].Value.ToString());
                    lst.Add(oConcepto);
                }

                VentaDB oVenta = new VentaDB();
                oVenta.Add(txtCliente.Text, lst);
                MessageBox.Show("Venta realizada con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvConceptos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0 || e.ColumnIndex != dgvConceptos.Columns["Op"].Index)
                return;

            dgvConceptos.Rows.RemoveAt(e.RowIndex);
            
        }
    }
}
