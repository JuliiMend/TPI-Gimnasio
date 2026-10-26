using DTOs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    // Barra "Anterior / Página X de Y / Siguiente" reutilizable para las grillas paginadas.
    // El formulario pide la página NumeroPagina, llama a Actualizar con el resultado
    // y vuelve a cargar cuando se dispara PaginaCambiada.
    public class Paginador : UserControl
    {
        private readonly Button btnAnterior;
        private readonly Button btnSiguiente;
        private readonly Label lblInfo;

        public int NumeroPagina { get; private set; } = 1;
        public int TamanioPagina { get; set; } = 10;

        public event EventHandler? PaginaCambiada;

        private int totalPaginas;

        public Paginador()
        {
            btnAnterior = new Button
            {
                Text = "< Anterior",
                Location = new Point(0, 0),
                Size = new Size(90, 28),
                Enabled = false
            };

            lblInfo = new Label
            {
                Location = new Point(96, 0),
                Size = new Size(230, 28),
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnSiguiente = new Button
            {
                Text = "Siguiente >",
                Location = new Point(332, 0),
                Size = new Size(90, 28),
                Enabled = false
            };

            btnAnterior.Click += (s, e) => IrA(NumeroPagina - 1);
            btnSiguiente.Click += (s, e) => IrA(NumeroPagina + 1);

            Controls.Add(btnAnterior);
            Controls.Add(lblInfo);
            Controls.Add(btnSiguiente);

            Size = new Size(422, 28);
        }

        // Vuelve a la primera página, por ejemplo al cambiar un filtro
        public void Reiniciar()
        {
            NumeroPagina = 1;
        }

        public void Actualizar<T>(PaginaDTO<T> pagina)
        {
            // La API puede corregir el número (por ejemplo, si se borró el último registro de la última página)
            NumeroPagina = Math.Max(1, pagina.NumeroPagina);
            totalPaginas = pagina.TotalPaginas;

            lblInfo.Text = pagina.TotalItems == 0
                ? "Sin registros"
                : $"Página {NumeroPagina} de {totalPaginas} ({pagina.TotalItems} registros)";

            btnAnterior.Enabled = NumeroPagina > 1;
            btnSiguiente.Enabled = NumeroPagina < totalPaginas;
        }

        private void IrA(int numero)
        {
            if (numero < 1 || numero > totalPaginas)
            {
                return;
            }

            NumeroPagina = numero;
            PaginaCambiada?.Invoke(this, EventArgs.Empty);
        }
    }
}
