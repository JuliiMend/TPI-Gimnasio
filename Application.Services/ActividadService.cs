using Data;
using Domain.Model;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository _actividadRepository;

        public ActividadService(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task<List<ActividadMostrarDTO>> ObtenerTodosAsync()
        {
            var actividades = await _actividadRepository.ObtenerTodosAsync();

            return actividades.Select(a => new ActividadMostrarDTO
            {
                IdActividad = a.IdActividad,
                Tipo = a.Tipo,
                Descripcion = a.Descripcion
            }).ToList();
        }

        public async Task<ActividadMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var actividad = await _actividadRepository.ObtenerPorIdAsync(id);

            if (actividad == null)
            {
                return null;
            }

            return new ActividadMostrarDTO
            {
                IdActividad = actividad.IdActividad,
                Tipo = actividad.Tipo,
                Descripcion = actividad.Descripcion
            };
        }

        public async Task<int> AgregarAsync(ActividadCreaActualizaDTO actividadDto)
        {
            var actividad = new Actividad
            {
                Tipo = actividadDto.Tipo,
                Descripcion = actividadDto.Descripcion
            };

            await _actividadRepository.AgregarAsync(actividad);
            return actividad.IdActividad;
        }

        public async Task ActualizarAsync(int id, ActividadCreaActualizaDTO actividadDto)
        {
            var actividad = await _actividadRepository.ObtenerPorIdAsync(id);

            if (actividad != null)
            {
                actividad.Tipo = actividadDto.Tipo;
                actividad.Descripcion = actividadDto.Descripcion;

                await _actividadRepository.ActualizarAsync(actividad);
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _actividadRepository.EliminarAsync(id);
        }
    }
}
