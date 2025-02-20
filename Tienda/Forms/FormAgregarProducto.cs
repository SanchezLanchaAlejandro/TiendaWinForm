using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.Modelos;

namespace Tienda.Forms
{
    public partial class FormAgregarProducto : Form
    {
        public string Nombre { get; private set; }
        public int Cantidad { get; private set; }
        private List<Producto> productosDisponibles;

        public FormAgregarProducto(List<Producto> productos)
        {
            InitializeComponent();
            productosDisponibles = productos;
            CargarProductos();
        }

        private void CargarProductos()
        {
            cmbProducto.DataSource = productosDisponibles;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Nombre";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Nombre = cmbProducto.SelectedValue.ToString();
            Cantidad = (int)numCantidad.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
