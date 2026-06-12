using SISTEMA_DE_CALIFICACIONES_DE_ESTUDIANTES;
using System;
using System.Windows.Forms;

namespace SistemaCalificaciones
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}