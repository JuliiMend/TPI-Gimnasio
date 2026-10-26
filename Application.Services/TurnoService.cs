using Data;
using Domain.Model;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;

        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }

        public async Task<List<TurnoMostrarDTO>> ObtenerTodosAsync()
        {
            var turnos = await _turnoRepository.ObtenerTodosAsync();

            return turnos.Select(t => new TurnoMostrarDTO
            {
                IdTurno = t.IdTurno,
                DiaSemana = t.DiaSemana,
                HoraDesde = t.HoraDesde,
                HoraHasta = t.HoraHasta
            }).ToList();
        }

        public async Task<TurnoMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var turno = await _turnoRepository.ObtenerPorIdAsync(id);

            if (turno == null)
            {
                return null;
            }

            return new TurnoMostrarDTO
            {
                IdTurno = turno.IdTurno,
                DiaSemana = turno.DiaSemana,
                HoraDesde = turno.HoraDesde,
                HoraHasta = turno.HoraHasta
            };
        }

        public async Task<int> AgregarAsync(TurnoCreaActualizaDTO turnoDto)
        {
            var turno = new Turno
            {
                DiaSemana = turnoDto.DiaSemana?.Trim() ?? string.Empty,
                HoraDesde = turnoDto.HoraDesde,
                HoraHasta = turnoDto.HoraHasta
            };

            await ValidarAsync(turno);

            await _turnoRepository.AgregarAsync(turno);
            return turno.IdTurno;
        }

        public async Task ActualizarAsync(int id, TurnoCreaActualizaDTO turnoDto)
        {
            var turno = new Turno
            {
                IdTurno = id,
                DiaSemana = turnoDto.DiaSemana?.Trim() ?? string.Empty,
                HoraDesde = turnoDto.HoraDesde,
                HoraHasta = turnoDto.HoraHasta
            };

            await ValidarAsync(turno);

            await _turnoRepository.ActualizarAsync(turno);
        }

        private async Task ValidarAsync(Turno turno)
        {
            turno.Validar();

            var existentes = await _turnoRepository.ObtenerTodosAsync();

            if (existentes.Any(t => t.IdTurno != turno.IdTurno &&
                                    t.DiaSemana == turno.DiaSemana &&
                                    t.HoraDesde == turno.HoraDesde &&
                                    t.HoraHasta == turno.HoraHasta))
            {
                throw new ReglaNegocioException($"Ya existe un turno el {turno.DiaSemana} de {turno.HoraDesde:hh\\:mm} a {turno.HoraHasta:hh\\:mm}.");
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _turnoRepository.EliminarAsync(id);
        }
    }
}