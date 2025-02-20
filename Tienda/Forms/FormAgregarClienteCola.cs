using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tienda.Modelos;

namespace Tienda.Forms
{
    public partial class FormAgregarClienteCola : Form
    {
        private List<Cliente> listaClientes;
        private List<Producto> listaProductos;
        private List<Tuple<string, int>> productosSeleccionados = new List<Tuple<string, int>>();
        public string ObtenerClienteSeleccionado() => cbClientes.SelectedItem.ToString();
        public List<Tuple<string, int>> ObtenerProductosSeleccionados() => productosSeleccionados;


        public FormAgregarClienteCola(List<Cliente> clientes, List<Producto> productos)
        {
            InitializeComponent();
            listaClientes = clientes;
            listaProductos = productos;
            ConfigurarDataGridView();
            this.Load += FormAgregarClienteCola_Load;
            btnAgregarProducto.Click += BtnAgregarProducto_Click;
            btnEliminarProducto.Click += BtnEliminarProducto_Click;
            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Producto", DataPropertyName = "Producto", Width = 200 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Cantidad", DataPropertyName = "Cantidad", Width = 100 });
        }

        private void FormAgregarClienteCola_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            cbClientes.Items.Clear();
            foreach (var cliente in listaClientes)
            {
                cbClientes.Items.Add(cliente.Nombre + " " + cliente.Apellido);
            }

            cbProductos.Items.Clear();
            foreach (var producto in listaProductos)
            {
                cbProductos.Items.Add(producto.Nombre);
            }

            if (cbClientes.Items.Count > 0) cbClientes.SelectedIndex = 0;
            if (cbProductos.Items.Count > 0) cbProductos.SelectedIndex = 0;
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cbProductos.SelectedItem != null && nudCantidad.Value > 0)
            {
                string producto = cbProductos.SelectedItem.ToString();
                int cantidad = (int)nudCantidad.Value;

                productosSeleccionados.Add(new Tuple<string, int>(producto, cantidad));
                dgvProductos.Rows.Add(producto, cantidad);
            }
            else
            {
                MessageBox.Show("Seleccione un producto y una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                string producto = dgvProductos.SelectedRows[0].Cells[0].Value.ToString();
                productosSeleccionados.RemoveAll(p => p.Item1 == producto);
                dgvProductos.Rows.RemoveAt(dgvProductos.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<Tuple<string, int>> ProductosSeleccionados => productosSeleccionados;
        public string ClienteSeleccionado => cbClientes.SelectedItem.ToString();

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedItem == null || productosSeleccionados.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente y al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Reducir stock de los productos seleccionados
            foreach (var item in productosSeleccionados)
            {
                Producto producto = listaProductos.Find(p => p.Nombre == item.Item1);
                if (producto != null && producto.Stock >= item.Item2)
                {
                    producto.Stock -= item.Item2;
                }
                else
                {
                    MessageBox.Show($"No hay suficiente stock para {item.Item1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
