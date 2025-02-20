using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tienda.Modelos;

namespace Tienda.Forms
{
    public partial class FormPrincipal : Form
    {
        public List<Cliente> ListaClientes { get; private set; } = new List<Cliente>();
        public List<Producto> ListaProductos { get; private set; } = new List<Producto>();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VerClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes(ListaClientes);
            formClientes.FormClosed += (s, args) => MostrarListaClientesEnConsola();
            formClientes.Show();
        }

        private void VerProductosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos(ListaProductos);
            formProductos.FormClosed += (s, args) => MostrarListaProductosEnConsola();
            formProductos.Show();
        }

        private void ConfigurarDataGridView()
        {
            dgvColaPago.Columns.Clear();
            dgvColaPago.AutoGenerateColumns = false;
            dgvColaPago.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Cliente", DataPropertyName = "Cliente", Width = 150 });
            dgvColaPago.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Producto", DataPropertyName = "Producto", Width = 150 });
            dgvColaPago.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Cantidad", DataPropertyName = "Cantidad", Width = 100 });
        }

        private void btnAnadirCola_Click(object sender, EventArgs e)
        {
            FormAgregarClienteCola formAgregarCola = new FormAgregarClienteCola(ListaClientes, ListaProductos);
            if (formAgregarCola.ShowDialog() == DialogResult.OK)
            {
                string cliente = formAgregarCola.ObtenerClienteSeleccionado();
                List<Tuple<string, int>> productos = formAgregarCola.ObtenerProductosSeleccionados();

                foreach (var producto in productos)
                {
                    dgvColaPago.Rows.Add(cliente, producto.Item1, producto.Item2);
                }
            }
        }

        private void MostrarListaClientesEnConsola()
        {
            Console.WriteLine("Lista de clientes en FormPrincipal:");
            foreach (var cliente in ListaClientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Apellido: {cliente.Apellido}, Teléfono: {cliente.Telefono}");
            }
        }

        private void MostrarListaProductosEnConsola()
        {
            Console.WriteLine("Lista de productos en FormPrincipal:");
            foreach (var producto in ListaProductos)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.Stock}");
            }
        }

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            if (dgvColaPago.Rows.Count > 0)
            {
                dgvColaPago.Rows.RemoveAt(0);
                MessageBox.Show("El cliente ha realizado su pago y ha salido de la cola.", "Pago Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay clientes en la cola de pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
