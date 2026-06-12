using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaCalificaciones
{
    public class Form1 : Form
    {
        private Panel pnlTarjeta;
        private Label lblTitulo;
        private Label lblSubtitulo;
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
            this.Text = "Sistema de Calificaciones";
            this.ClientSize = new Size(420, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Paleta.Fondo;
            this.Font = Paleta.FontTexto;

            pnlTarjeta = new Panel()
            {
                BackColor = Paleta.Tarjeta,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(30, 30),
                Size = new Size(360, 260)
            };

            lblTitulo = new Label()
            {
                Text = "Sistema de Calificaciones",
                Font = Paleta.FontTitulo,
                ForeColor = Paleta.PrimarioOscuro,
                AutoSize = true,
                Location = new Point(25, 25)
            };

            lblSubtitulo = new Label()
            {
                Text = "Configuración inicial del grupo",
                Font = Paleta.FontSubtitulo,
                ForeColor = Paleta.Texto,
                AutoSize = true,
                Location = new Point(25, 58)
            };

            lblAlumnos = new Label()
            {
                Text = "Número de alumnos:",
                Font = Paleta.FontEtiqueta,
                ForeColor = Paleta.Texto,
                AutoSize = true,
                Location = new Point(25, 110)
            };

            numAlumnos = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = 50,
                Value = 5,
                Location = new Point(220, 107),
                Width = 100,
                Height = 28,
                Font = Paleta.FontTexto,
                TextAlign = HorizontalAlignment.Center
            };

            lblMaterias = new Label()
            {
                Text = "Número de materias:",
                Font = Paleta.FontEtiqueta,
                ForeColor = Paleta.Texto,
                AutoSize = true,
                Location = new Point(25, 155)
            };

            numMaterias = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = 10,
                Value = 3,
                Location = new Point(220, 152),
                Width = 100,
                Height = 28,
                Font = Paleta.FontTexto,
                TextAlign = HorizontalAlignment.Center
            };

            btnContinuar = new Button()
            {
                Text = "Continuar",
                Location = new Point(105, 200),
                Size = new Size(150, 42),
                Font = Paleta.FontBoton,
                BackColor = Paleta.Primario,
                ForeColor = Paleta.TextoClaro,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnContinuar.FlatAppearance.BorderSize = 0;
            btnContinuar.FlatAppearance.MouseOverBackColor = Paleta.PrimarioOscuro;
            btnContinuar.Click += BtnContinuar_Click;

            pnlTarjeta.Controls.Add(lblTitulo);
            pnlTarjeta.Controls.Add(lblSubtitulo);
            pnlTarjeta.Controls.Add(lblAlumnos);
            pnlTarjeta.Controls.Add(numAlumnos);
            pnlTarjeta.Controls.Add(lblMaterias);
            pnlTarjeta.Controls.Add(numMaterias);
            pnlTarjeta.Controls.Add(btnContinuar);

            this.Controls.Add(pnlTarjeta);
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