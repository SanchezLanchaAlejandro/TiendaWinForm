using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tienda.Modelos;

namespace Tienda.Forms
{
    public partial class FormClientes : Form
    {
        private List<Cliente> listaClientes = new List<Cliente>();

        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarClientes();
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.Columns.Clear();
            dgvClientes.AutoGenerateColumns = false;

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 100 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Apellido", DataPropertyName = "Apellido", Width = 100 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Teléfono", DataPropertyName = "Telefono", Width = 100 });
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormAgregarCliente formAgregar = new FormAgregarCliente();
            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                Cliente nuevoCliente = new Cliente()
                {
                    Id = listaClientes.Count + 1,
                    Nombre = formAgregar.Nombre,
                    Apellido = formAgregar.Apellido,
                    Telefono = formAgregar.Telefono
                };

                listaClientes.Add(nuevoCliente);
                CargarClientes();
            }
        }

        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            FormBorrarCliente formBorrar = new FormBorrarCliente();
            if (formBorrar.ShowDialog() == DialogResult.OK)
            {
                Cliente clienteAEliminar = listaClientes.FirstOrDefault(c => c.Id == formBorrar.ClienteId);
                if (clienteAEliminar != null)
                {
                    listaClientes.Remove(clienteAEliminar);
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("No se encontró un cliente con el ID ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormClientes_Load_1(object sender, EventArgs e)
        {

        }
    }
}
