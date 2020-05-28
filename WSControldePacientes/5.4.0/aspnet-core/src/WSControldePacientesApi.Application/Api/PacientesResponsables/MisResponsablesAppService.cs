using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControldePacientesApi.ControlPacientes.Responsables;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto;

namespace WSControldePacientesApi.Api.PacientesResponsables
{
    [AbpAuthorize(PermissionNames.Pages_PacienteResponsables)]
    public class MisResponsablesAppService : ApplicationService
    {
        private readonly IRepository<PacienteResponsable> _pacienteRepository;

        private readonly UserManager _userManager;

        public MisResponsablesAppService(IRepository<PacienteResponsable> repository, UserManager userManager)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<PacienteMiResponsableDto>> GetAll()
        {
            var pacienteActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var responsables = await _pacienteRepository.GetAll()
                .Include(c => c.Responsable)
                    .ThenInclude(c => c.DatosPersonales)
                .Where(c => c.Paciente.DatosPersonalesId == pacienteActual.Id)
                .ToListAsync();

            return new ListResultDto<PacienteMiResponsableDto>(ObjectMapper.Map<List<PacienteMiResponsableDto>>(responsables));
        }

        public async Task AsociarResponsables(int pacienteId, int responsableId)
        {

            PacienteResponsable nuevoPacienteResponsable = new PacienteResponsable();
            nuevoPacienteResponsable.PacienteId = pacienteId;
            nuevoPacienteResponsable.ResponsableId = responsableId;
            
            await _pacienteRepository.InsertAsync(nuevoPacienteResponsable);
            CurrentUnitOfWork.SaveChanges();

        }
    }
}
