using System;
using System.Collections.Generic;

namespace DTOs
{
    public class PaginaDTO<T>
    {
        public List<T> Items { get; set; } = new();
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }
        public int TotalItems { get; set; }
        public int TotalPaginas => TamanioPagina > 0 ? (int)Math.Ceiling(TotalItems / (double)TamanioPagina) : 0;
    }
}
