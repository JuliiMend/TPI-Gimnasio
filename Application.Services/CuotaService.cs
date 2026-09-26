using Data;
using Domain.Model;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CuotaService : ICuotaService
    {
        private readonly ICuotaRepository _cuotaRepository;

        public CuotaService(ICuotaRepository cuotaRepository)
        {
            _cuotaRepository = cuotaRepository;
        }

        public async Task<List<CuotaMostrarDTO>> ObtenerTodosAsync()
        {
            var cuotas = await _cuotaRepository.ObtenerTodosAsync();

            return cuotas.Select(c => new CuotaMostrarDTO
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
            }).ToList();
        }

        public async Task<CuotaMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var c = await _cuotaRepository.ObtenerPorIdAsync(id);

            if (c == null) return null;

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

        public async Task AgregarAsync(CuotaCreaActualizaDTO cuotaDto)
        {
            var cuota = new Cuota
            {
                SocioId = cuotaDto.SocioId,
                MesAnio = cuotaDto.MesAnio,
                FechaPago = cuotaDto.FechaPago,
                Valor = cuotaDto.Valor,
                Detalles = cuotaDto.Detalles.Select(d => new DetalleCuota
                {
                    Concepto = d.Concepto,
                    Subtotal = d.Subtotal,
                    Monto = d.Monto
                }).ToList()
            };

            await _cuotaRepository.AgregarAsync(cuota);
        }

        public async Task ActualizarAsync(int id, CuotaCreaActualizaDTO cuotaDto)
        {
            var cuotaExistente = await _cuotaRepository.ObtenerPorIdAsync(id);
            if (cuotaExistente == null)
                throw new Exception("La cuota no existe");

            var cuotaActualizada = new Cuota
            {
                CuotaId = id,
                SocioId = cuotaDto.SocioId,
                MesAnio = cuotaDto.MesAnio,
                FechaPago = cuotaDto.FechaPago,
                Valor = cuotaDto.Valor,
                Detalles = cuotaDto.Detalles.Select(d => new DetalleCuota
                {
                    Concepto = d.Concepto,
                    Subtotal = d.Subtotal
                }).ToList()
            };

            await _cuotaRepository.ActualizarAsync(cuotaActualizada);
        }

        public async Task EliminarAsync(int id)
        {
            await _cuotaRepository.EliminarAsync(id);
        }
    }
}
