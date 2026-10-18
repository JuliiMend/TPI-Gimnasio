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

        public ClaseService(IClaseRepository claseRepository)
        {
            _claseRepository = claseRepository;
        }

        public async Task<List<ClaseMostrarDTO>> ObtenerTodosAsync()
        {
            var clases = await _claseRepository.ObtenerTodosAsync();

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

            await _claseRepository.AgregarAsync(clase);
            return clase.IdClase;
        }

        public async Task ActualizarAsync(int id, ClaseCreaActualizaDTO claseDto)
        {
            var clase = await _claseRepository.ObtenerPorIdAsync(id);

            if (clase != null)
            {
                if (claseDto.Cupo < clase.Inscripciones.Count)
                {
                    throw new ReglaNegocioException(
                        $"El cupo no puede ser menor a la cantidad de inscriptos ({clase.Inscripciones.Count}).");
                }

                clase.IdActividad = claseDto.IdActividad;
                clase.IdProfesor = claseDto.IdProfesor;
                clase.IdTurno = claseDto.IdTurno;
                clase.Cupo = claseDto.Cupo;

                await _claseRepository.ActualizarAsync(clase);
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
