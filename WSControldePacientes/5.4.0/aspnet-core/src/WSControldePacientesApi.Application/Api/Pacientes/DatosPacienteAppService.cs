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
using WSControldePacientesApi.Api.Pacientes.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControldePacientesApi.Api.Pacientes
{
    [AbpAuthorize(PermissionNames.Pages_DatosPersonalesPaciente)]
    public class DatosPacienteAppService : ApplicationService
    {
        private readonly IRepository<Paciente> _pacienteRepository;

        private readonly UserManager _userManager;

        public DatosPacienteAppService(IRepository<Paciente> repository, UserManager userManager)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }

        public async Task<PacienteCompletoDto> Datos()
        {
            var user= await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var paciente = await _pacienteRepository.GetAll()
                .Include(p => p.DatosPersonales)
                .Include(p => p.DondeVive)
                .Include(p => p.Termometro)
                .Include(p => p.MiMedicoCabecera)
                    .ThenInclude(p => p.DatosPersonales)
                .Include(p=> p.MisResponsables)
                .Where(p => p.DatosPersonales == user)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<PacienteCompletoDto>(paciente);
        }


        public async Task<MisResponsables> GetMisResponsables()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.MisResponsables)
                    .ThenInclude(pacientes => pacientes.Responsable)
                        .ThenInclude(pacientes => pacientes.DatosPersonales)
                .Where(pacientes => pacientes.DatosPersonales == user)
                .FirstOrDefaultAsync();
            return ObjectMapper.Map<MisResponsables>(pacientes);
        }

        public async Task<MisEnfermedades> GetMisEnfermedades()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            var medicos = await _pacienteRepository.GetAll()
                .Include(p => p.MisEnfermedades)
                    .ThenInclude(p => p.Enfermedad)
                .Where(p => p.DatosPersonales== user)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<MisEnfermedades>(medicos);
        }


        public async Task<MisPrescripciones> GetMisPrescripciones()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            var prescripciones = await _pacienteRepository.GetAll()
                .Include(p => p.MisPrescripciones)
                    .ThenInclude(p => p.Medicamento)
                .Where(p => p.DatosPersonales == user)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<MisPrescripciones>(prescripciones);
        }



        public async Task<MisRecordatorios> GetMisRecordatorios()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            var recordatorios = await _pacienteRepository.GetAll()
                .Include(p => p.MisRecordatorios)
                .Where(p => p.DatosPersonales == user)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<MisRecordatorios>(recordatorios);
        }


    }
}
