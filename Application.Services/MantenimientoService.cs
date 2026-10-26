using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MantenimientoService : IMantenimientoService
    {
        public const string EstadoEnCurso = "En curso";
        public const string EstadoDemorado = "Demorado";
        public const string EstadoFinalizado = "Finalizado";
        public const string EstadoFinalizadoConDemora = "Finalizado con demora";

        private readonly IMantenimientoRepository _mantenimientoRepository;

        public MantenimientoService(IMantenimientoRepository mantenimientoRepository)
        {
            _mantenimientoRepository = mantenimientoRepository;
        }

        public async Task<List<MantenimientoMostrarDTO>> ObtenerTodosAsync(int? idMaquina, string? estado)
        {
            var mantenimientos = await _mantenimientoRepository.ObtenerTodosAsync(idMaquina);

            var resultado = mantenimientos.Select(MapearAMostrar);

            if (!string.IsNullOrWhiteSpace(estado))
            {
                resultado = resultado.Where(m => string.Equals(m.Estado, estado, StringComparison.OrdinalIgnoreCase));
            }

            return resultado.ToList();
        }

        // El estado se calcula en memoria, así que se pagina después de filtrar por él
        public async Task<PaginaDTO<MantenimientoMostrarDTO>> ObtenerPaginadoAsync(int? idMaquina, string? estado, int numeroPagina, int tamanioPagina)
        {
            var todos = await ObtenerTodosAsync(idMaquina, estado);

            return Pagina<MantenimientoMostrarDTO>.Crear(todos, numeroPagina, tamanioPagina).ADto(m => m);
        }

        public async Task<MantenimientoMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var mantenimiento = await _mantenimientoRepository.ObtenerPorIdAsync(id);

            return mantenimiento == null ? null : MapearAMostrar(mantenimiento);
        }

        public async Task<int> AgregarAsync(MantenimientoCreaActualizaDTO dto)
        {
            var mantenimiento = new Mantenimiento
            {
                IdMaquina = dto.IdMaquina,
                FechaInicio = dto.FechaInicio.Date,
                FechaFinEsperada = dto.FechaFinEsperada.Date,
                FechaFinReal = dto.FechaFinReal?.Date,
                Descripcion = dto.Descripcion?.Trim() ?? string.Empty
            };

            await ValidarAsync(mantenimiento);

            await _mantenimientoRepository.AgregarAsync(mantenimiento);
            return mantenimiento.IdMantenimiento;
        }

        public async Task ActualizarAsync(int id, MantenimientoCreaActualizaDTO dto)
        {
            var mantenimiento = await _mantenimientoRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException("El mantenimiento no existe.");

            mantenimiento.IdMaquina = dto.IdMaquina;
            mantenimiento.FechaInicio = dto.FechaInicio.Date;
            mantenimiento.FechaFinEsperada = dto.FechaFinEsperada.Date;
            mantenimiento.FechaFinReal = dto.FechaFinReal?.Date;
            mantenimiento.Descripcion = dto.Descripcion?.Trim() ?? string.Empty;

            await ValidarAsync(mantenimiento);

            await _mantenimientoRepository.ActualizarAsync(mantenimiento);
        }

        public async Task EliminarAsync(int id)
        {
            await _mantenimientoRepository.EliminarAsync(id);
        }

        // Una máquina no puede tener dos mantenimientos abiertos (sin fecha de fin real) a la vez
        private async Task ValidarAsync(Mantenimiento mantenimiento)
        {
            mantenimiento.Validar();

            if (mantenimiento.FechaFinReal.HasValue)
            {
                return;
            }

            var deLaMaquina = await _mantenimientoRepository.ObtenerTodosAsync(mantenimiento.IdMaquina);

            if (deLaMaquina.Any(m => m.IdMantenimiento != mantenimiento.IdMantenimiento && !m.FechaFinReal.HasValue))
            {
                throw new ReglaNegocioException(
                    "La máquina ya tiene un mantenimiento en curso. Cargá la fecha de fin real de ese mantenimiento antes de registrar otro.");
            }
        }

        private static MantenimientoMostrarDTO MapearAMostrar(Mantenimiento m)
        {
            string estado;
            int diasDemora;

            if (m.FechaFinReal.HasValue)
            {
                diasDemora = Math.Max(0, (m.FechaFinReal.Value.Date - m.FechaFinEsperada.Date).Days);
                estado = diasDemora > 0 ? EstadoFinalizadoConDemora : EstadoFinalizado;
            }
            else
            {
                diasDemora = Math.Max(0, (DateTime.Today - m.FechaFinEsperada.Date).Days);
                estado = diasDemora > 0 ? EstadoDemorado : EstadoEnCurso;
            }

            return new MantenimientoMostrarDTO
            {
                IdMantenimiento = m.IdMantenimiento,
                IdMaquina = m.IdMaquina,
                Maquina = m.Maquina?.Nombre ?? string.Empty,
                FechaInicio = m.FechaInicio,
                FechaFinEsperada = m.FechaFinEsperada,
                FechaFinReal = m.FechaFinReal,
                Descripcion = m.Descripcion,
                Estado = estado,
                DiasDemora = diasDemora
            };
        }
    }
}
