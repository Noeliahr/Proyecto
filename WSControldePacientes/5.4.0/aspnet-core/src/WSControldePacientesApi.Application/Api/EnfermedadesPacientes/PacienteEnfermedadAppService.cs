using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.EnfermadesPacientes;
using WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto;

namespace WSControldePacientesApi.Api.EnfermedadesPacientes
{
    [AbpAuthorize(PermissionNames.Pages_MisEnfermedades)]
    public class PacienteEnfermedadAppService : ApplicationService
    {
        private readonly IRepository<EnfermedadPaciente> _enfermedadpacienteRepository;

        private UserManager _userManager;


        public PacienteEnfermedadAppService(IRepository<EnfermedadPaciente> repository, UserManager userManager)
        {
            _enfermedadpacienteRepository = repository;
            _userManager = userManager;
        }


        public async Task<ListResultDto<EnfermedadPacienteDto>> GetAll()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var enfermedades = await _enfermedadpacienteRepository.GetAll()
                .Include(e => e.Paciente)
                .Include(e => e.Enfermedad)
                .Where(e => e.Paciente.DatosPersonales == user)
                .ToListAsync();

            return new ListResultDto<EnfermedadPacienteDto>(ObjectMapper.Map<List<EnfermedadPacienteDto>>(enfermedades));
        }
    }
}
