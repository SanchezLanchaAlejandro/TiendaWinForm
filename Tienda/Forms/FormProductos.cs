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
    public partial class FormProductos : Form
    {
        private List<Producto> listaProductos;
        private readonly List<Producto> productosPredefinidos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Pan", Precio = 1.00m, Stock = 50 },
            new Producto { Id = 2, Nombre = "Leche", Precio = 1.20m, Stock = 30 },
            new Producto { Id = 3, Nombre = "Azúcar", Precio = 2.50m, Stock = 20 },
            new Producto { Id = 4, Nombre = "Lechuga", Precio = 0.80m, Stock = 40 },
            new Producto { Id = 5, Nombre = "Tomate", Precio = 1.50m, Stock = 25 },
            new Producto { Id = 6, Nombre = "Agua", Precio = 0.60m, Stock = 100 }
        };

        public FormProductos(List<Producto> productos)
        {
            InitializeComponent();
            listaProductos = productos;
            CargarProductosPredefinidos();
            CargarProductos();
        }

        private void CargarProductosPredefinidos()
        {
            foreach (var producto in productosPredefinidos)
            {
                if (!listaProductos.Any(p => p.Nombre == producto.Nombre))
                {
                    listaProductos.Add(producto);
                }
            }
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarProductos();
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "Id", Width = 50 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Precio", DataPropertyName = "Precio", Width = 100 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Stock", DataPropertyName = "Stock", Width = 80 });
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaProductos;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormAgregarProducto formAgregar = new FormAgregarProducto(productosPredefinidos);
            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                Producto productoSeleccionado = productosPredefinidos.FirstOrDefault(p => p.Nombre == formAgregar.Nombre);
                if (productoSeleccionado != null && !listaProductos.Any(p => p.Nombre == productoSeleccionado.Nombre))
                {
                    listaProductos.Add(productoSeleccionado);
                    CargarProductos();
                }
            }
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int productoIdSeleccionado = (int)dgvProductos.SelectedRows[0].Cells["ID"].Value;
                Producto productoAEliminar = listaProductos.FirstOrDefault(p => p.Id == productoIdSeleccionado);

                if (productoAEliminar != null)
                {
                    DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de que deseas eliminar el producto con ID {productoIdSeleccionado}?",
                                                                "Confirmar Eliminación",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        listaProductos.Remove(productoAEliminar);
                        CargarProductos();
                        MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el producto en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto válido para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
