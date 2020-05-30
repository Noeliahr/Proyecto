using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.EnfermedadesPacientes.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.EnfermadesPacientes;
using WSControldePacientesApi.ControlPacientes.Enfermedades;
using WSControlPacientesApi.ControlPacienteApi.Enfermedades.Dto;
using WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControldePacientesApi.Api.EnfermedadesPacientes
{
    [AbpAuthorize(PermissionNames.Pages_EnfermedadesPacientes)]
    public class EnfermedadPacienteAppService : ApplicationService
    {
        private readonly IRepository<EnfermedadPaciente> _enfermedadpacienteRepository;


        public EnfermedadPacienteAppService(IRepository<EnfermedadPaciente> repository)
        {
            _enfermedadpacienteRepository = repository;
        }

        public async Task AddEnfermedad(int id, EnfermedadDto enfermedad) {

            EnfermedadPaciente nuevaEnfermedad = new EnfermedadPaciente();

            nuevaEnfermedad.PacienteId = id;
            nuevaEnfermedad.Enfermedad = ObjectMapper.Map<Enfermedad>(enfermedad);

            await _enfermedadpacienteRepository.InsertAsync(nuevaEnfermedad);
            CurrentUnitOfWork.SaveChanges();
        }


        public async Task EliminarEnfermedad(int id, EnfermedadDto enfermedad)
        {
            var enfer = await _enfermedadpacienteRepository.GetAll()
                .Include(e => e.Paciente)
                .Include(e => e.Enfermedad)
                .Where(e => e.PacienteId == id && e.Enfermedad == ObjectMapper.Map<Enfermedad>(enfermedad))
                .FirstOrDefaultAsync();

            await _enfermedadpacienteRepository.DeleteAsync(enfer);
            CurrentUnitOfWork.SaveChanges();

        }

        public async Task<ListResultDto<EnfermedadPacienteDto>> GetAll (int id)
        {
            var enfermedades = await _enfermedadpacienteRepository.GetAll()
                .Include(e => e.Paciente)
                .Include(e => e.Enfermedad)
                .Where(e => e.PacienteId == id)
                .ToListAsync();

            return new ListResultDto<EnfermedadPacienteDto>(ObjectMapper.Map<List<EnfermedadPacienteDto>>(enfermedades));
        }

        public async Task<PacienteEnfermedadDto> getDatosPaciente (int id)
        {
            var paciente = await _enfermedadpacienteRepository.GetAll()
                .Include(e => e.Paciente)
                    .ThenInclude(e=> e.DatosPersonales)
                .Where(e => e.PacienteId == id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<PacienteEnfermedadDto>(paciente);
        }
    }
}
