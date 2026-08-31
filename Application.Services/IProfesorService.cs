using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface IProfesorService
    {
        List<ProfesorDTO> ObtenerTodos();
        ProfesorDTO? ObtenerPorId(int id);
        void Agregar(ProfesorCreaActualizaDTO profesorDto);
        void Actualizar(int id, ProfesorCreaActualizaDTO profesorDto);
        void Eliminar(int id);
    }
}