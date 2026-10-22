using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InscripcionService : IInscripcionService
    {
        private readonly IInscripcionRepository _inscripcionRepository;
        private readonly IClaseRepository _claseRepository;
        private readonly ISocioRepository _socioRepository;

        public InscripcionService(
            IInscripcionRepository inscripcionRepository,
            IClaseRepository claseRepository,
            ISocioRepository socioRepository)
        {
            _inscripcionRepository = inscripcionRepository;
            _claseRepository = claseRepository;
            _socioRepository = socioRepository;
        }

        public async Task<List<InscripcionMostrarDTO>> ObtenerTodosAsync(int? idClase, int? idSocio = null, int? idProfesor = null)
        {
            var inscripciones = await _inscripcionRepository.ObtenerTodosAsync(idClase, idSocio, idProfesor);

            return inscripciones.Select(MapearAMostrar).ToList();
        }

        public async Task<InscripcionMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var inscripcion = await _inscripcionRepository.ObtenerPorIdAsync(id);

            return inscripcion == null ? null : MapearAMostrar(inscripcion);
        }

        public async Task<int> InscribirAsync(InscripcionCreaDTO inscripcionDto)
        {
            var socio = await _socioRepository.ObtenerPorIdAsync(inscripcionDto.IdSocio)
                ?? throw new ReglaNegocioException("El socio no existe.");

            if (socio.FechaBaja.HasValue && socio.FechaBaja.Value.Date <= DateTime.Today)
            {
                throw new ReglaNegocioException("El socio está dado de baja y no puede inscribirse a clases.");
            }

            var clase = await _claseRepository.ObtenerPorIdAsync(inscripcionDto.IdClase)
                ?? throw new ReglaNegocioException("La clase no existe.");

            if (await _inscripcionRepository.ExisteAsync(inscripcionDto.IdSocio, inscripcionDto.IdClase))
            {
                throw new ReglaNegocioException("El socio ya está inscripto en esa clase.");
            }

            var inscriptos = await _inscripcionRepository.ContarPorClaseAsync(inscripcionDto.IdClase);

            if (inscriptos >= clase.Cupo)
            {
                throw new ReglaNegocioException($"La clase no tiene cupo disponible ({inscriptos}/{clase.Cupo}).");
            }

            var inscripcion = new Inscripcion
            {
                IdSocio = inscripcionDto.IdSocio,
                IdClase = inscripcionDto.IdClase,
                FechaInscripcion = DateTime.Now
            };

            await _inscripcionRepository.AgregarAsync(inscripcion);
            return inscripcion.IdInscripcion;
        }

        public async Task EliminarAsync(int id)
        {
            await _inscripcionRepository.EliminarAsync(id);
        }

        private static InscripcionMostrarDTO MapearAMostrar(Inscripcion i)
        {
            var clase = i.Clase;

            return new InscripcionMostrarDTO
            {
                IdInscripcion = i.IdInscripcion,
                IdSocio = i.IdSocio,
                Socio = i.Socio != null ? $"{i.Socio.Nombre} {i.Socio.Apellido}" : string.Empty,
                IdClase = i.IdClase,
                Clase = clase != null
                    ? $"{clase.Actividad?.Tipo} - {clase.Turno?.DiaSemana} {clase.Turno?.HoraDesde:hh\\:mm}"
                    : string.Empty,
                FechaInscripcion = i.FechaInscripcion
            };
        }
    }
}
