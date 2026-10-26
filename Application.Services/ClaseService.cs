using Data;
using Domain.Model;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClaseService : IClaseService
    {
        private readonly IClaseRepository _claseRepository;
        private readonly ITurnoRepository _turnoRepository;

        public ClaseService(IClaseRepository claseRepository, ITurnoRepository turnoRepository)
        {
            _claseRepository = claseRepository;
            _turnoRepository = turnoRepository;
        }

        public async Task<List<ClaseMostrarDTO>> ObtenerTodosAsync(int? idProfesor = null)
        {
            var clases = await _claseRepository.ObtenerTodosAsync(idProfesor);

            return clases.Select(MapearAMostrar).ToList();
        }

        public async Task<ClaseMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var clase = await _claseRepository.ObtenerPorIdAsync(id);

            return clase == null ? null : MapearAMostrar(clase);
        }

        public async Task<int> AgregarAsync(ClaseCreaActualizaDTO claseDto)
        {
            var clase = new Clase
            {
                IdActividad = claseDto.IdActividad,
                IdProfesor = claseDto.IdProfesor,
                IdTurno = claseDto.IdTurno,
                Cupo = claseDto.Cupo
            };

            await ValidarAsync(clase);

            await _claseRepository.AgregarAsync(clase);
            return clase.IdClase;
        }

        public async Task ActualizarAsync(int id, ClaseCreaActualizaDTO claseDto)
        {
            var clase = await _claseRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException("La clase no existe.");

            if (claseDto.Cupo < clase.Inscripciones.Count)
            {
                throw new ReglaNegocioException(
                    $"El cupo no puede ser menor a la cantidad de inscriptos ({clase.Inscripciones.Count}).");
            }

            clase.IdActividad = claseDto.IdActividad;
            clase.IdProfesor = claseDto.IdProfesor;
            clase.IdTurno = claseDto.IdTurno;
            clase.Cupo = claseDto.Cupo;

            await ValidarAsync(clase);

            await _claseRepository.ActualizarAsync(clase);
        }

        // Un profesor no puede dar dos clases en turnos que se superponen
        private async Task ValidarAsync(Clase clase)
        {
            clase.Validar();

            var turno = await _turnoRepository.ObtenerPorIdAsync(clase.IdTurno)
                ?? throw new ReglaNegocioException("El turno seleccionado no existe.");

            var clasesDelProfesor = await _claseRepository.ObtenerTodosAsync(clase.IdProfesor);

            var superpuesta = clasesDelProfesor.FirstOrDefault(c =>
                c.IdClase != clase.IdClase && c.Turno != null && c.Turno.SeSuperponeCon(turno));

            if (superpuesta != null)
            {
                throw new ReglaNegocioException(
                    $"El profesor ya da la clase de {superpuesta.Actividad?.Tipo} el {superpuesta.Turno!.DiaSemana} " +
                    $"de {superpuesta.Turno.HoraDesde:hh\\:mm} a {superpuesta.Turno.HoraHasta:hh\\:mm}, que se superpone con ese turno.");
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _claseRepository.EliminarAsync(id);
        }

        private static ClaseMostrarDTO MapearAMostrar(Clase c)
        {
            return new ClaseMostrarDTO
            {
                IdClase = c.IdClase,
                IdActividad = c.IdActividad,
                Actividad = c.Actividad?.Tipo ?? string.Empty,
                IdProfesor = c.IdProfesor,
                Profesor = c.Profesor != null ? $"{c.Profesor.Nombre} {c.Profesor.Apellido}" : string.Empty,
                IdTurno = c.IdTurno,
                Turno = c.Turno != null
                    ? $"{c.Turno.DiaSemana} {c.Turno.HoraDesde:hh\\:mm} - {c.Turno.HoraHasta:hh\\:mm}"
                    : string.Empty,
                Cupo = c.Cupo,
                Inscriptos = c.Inscripciones.Count
            };
        }
    }
}
