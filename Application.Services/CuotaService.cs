using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CuotaService : ICuotaService
    {
        private readonly ICuotaRepository _cuotaRepository;
        private readonly ISocioRepository _socioRepository;

        public CuotaService(ICuotaRepository cuotaRepository, ISocioRepository socioRepository)
        {
            _cuotaRepository = cuotaRepository;
            _socioRepository = socioRepository;
        }

        public async Task<List<CuotaMostrarDTO>> ObtenerTodosAsync(int? idSocio = null)
        {
            var cuotas = await _cuotaRepository.ObtenerTodosAsync(idSocio);

            return cuotas.Select(MapearAMostrar).ToList();
        }

        public async Task<PaginaDTO<CuotaMostrarDTO>> ObtenerPaginadoAsync(int? idSocio, int? mes, int? anio, int numeroPagina, int tamanioPagina)
        {
            var pagina = await _cuotaRepository.ObtenerPaginadoAsync(idSocio, mes, anio, numeroPagina, tamanioPagina);

            return pagina.ADto(MapearAMostrar);
        }

        private static CuotaMostrarDTO MapearAMostrar(Cuota c)
        {
            return new CuotaMostrarDTO
            {
                CuotaId = c.CuotaId,
                SocioId = c.SocioId,
                MesAnio = c.MesAnio,
                FechaPago = c.FechaPago,
                Valor = c.Valor,
                SocioNombre = c.Socio != null ? $"{c.Socio.Nombre} {c.Socio.Apellido}" : string.Empty,
                Detalles = c.Detalles.Select(d => new DetalleCuotaMostrarDTO
                {
                    DetalleCuotaId = d.DetalleCuotaId,
                    CuotaId = d.CuotaId,
                    Concepto = d.Concepto,
                    Subtotal = d.Subtotal,
                    Monto = d.Monto
                }).ToList()
            };
        }

        public async Task<CuotaMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var c = await _cuotaRepository.ObtenerPorIdAsync(id);

            return c == null ? null : MapearAMostrar(c);
        }

        public async Task<int> AgregarAsync(CuotaCreaActualizaDTO cuotaDto)
        {
            var cuota = new Cuota
            {
                SocioId = cuotaDto.SocioId,
                MesAnio = cuotaDto.MesAnio,
                FechaPago = cuotaDto.FechaPago,
                Valor = cuotaDto.Detalles.Sum(d => d.Monto),
                Detalles = cuotaDto.Detalles.Select(d => new DetalleCuota
                {
                    Concepto = d.Concepto?.Trim() ?? string.Empty,
                    Subtotal = d.Subtotal,
                    Monto = d.Monto
                }).ToList()
            };

            await ValidarAsync(cuota);

            await _cuotaRepository.AgregarAsync(cuota);
            return cuota.CuotaId;
        }

        public async Task ActualizarAsync(int id, CuotaCreaActualizaDTO cuotaDto)
        {
            var cuotaActualizada = new Cuota
            {
                CuotaId = id,
                SocioId = cuotaDto.SocioId,
                MesAnio = cuotaDto.MesAnio,
                FechaPago = cuotaDto.FechaPago,
                Valor = cuotaDto.Detalles.Sum(d => d.Monto),
                Detalles = cuotaDto.Detalles.Select(d => new DetalleCuota
                {
                    DetalleCuotaId = d.DetalleCuotaId, 
                    Concepto = d.Concepto?.Trim() ?? string.Empty,
                    Subtotal = d.Subtotal,
                    Monto = d.Monto
                }).ToList()
            };

            _ = await _cuotaRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException("La cuota no existe.");

            await ValidarAsync(cuotaActualizada);

            await _cuotaRepository.ActualizarAsync(cuotaActualizada);
        }

        private async Task ValidarAsync(Cuota cuota)
        {
            cuota.Validar();

            var socio = await _socioRepository.ObtenerPorIdAsync(cuota.SocioId)
                ?? throw new ReglaNegocioException("El socio no existe.");

            // El período se compara como AAAAMM con el mes de alta y el de baja del socio
            int periodoAlta = socio.FechaAlta.Year * 100 + socio.FechaAlta.Month;

            if (cuota.MesAnio < periodoAlta)
            {
                throw new ReglaNegocioException(
                    $"El período de la cuota es anterior al alta del socio ({socio.FechaAlta:MM/yyyy}).");
            }

            if (socio.FechaBaja.HasValue && cuota.MesAnio > socio.FechaBaja.Value.Year * 100 + socio.FechaBaja.Value.Month)
            {
                throw new ReglaNegocioException(
                    $"El período de la cuota es posterior a la baja del socio ({socio.FechaBaja.Value:MM/yyyy}).");
            }

            if (await _cuotaRepository.ExisteAsync(cuota.SocioId, cuota.MesAnio, cuota.CuotaId == 0 ? null : cuota.CuotaId))
            {
                throw new ReglaNegocioException(
                    $"El socio ya tiene registrada la cuota de {cuota.Mes:00}/{cuota.Anio}.");
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _cuotaRepository.EliminarAsync(id);
        }
    }
}