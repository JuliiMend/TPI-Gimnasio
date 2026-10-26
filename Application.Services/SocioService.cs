using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SocioService : ISocioService
    {
        private readonly ISocioRepository _socioRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public SocioService(ISocioRepository socioRepository, IUsuarioRepository usuarioRepository)
        {
            _socioRepository = socioRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<SocioMostrarDTO>> ObtenerTodosAsync(SocioCriteriaDTO? criterios)
        {
            var socios = await _socioRepository.ObtenerTodosAsync(ACriteria(criterios));

            return socios.Select(MapearAMostrar).ToList();
        }

        public async Task<PaginaDTO<SocioMostrarDTO>> ObtenerPaginadoAsync(SocioCriteriaDTO? criterios, int numeroPagina, int tamanioPagina)
        {
            var pagina = await _socioRepository.ObtenerPaginadoAsync(ACriteria(criterios), numeroPagina, tamanioPagina);

            return pagina.ADto(MapearAMostrar);
        }

        private static SocioCriteria ACriteria(SocioCriteriaDTO? criterios)
        {
            return new SocioCriteria
            {
                Nombre = criterios?.Nombre?.Trim() ?? string.Empty,
                Apellido = criterios?.Apellido?.Trim() ?? string.Empty,
                Dni = criterios?.Dni?.Trim() ?? string.Empty,
                IdPlan = criterios?.IdPlan ?? 0
            };
        }

        private static SocioMostrarDTO MapearAMostrar(Socio s)
        {
            return new SocioMostrarDTO
            {
                IdPersona = s.PersonaId,
                Dni = s.Dni,
                Nombre = s.Nombre,
                Apellido = s.Apellido,
                FechaAlta = s.FechaAlta,
                NombrePlan = s.Plan?.Nombre ?? "",
                Telefono = s.Telefono,
                FechaNac = s.FechaNac,
                FechaBaja = s.FechaBaja,
                IdPlan = s.IdPlan,
                Email = s.Usuario?.Email ?? "",
                Username = s.Usuario?.Username ?? "",
                UsuarioActivo = s.Usuario?.Activo ?? false
            };
        }

        public async Task<SocioMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var socio = await _socioRepository.ObtenerPorIdAsync(id);

            if (socio == null)
            {
                return null;
            }

            return new SocioMostrarDTO
            {
                IdPersona = socio.PersonaId,
                Dni = socio.Dni,
                Nombre = socio.Nombre,
                Apellido = socio.Apellido,
                FechaAlta = socio.FechaAlta,
                NombrePlan = socio.Plan?.Nombre ?? "",
                Telefono = socio.Telefono,
                FechaNac = socio.FechaNac,
                FechaBaja = socio.FechaBaja,
                IdPlan = socio.IdPlan,
                Email = socio.Usuario?.Email ?? "",
                Username = socio.Usuario?.Username ?? "",
                UsuarioActivo = socio.Usuario?.Activo ?? false
            };
        }

        public async Task<SocioMostrarDTO?> ObtenerPorUsuarioAsync(int usuarioId)
        {
            var socio = await _socioRepository.ObtenerPorUsuarioIdAsync(usuarioId);

            return socio == null ? null : await ObtenerPorIdAsync(socio.PersonaId);
        }

        public async Task<int> AgregarAsync(SocioCreaActualizaDTO dto)
        {
            var socio = new Socio
            {
                Dni = dto.Dni?.Trim() ?? string.Empty,
                Nombre = dto.Nombre?.Trim() ?? string.Empty,
                Apellido = dto.Apellido?.Trim() ?? string.Empty,
                Telefono = dto.Telefono?.Trim() ?? string.Empty,
                FechaNac = dto.FechaNac.Date,
                FechaAlta = dto.FechaAlta.Date,
                FechaBaja = dto.FechaBaja?.Date,
                IdPlan = dto.IdPlan
            };

            socio.Validar();
            socio.Usuario = CuentaUsuario.Crear(socio.Dni, dto.Username, dto.Email, dto.Password, Roles.Socio);

            await VerificarDuplicadosAsync(socio);

            await _socioRepository.AgregarAsync(socio);

            return socio.PersonaId;
        }

        public async Task ActualizarAsync(int id, SocioCreaActualizaDTO socioDto)
        {
            var socio = await _socioRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException("El socio no existe.");

            socio.Dni = socioDto.Dni?.Trim() ?? string.Empty;
            socio.Nombre = socioDto.Nombre?.Trim() ?? string.Empty;
            socio.Apellido = socioDto.Apellido?.Trim() ?? string.Empty;
            socio.Telefono = socioDto.Telefono?.Trim() ?? string.Empty;
            socio.FechaNac = socioDto.FechaNac.Date;
            socio.FechaAlta = socioDto.FechaAlta.Date;
            socio.FechaBaja = socioDto.FechaBaja?.Date;
            socio.IdPlan = socioDto.IdPlan;

            socio.Validar();

            if (socio.Usuario != null)
            {
                CuentaUsuario.Actualizar(socio.Usuario, socioDto.Username, socioDto.Email, socioDto.Password);
            }

            await VerificarDuplicadosAsync(socio);

            await _socioRepository.ActualizarAsync(socio);
        }

        private async Task VerificarDuplicadosAsync(Socio socio)
        {
            if (await _socioRepository.ExisteDniAsync(socio.Dni, socio.PersonaId == 0 ? null : socio.PersonaId))
            {
                throw new ReglaNegocioException($"Ya existe un socio con el DNI {socio.Dni}.");
            }

            if (socio.Usuario != null)
            {
                await CuentaUsuario.VerificarDisponibleAsync(_usuarioRepository, socio.Usuario);
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _socioRepository.EliminarAsync(id);
        }
    }
}