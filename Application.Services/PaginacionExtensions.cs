using Domain.Model;
using DTOs;
using System;
using System.Linq;

namespace Application.Services
{
    public static class PaginacionExtensions
    {
        public static PaginaDTO<TDto> ADto<T, TDto>(this Pagina<T> pagina, Func<T, TDto> mapear)
        {
            return new PaginaDTO<TDto>
            {
                Items = pagina.Items.Select(mapear).ToList(),
                NumeroPagina = pagina.NumeroPagina,
                TamanioPagina = pagina.TamanioPagina,
                TotalItems = pagina.TotalItems
            };
        }
    }
}
