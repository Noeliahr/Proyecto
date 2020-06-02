using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControlPacientesApi.ControlPacienteApi.Medicos.Dto;

namespace WSControldePacientesApi.Api.Medicos
{
    [AbpAuthorize(PermissionNames.Pages_DatosPersonalesMedico)]
    public class DatosMedicoAppService : ApplicationService
    {
        private IRepository<Medico> _medicoRepository;
        private UserManager _userManager;

        public DatosMedicoAppService(IRepository<Medico> repository, UserManager userManager)
        {
            _medicoRepository = repository;
            _userManager = userManager;
        }

        public async Task<MedicoDto> GetMedico()
        {
            var medicoActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var medico = await _medicoRepository.GetAll()
                .Where(m => m.Id == medicoActual.medicoId)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<MedicoDto>(medico);
        }
    }
}
