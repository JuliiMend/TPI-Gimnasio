using Data;
using Domain.Model;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<List<MaterialMostrarDTO>> ObtenerTodosAsync()
        {
            var materiales = await _materialRepository.ObtenerTodosAsync();

            return materiales.Select(m => new MaterialMostrarDTO
            {
                IdMaterial = m.IdMaterial,
                Descripcion = m.Descripcion,
                Stock = m.Stock
            }).ToList();
        }

        public async Task<MaterialMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var material = await _materialRepository.ObtenerPorIdAsync(id);

            if (material == null)
            {
                return null;
            }

            return new MaterialMostrarDTO
            {
                IdMaterial = material.IdMaterial,
                Descripcion = material.Descripcion,
                Stock = material.Stock
            };
        }

        public async Task<int> AgregarAsync(MaterialCreaActualizaDTO materialDto)
        {
            var material = new Material
            {
                Descripcion = materialDto.Descripcion?.Trim() ?? string.Empty,
                Stock = materialDto.Stock
            };

            material.Validar();

            await _materialRepository.AgregarAsync(material);
            return material.IdMaterial;
        }

        public async Task ActualizarAsync(int id, MaterialCreaActualizaDTO materialDto)
        {
            var material = new Material
            {
                IdMaterial = id,
                Descripcion = materialDto.Descripcion?.Trim() ?? string.Empty,
                Stock = materialDto.Stock
            };

            material.Validar();

            await _materialRepository.ActualizarAsync(material);
        }

        public async Task EliminarAsync(int id)
        {
            await _materialRepository.EliminarAsync(id);
        }
    }
}
