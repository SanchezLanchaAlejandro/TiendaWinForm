using System;
using System.Windows.Forms;

namespace Tienda.Forms
{
    public partial class FormPrincipal : Form
    {
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VerClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VerProductosToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvColaPago;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnAnadirCola;
        private System.Windows.Forms.PictureBox pbBanner;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.dgvColaPago = new System.Windows.Forms.DataGridView();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnAnadirCola = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaPago)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.productosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 24);
            this.menuStrip1.TabIndex = 4;
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SalirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // SalirToolStripMenuItem
            // 
            this.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem";
            this.SalirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.SalirToolStripMenuItem.Text = "Salir";
            this.SalirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // VerClientesToolStripMenuItem
            // 
            this.VerClientesToolStripMenuItem.Name = "VerClientesToolStripMenuItem";
            this.VerClientesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.VerClientesToolStripMenuItem.Text = "Ver Clientes";
            this.VerClientesToolStripMenuItem.Click += new System.EventHandler(this.VerClientesToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerProductosToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // VerProductosToolStripMenuItem
            // 
            this.VerProductosToolStripMenuItem.Name = "VerProductosToolStripMenuItem";
            this.VerProductosToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.VerProductosToolStripMenuItem.Text = "Ver Productos";
            this.VerProductosToolStripMenuItem.Click += new System.EventHandler(this.VerProductosToolStripMenuItem_Click_1);
            // 
            // pbBanner
            // 
            this.pbBanner.Image = ((System.Drawing.Image)(resources.GetObject("pbBanner.Image")));
            this.pbBanner.Location = new System.Drawing.Point(54, 30);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(756, 149);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            // 
            // dgvColaPago
            // 
            this.dgvColaPago.AllowUserToAddRows = false;
            this.dgvColaPago.AllowUserToDeleteRows = false;
            this.dgvColaPago.Location = new System.Drawing.Point(178, 196);
            this.dgvColaPago.Name = "dgvColaPago";
            this.dgvColaPago.ReadOnly = true;
            this.dgvColaPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColaPago.Size = new System.Drawing.Size(500, 250);
            this.dgvColaPago.TabIndex = 1;
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(275, 470);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(100, 30);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click_1);
            // 
            // btnAnadirCola
            // 
            this.btnAnadirCola.Location = new System.Drawing.Point(473, 470);
            this.btnAnadirCola.Name = "btnAnadirCola";
            this.btnAnadirCola.Size = new System.Drawing.Size(150, 30);
            this.btnAnadirCola.TabIndex = 3;
            this.btnAnadirCola.Text = "Añadir Cliente a la Cola";
            this.btnAnadirCola.UseVisualStyleBackColor = true;
            this.btnAnadirCola.Click += new System.EventHandler(this.btnAnadirCola_Click);
            // 
            // FormPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(864, 520);
            this.Controls.Add(this.pbBanner);
            this.Controls.Add(this.dgvColaPago);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnAnadirCola);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tienda";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
