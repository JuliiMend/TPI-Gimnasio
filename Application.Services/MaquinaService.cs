using Data;
using Domain.Model;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MaquinaService : IMaquinaService
    {
        private readonly IMaquinaRepository _maquinaRepository;

        public MaquinaService(IMaquinaRepository maquinaRepository)
        {
            _maquinaRepository = maquinaRepository;
        }

        public async Task<List<MaquinaMostrarDTO>> ObtenerTodosAsync()
        {
            var maquinas = await _maquinaRepository.ObtenerTodosAsync();

            return maquinas.Select(m => new MaquinaMostrarDTO
            {
                IdMaquina = m.IdMaquina,
                Nombre = m.Nombre,
                Descripcion = m.Descripcion,
                Tipo = m.Tipo,
                Estado = m.Estado
            }).ToList();
        }

        public async Task<MaquinaMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var maquina = await _maquinaRepository.ObtenerPorIdAsync(id);

            if (maquina == null)
            {
                return null;
            }

            return new MaquinaMostrarDTO
            {
                IdMaquina = maquina.IdMaquina,
                Nombre = maquina.Nombre,
                Descripcion = maquina.Descripcion,
                Tipo = maquina.Tipo,
                Estado = maquina.Estado
            };
        }

        public async Task<int> AgregarAsync(MaquinaCreaActualizaDTO maquinaDto)
        {
            var maquina = new Maquina
            {
                Nombre = maquinaDto.Nombre,
                Descripcion = maquinaDto.Descripcion,
                Tipo = maquinaDto.Tipo,
                Estado = maquinaDto.Estado
            };

            await _maquinaRepository.AgregarAsync(maquina);
            return maquina.IdMaquina;
        }

        public async Task ActualizarAsync(int id, MaquinaCreaActualizaDTO maquinaDto)
        {
            var maquina = new Maquina
            {
                IdMaquina = id,
                Nombre = maquinaDto.Nombre,
                Descripcion = maquinaDto.Descripcion,
                Tipo = maquinaDto.Tipo,
                Estado = maquinaDto.Estado
            };

            await _maquinaRepository.ActualizarAsync(maquina);
        }

        public async Task EliminarAsync(int id)
        {
            await _maquinaRepository.EliminarAsync(id);
        }
    }
}
