using System;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_DE_CALIFICACIONES_DE_ESTUDIANTES
{
    public partial class FormReporte : Form
    {
        private string[] nombres;
        private double[,] calificaciones;
        private int numAlumnos;
        private int numMaterias;

        // Arreglos unidimensionales para los promedios
        private double[] promedioAlumno;
        private double[] promedioMateria;

        private DataGridView dgvReporte;
        private Label lblTitulo;
        private Button btnCerrar;

        public FormReporte (string[] nombres, double[,] calificaciones, int numAlumnos, int numMaterias)
        {
            this.nombres = nombres;
            this.calificaciones = calificaciones;
            this.numAlumnos = numAlumnos;
            this.numMaterias = numMaterias;

            promedioAlumno = new double[numAlumnos];
            promedioMateria = new double[numMaterias];

            InitializeComponent();
            CalcularPromedios();
            LlenarTabla();
        }

        private void InitializeComponent()
        {
            this.Text = "Reporte de Calificaciones";
            this.Width = 700;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitulo = new Label()
            {
                Text = "Reporte de Calificaciones",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };

            dgvReporte = new DataGridView()
            {
                Location = new Point(20, 50),
                Width = 650,
                Height = 380,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnCerrar = new Button()
            {
                Text = "Cerrar",
                Location = new Point(560, 440),
                Width = 110,
                Height = 35
            };
            btnCerrar.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitulo);
            this.Controls.Add(dgvReporte);
            this.Controls.Add(btnCerrar);
        }

        private void CalcularPromedios()
        {
            // Promedio por alumno (promedio de cada fila)
            for (int i = 0; i < numAlumnos; i++)
            {
                double suma = 0;
                for (int j = 0; j < numMaterias; j++)
                {
                    suma += calificaciones[i, j];
                }
                promedioAlumno[i] = suma / numMaterias;
            }

            // Promedio por materia (promedio de cada columna)
            for (int j = 0; j < numMaterias; j++)
            {
                double suma = 0;
                for (int i = 0; i < numAlumnos; i++)
                {
                    suma += calificaciones[i, j];
                }
                promedioMateria[j] = suma / numAlumnos;
            }
        }

        private void LlenarTabla()
        {
            dgvReporte.Columns.Add("colAlumno", "Alumno");

            for (int j = 0; j < numMaterias; j++)
            {
                dgvReporte.Columns.Add($"colMateria{j}", $"Materia {j + 1}");
            }

            dgvReporte.Columns.Add("colPromedio", "Promedio");

            // Filas de alumnos
            for (int i = 0; i < numAlumnos; i++)
            {
                object[] fila = new object[numMaterias + 2];
                fila[0] = nombres[i];

                for (int j = 0; j < numMaterias; j++)
                {
                    fila[j + 1] = calificaciones[i, j].ToString("0.00");
                }

                fila[numMaterias + 1] = promedioAlumno[i].ToString("0.00");

                dgvReporte.Rows.Add(fila);
            }

            // Fila de promedios por materia
            object[] filaPromedios = new object[numMaterias + 2];
            filaPromedios[0] = "Promedio por materia";

            for (int j = 0; j < numMaterias; j++)
            {
                filaPromedios[j + 1] = promedioMateria[j].ToString("0.00");
            }

            filaPromedios[numMaterias + 1] = "";

            int indiceFila = dgvReporte.Rows.Add(filaPromedios);
            dgvReporte.Rows[indiceFila].DefaultCellStyle.Font = new Font(dgvReporte.Font, FontStyle.Bold);
            dgvReporte.Rows[indiceFila].DefaultCellStyle.BackColor = Color.LightGray;
        }
    }
}