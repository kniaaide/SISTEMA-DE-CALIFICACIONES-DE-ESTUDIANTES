using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaCalificaciones
{
    public class Form1 : Form
    {
        private Label lblTitulo;
        private Label lblAlumnos;
        private NumericUpDown numAlumnos;
        private Label lblMaterias;
        private NumericUpDown numMaterias;
        private Button btnContinuar;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sistema de Calificaciones - Configuración";
            this.Width = 400;
            this.Height = 250;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTitulo = new Label()
            {
                Text = "Sistema de Calificaciones de Estudiantes",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 20)
            };

            lblAlumnos = new Label()
            {
                Text = "Número de alumnos:",
                AutoSize = true,
                Location = new Point(30, 70)
            };

            numAlumnos = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = 50,
                Value = 5,
                Location = new Point(200, 68),
                Width = 80
            };

            lblMaterias = new Label()
            {
                Text = "Número de materias:",
                AutoSize = true,
                Location = new Point(30, 110)
            };

            numMaterias = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = 10,
                Value = 3,
                Location = new Point(200, 108),
                Width = 80
            };

            btnContinuar = new Button()
            {
                Text = "Continuar",
                Location = new Point(140, 160),
                Width = 100,
                Height = 35
            };
            btnContinuar.Click += BtnContinuar_Click;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblAlumnos);
            this.Controls.Add(numAlumnos);
            this.Controls.Add(lblMaterias);
            this.Controls.Add(numMaterias);
            this.Controls.Add(btnContinuar);
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            int alumnos = (int)numAlumnos.Value;
            int materias = (int)numMaterias.Value;

            FormCaptura formCaptura = new FormCaptura(alumnos, materias);
            this.Hide();
            formCaptura.FormClosed += (s, args) => this.Close();
            formCaptura.Show();
        }
    }
}