using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HistoricoSueldoService : IHistoricoSueldoService
    {
        private readonly IHistoricoSueldoRepository _historicoSueldoRepository;
        private readonly IProfesorRepository _profesorRepository;

        public HistoricoSueldoService(
            IHistoricoSueldoRepository historicoSueldoRepository,
            IProfesorRepository profesorRepository)
        {
            _historicoSueldoRepository = historicoSueldoRepository;
            _profesorRepository = profesorRepository;
        }

        public async Task<List<HistoricoSueldoMostrarDTO>> ObtenerTodosAsync(int? idProfesor)
        {
            var sueldos = await _historicoSueldoRepository.ObtenerTodosAsync(idProfesor);

            return sueldos
                .GroupBy(s => s.IdProfesor)
                .SelectMany(grupo =>
                {
                    var ordenados = grupo.OrderBy(s => s.FechaDesde).ToList();

                    return ordenados.Select((s, i) =>
                    {
                        DateTime? hasta = i < ordenados.Count - 1
                            ? ordenados[i + 1].FechaDesde.AddDays(-1)
                            : null;

                        return new HistoricoSueldoMostrarDTO
                        {
                            IdHistoricoSueldo = s.IdHistoricoSueldo,
                            IdProfesor = s.IdProfesor,
                            Profesor = s.Profesor != null ? $"{s.Profesor.Nombre} {s.Profesor.Apellido}" : string.Empty,
                            FechaDesde = s.FechaDesde,
                            FechaHasta = hasta,
                            Valor = s.Valor,
                            Vigente = hasta == null && s.FechaDesde.Date <= DateTime.Today
                        };
                    });
                })
                .OrderBy(s => s.Profesor)
                .ThenByDescending(s => s.FechaDesde)
                .ToList();
        }

        // FechaHasta depende del sueldo siguiente del profesor, así que se pagina después de calcularla
        public async Task<PaginaDTO<HistoricoSueldoMostrarDTO>> ObtenerPaginadoAsync(int? idProfesor, int numeroPagina, int tamanioPagina)
        {
            var todos = await ObtenerTodosAsync(idProfesor);

            return Pagina<HistoricoSueldoMostrarDTO>.Crear(todos, numeroPagina, tamanioPagina).ADto(s => s);
        }

        public async Task<int> RegistrarAsync(HistoricoSueldoCreaDTO dto)
        {
            var sueldo = new HistoricoSueldo
            {
                IdProfesor = dto.IdProfesor,
                FechaDesde = dto.FechaDesde.Date,
                Valor = dto.Valor
            };

            sueldo.Validar();

            _ = await _profesorRepository.ObtenerPorIdAsync(dto.IdProfesor)
                ?? throw new ReglaNegocioException("El profesor no existe.");

            if (await _historicoSueldoRepository.ExisteAsync(dto.IdProfesor, dto.FechaDesde))
            {
                throw new ReglaNegocioException(
                    $"El profesor ya tiene un sueldo registrado desde el {dto.FechaDesde:dd/MM/yyyy}.");
            }

            await _historicoSueldoRepository.AgregarAsync(sueldo);
            return sueldo.IdHistoricoSueldo;
        }
    }
}
