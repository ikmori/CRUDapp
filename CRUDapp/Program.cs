using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimpleCrudApp
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class MainForm : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private int nextId = 1;

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
            RefreshGrid();
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
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = new Button { Text = "Actualizar", Location = new Point(110, 90), Width = 80 };
            btnUpdate.Click += BtnUpdate_Click;
            
            btnDelete = new Button { Text = "Eliminar", Location = new Point(200, 90), Width = 80 };
            btnDelete.Click += BtnDelete_Click;
            
            grid = new DataGridView
            {
                Location = new Point(20, 140),
                Size = new Size(540, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };

            
            
            grid.SelectionChanged += Grid_SelectionChanged;



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

        private void ClearForm()
        {
            txtTitle.Clear();
            txtDesc.Clear();
            chkCompleted.Checked = false;
        }




        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) return;

            var task = new TaskItem
            {
                Id = nextId++,
                Title = txtTitle.Text,
                Description = txtDesc.Text,
                IsCompleted = chkCompleted.Checked
            };

            tasks.Add(task);
            RefreshGrid();
            ClearForm();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;
            int id = (int)grid.SelectedRows[0].Cells["Id"].Value;
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Title = txtTitle.Text;
                task.Description = txtDesc.Text;
                task.IsCompleted = chkCompleted.Checked;
                RefreshGrid();
                ClearForm();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) return;
            int id = (int)grid.SelectedRows[0].Cells["Id"].Value;
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                RefreshGrid();
                ClearForm();
            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                int id = (int)grid.SelectedRows[0].Cells["Id"].Value;
                var task = tasks.FirstOrDefault(t => t.Id == id);
                if (task != null)
                {
                    txtTitle.Text = task.Title;
                    txtDesc.Text = task.Description;
                    chkCompleted.Checked = task.IsCompleted;
                }
            }
        }

        private void RefreshGrid()
        {
            grid.DataSource = null;
            grid.DataSource = tasks.ToList();
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