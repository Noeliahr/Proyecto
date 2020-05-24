﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Citas.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Citas;

namespace WSControldePacientesApi.Api.Citas
{
    [AbpAuthorize(PermissionNames.Pages_CitasMedico)]
    public class AgendaAppService : ApplicationService
    {
        private IRepository<Cita> _citaRepository;
        private UserManager _userManager;

        public AgendaAppService(IRepository<Cita> repository, UserManager userManager)
        {
            _citaRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<AgendaDto>> GetAll()
        {
            var pacienteActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var citas = await _citaRepository.GetAll()
                .Include(c => c.Direccion)
                .Include(c => c.Medico)
                    .ThenInclude(c => c.DatosPersonales)
                .Where(c => c.Paciente.DatosPersonalesId == pacienteActual.Id)
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();

            return new ListResultDto<AgendaDto>(ObjectMapper.Map<List<AgendaDto>>(citas));
        }

        public async Task AnularCita(EntityDto<int> input)
        {
            var cita = _citaRepository.Get(input.Id);
            await _citaRepository.DeleteAsync(cita);
        }

        public async Task<ListResultDto<AgendaDto>> GetAllPorFecha(DateTime fecha)
        {
            var pacienteActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var citas = await _citaRepository.GetAll()
                .Include(c => c.Direccion)
                .Include(c => c.Medico)
                    .ThenInclude(c => c.DatosPersonales)
                .Where(c => c.Paciente.DatosPersonalesId == pacienteActual.Id  && c.FechaHora.Equals(fecha))
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();

            return new ListResultDto<AgendaDto>(ObjectMapper.Map<List<AgendaDto>>(citas));
        }

    }

}