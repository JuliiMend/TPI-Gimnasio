using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SocioService : ISocioService
    {
        private readonly ISocioRepository _socioRepository;

        public SocioService(ISocioRepository socioRepository)
        {
            _socioRepository = socioRepository;
        }

        public List<SocioDTO> ObtenerTodos(SocioCriteriaDTO criterios)
        {
            throw new NotImplementedException();
        }

        public SocioDTO? ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Agregar(SocioDTO socioDto)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(int id, SocioDTO socioDto)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}