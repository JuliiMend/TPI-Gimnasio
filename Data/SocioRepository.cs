using Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class SocioRepository : ISocioRepository
    {
        public List<Socio> ObtenerTodos(SocioCriteria criterios)
        {
            var socios = DatosEnMemoria.Socios.AsEnumerable();
            if (!string.IsNullOrEmpty(criterios.Nombre))
            {
                socios = socios.Where(s =>
                    s.Nombre.Contains(criterios.Nombre));
            }

            if (!string.IsNullOrEmpty(criterios.Apellido))
            {
                socios = socios.Where(s =>
                    s.Apellido.Contains(criterios.Apellido));
            }

            if (!string.IsNullOrEmpty(criterios.Dni))
            {
                socios = socios.Where(s =>
                    s.Dni.Contains(criterios.Dni));
            }

            if (criterios.IdPlan.HasValue)
            {
                socios = socios.Where(s =>
                    s.IdPlan == criterios.IdPlan.Value);
            }

            return socios.ToList();
        }

        public Socio? ObtenerPorId(int id)
        {
            return DatosEnMemoria.Socios
               .FirstOrDefault(s => s.IdPersona == id);
        }

        public void Agregar(Socio socio)
        {
            DatosEnMemoria.Socios.Add(socio);
        }

        public void Actualizar(Socio socio)
        {
            var existente = ObtenerPorId(socio.IdPersona);

            if (existente != null)
            {
                existente.Dni = socio.Dni;
                existente.Nombre = socio.Nombre;
                existente.Apellido = socio.Apellido;
                existente.Email = socio.Email;
                existente.Telefono = socio.Telefono;
                existente.FechaNac = socio.FechaNac;
                existente.Usuario = socio.Usuario;
                existente.Contraseña = socio.Contraseña;
                existente.FechaAlta = socio.FechaAlta;
                existente.FechaBaja = socio.FechaBaja;
                existente.IdPlan = socio.IdPlan;
            }
        }

        public void Eliminar(int id)
        {
            var socio = ObtenerPorId(id);

            if (socio != null)
            {
                DatosEnMemoria.Socios.Remove(socio);
            }
        }
    }
}