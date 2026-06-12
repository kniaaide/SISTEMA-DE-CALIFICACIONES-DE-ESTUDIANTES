using System.Drawing;

namespace SistemaCalificaciones
{
    public static class Paleta
    {
        public static readonly Color Fondo = ColorTranslator.FromHtml("#F4F6F9");
        public static readonly Color Tarjeta = Color.White;
        public static readonly Color Primario = ColorTranslator.FromHtml("#2E75B6");
        public static readonly Color PrimarioOscuro = ColorTranslator.FromHtml("#1F4E79");
        public static readonly Color Acento = ColorTranslator.FromHtml("#5B9BD5");
        public static readonly Color Exito = ColorTranslator.FromHtml("#5DA85B");
        public static readonly Color Texto = ColorTranslator.FromHtml("#33414E");
        public static readonly Color TextoClaro = Color.White;
        public static readonly Color Borde = ColorTranslator.FromHtml("#D9E2EC");
        public static readonly Color FilaAlterna = ColorTranslator.FromHtml("#EAF1FA");

        public static readonly Font FontTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
        public static readonly Font FontSubtitulo = new Font("Segoe UI", 10, FontStyle.Regular);
        public static readonly Font FontTexto = new Font("Segoe UI", 10, FontStyle.Regular);
        public static readonly Font FontEtiqueta = new Font("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font FontBoton = new Font("Segoe UI", 10, FontStyle.Bold);
    }
}