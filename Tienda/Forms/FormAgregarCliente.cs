using System;
using System.Linq;
using System.Windows.Forms;

namespace Tienda.Forms
{
    public partial class FormAgregarCliente : Form
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Telefono { get; private set; }

        public FormAgregarCliente()
        {
            InitializeComponent();  // No tocar esto, el diseñador lo maneja
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox
            Nombre = txtNombre.Text.Trim();
            Apellido = txtApellido.Text.Trim();
            Telefono = txtTelefono.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(Apellido) ||
                string.IsNullOrWhiteSpace(Telefono))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Validar que el teléfono solo contenga números
            if (!Telefono.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono solo debe contener caracteres numéricos.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Si todo está bien, cerrar la ventana y devolver los datos
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana sin guardar cambios
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
