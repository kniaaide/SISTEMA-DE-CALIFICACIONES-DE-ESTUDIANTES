using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaCalificaciones
{
    public class FormCaptura : Form
    {
        private int numAlumnos;
        private int numMaterias;
        private int indiceActual;

        // Arreglo unidimensional: nombres de los alumnos
        private string[] nombres;

        // Arreglo multidimensional: calificaciones[alumno, materia]
        private double[,] calificaciones;

        private Label lblTitulo;
        private Label lblProgreso;
        private Label lblNombre;
        private TextBox txtNombre;

        private Label[] lblMaterias;
        private TextBox[] txtCalificaciones;

        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnFinalizar;

        public FormCaptura(int alumnos, int materias)
        {
            numAlumnos = alumnos;
            numMaterias = materias;
            indiceActual = 0;

            nombres = new string[numAlumnos];
            calificaciones = new double[numAlumnos, numMaterias];

            InitializeComponent();
            MostrarAlumno(indiceActual);
        }

        private void InitializeComponent()
        {
            this.Text = "Captura de Calificaciones";
            this.Width = 450;
            this.Height = 130 + (numMaterias * 35) + 80;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTitulo = new Label()
            {
                Text = "Captura de Datos",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 15)
            };

            lblProgreso = new Label()
            {
                Text = "",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                Location = new Point(30, 45)
            };

            lblNombre = new Label()
            {
                Text = "Nombre del alumno:",
                AutoSize = true,
                Location = new Point(30, 80)
            };

            txtNombre = new TextBox()
            {
                Location = new Point(180, 77),
                Width = 220
            };

            lblMaterias = new Label[numMaterias];
            txtCalificaciones = new TextBox[numMaterias];

            int posY = 120;
            for (int i = 0; i < numMaterias; i++)
            {
                lblMaterias[i] = new Label()
                {
                    Text = $"Materia {i + 1}:",
                    AutoSize = true,
                    Location = new Point(30, posY)
                };

                txtCalificaciones[i] = new TextBox()
                {
                    Location = new Point(180, posY - 3),
                    Width = 100
                };

                this.Controls.Add(lblMaterias[i]);
                this.Controls.Add(txtCalificaciones[i]);

                posY += 35;
            }

            btnAnterior = new Button()
            {
                Text = "Anterior",
                Location = new Point(30, posY + 15),
                Width = 100,
                Height = 35
            };
            btnAnterior.Click += BtnAnterior_Click;

            btnSiguiente = new Button()
            {
                Text = "Siguiente",
                Location = new Point(160, posY + 15),
                Width = 100,
                Height = 35
            };
            btnSiguiente.Click += BtnSiguiente_Click;

            btnFinalizar = new Button()
            {
                Text = "Finalizar",
                Location = new Point(290, posY + 15),
                Width = 100,
                Height = 35
            };
            btnFinalizar.Click += BtnFinalizar_Click;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblProgreso);
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(btnAnterior);
            this.Controls.Add(btnSiguiente);
            this.Controls.Add(btnFinalizar);
        }

        private void MostrarAlumno(int indice)
        {
            lblProgreso.Text = $"Alumno {indice + 1} de {numAlumnos}";

            txtNombre.Text = nombres[indice] ?? "";

            for (int i = 0; i < numMaterias; i++)
            {
                double valor = calificaciones[indice, i];
                txtCalificaciones[i].Text = valor == 0 ? "" : valor.ToString();
            }

            btnAnterior.Enabled = indice > 0;
            btnSiguiente.Enabled = indice < numAlumnos - 1;
        }

        private bool GuardarAlumno(int indice)
        {
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debes escribir el nombre del alumno.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            double[] notasTemp = new double[numMaterias];

            for (int i = 0; i < numMaterias; i++)
            {
                string texto = txtCalificaciones[i].Text.Trim();

                if (string.IsNullOrEmpty(texto))
                {
                    MessageBox.Show($"Falta la calificación de Materia {i + 1}.", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCalificaciones[i].Focus();
                    return false;
                }

                if (!double.TryParse(texto, out double valor) || valor < 0 || valor > 10)
                {
                    MessageBox.Show($"La calificación de Materia {i + 1} debe ser un número entre 0 y 10.",
                        "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCalificaciones[i].Focus();
                    return false;
                }

                notasTemp[i] = valor;
            }

            nombres[indice] = nombre;
            for (int i = 0; i < numMaterias; i++)
            {
                calificaciones[indice, i] = notasTemp[i];
            }

            return true;
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (!GuardarAlumno(indiceActual)) return;

            if (indiceActual > 0)
            {
                indiceActual--;
                MostrarAlumno(indiceActual);
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (!GuardarAlumno(indiceActual)) return;

            if (indiceActual < numAlumnos - 1)
            {
                indiceActual++;
                MostrarAlumno(indiceActual);
            }
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (!GuardarAlumno(indiceActual)) return;

            FormReporte formReporte = new FormReporte(nombres, calificaciones, numAlumnos, numMaterias);
            this.Hide();
            formReporte.FormClosed += (s, args) => this.Close();
            formReporte.Show();
        }
    }
}