using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimpleCrudApp
{

    public class MainForm : Form
    {
        private DataGridView grid;
        private TextBox txtTitle;
        private TextBox txtDesc;
        private CheckBox chkCompleted;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblTitle;
        private Label lblDesc;
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(600, 500);
            this.Text = "Gestor de tareas ";

            lblTitle = new Label { Text = "Titulo:", Location = new Point(20, 20), AutoSize = true };
            txtTitle = new TextBox { Location = new Point(20, 45), Width = 200 };

            lblDesc = new Label { Text = "Descripcion:", Location = new Point(240, 20), AutoSize = true };
            txtDesc = new TextBox { Location = new Point(240, 45), Width = 200 };

            chkCompleted = new CheckBox { Text = "Completada", Location = new Point(460, 45) };

            btnAdd = new Button { Text = "Agregar", Location = new Point(20, 90), Width = 80 };
            btnUpdate = new Button { Text = "Actualizar", Location = new Point(110, 90), Width = 80 };
            btnDelete = new Button { Text = "Eliminar", Location = new Point(200, 90), Width = 80 };

            grid = new DataGridView
            {
                Location = new Point(20, 140),
                Size = new Size(540, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblDesc);
            this.Controls.Add(txtDesc);
            this.Controls.Add(chkCompleted);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(grid);

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}