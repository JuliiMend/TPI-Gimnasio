using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;

        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }

        public List<TurnoDTO> ObtenerTodos()
        {
            return _turnoRepository.ObtenerTodos()
                .Select(t => new TurnoDTO
                {
                    IdTurno = t.IdTurno,
                    DiaSemana = t.DiaSemana,
                    HoraDesde = t.HoraDesde,
                    HoraHasta = t.HoraHasta
                }).ToList();
        }

        public TurnoDTO? ObtenerPorId(int id)
        {
            var turno = _turnoRepository.ObtenerPorId(id);
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

        public void Agregar(TurnoCreaActualizaDTO turnoDto)
        {
            var turno = new Turno
            {
                DiaSemana = turnoDto.DiaSemana,
                HoraDesde = turnoDto.HoraDesde,
                HoraHasta = turnoDto.HoraHasta
            };
            _turnoRepository.Agregar(turno);
        }

        public void Actualizar(int id, TurnoCreaActualizaDTO turnoDto)
        {
            var turno = new Turno
            {
                IdTurno = id,
                DiaSemana = turnoDto.DiaSemana,
                HoraDesde = turnoDto.HoraDesde,
                HoraHasta = turnoDto.HoraHasta
            };
            _turnoRepository.Actualizar(turno);
        }

        public void Eliminar(int id)
        {
            _turnoRepository.Eliminar(id);
        }
    }
}