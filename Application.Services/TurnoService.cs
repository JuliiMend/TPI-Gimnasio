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

        public async Task<List<TurnoDTO>> ObtenerTodosAsync()
        {
            var turnos = await _turnoRepository.ObtenerTodosAsync();

            return turnos.Select(t => new TurnoDTO
            {
                IdTurno = t.IdTurno,
                DiaSemana = t.DiaSemana,
                HoraDesde = t.HoraDesde,
                HoraHasta = t.HoraHasta
            }).ToList();
        }

        public async Task<TurnoDTO?> ObtenerPorIdAsync(int id)
        {
            var turno = await _turnoRepository.ObtenerPorIdAsync(id);

            if (turno == null)
            {
                return null;
            }

            return new TurnoDTO
            {
                IdTurno = turno.IdTurno,
                DiaSemana = turno.DiaSemana,
                HoraDesde = turno.HoraDesde,
                HoraHasta = turno.HoraHasta
            };
        }

        public async Task AgregarAsync(TurnoCreaActualizaDTO turnoDto)
        {
            var turno = new Turno
            {
                DiaSemana = turnoDto.DiaSemana,
                HoraDesde = turnoDto.HoraDesde,
                HoraHasta = turnoDto.HoraHasta
            };

            await _turnoRepository.AgregarAsync(turno);
        }

        public async Task ActualizarAsync(int id, TurnoCreaActualizaDTO turnoDto)
        {
            var turno = new Turno
            {
                IdTurno = id,
                DiaSemana = turnoDto.DiaSemana,
                HoraDesde = turnoDto.HoraDesde,
                HoraHasta = turnoDto.HoraHasta
            };

            await _turnoRepository.ActualizarAsync(turno);
        }

        public async Task EliminarAsync(int id)
        {
            await _turnoRepository.EliminarAsync(id);
        }
    }
}