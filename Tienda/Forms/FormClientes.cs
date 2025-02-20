using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tienda.Modelos;

namespace Tienda.Forms
{
    public partial class FormClientes : Form
    {
        private List<Cliente> listaClientes;
        private int idCounter = 1;

        public FormClientes(List<Cliente> clientes)
        {
            InitializeComponent();
            listaClientes = clientes;
            CargarClientes();
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

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvClientes.SelectedRows[0].Index;
                if (selectedIndex < 0 || selectedIndex >= listaClientes.Count)
                {
                    dgvClientes.ClearSelection();
                }
            }
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
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int clienteIdSeleccionado = (int)dgvClientes.SelectedRows[0].Cells["ID"].Value;
                Cliente clienteAEliminar = listaClientes.FirstOrDefault(c => c.Id == clienteIdSeleccionado);

                if (clienteAEliminar != null)
                {
                    DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de que deseas eliminar al cliente con ID {clienteIdSeleccionado}?",
                                                                "Confirmar Eliminación",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        listaClientes.Remove(clienteAEliminar);
                        CargarClientes();
                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente válido para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
