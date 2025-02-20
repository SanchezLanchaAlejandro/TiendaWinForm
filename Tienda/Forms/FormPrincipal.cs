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
            // Código para ejecutar al cargar FormPrincipal
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

        private void VerProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos(ListaProductos);
            formProductos.FormClosed += (s, args) => MostrarListaProductosEnConsola();
            formProductos.Show();
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
    }
}

