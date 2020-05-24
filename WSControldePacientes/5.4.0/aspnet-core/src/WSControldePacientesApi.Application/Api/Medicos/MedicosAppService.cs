using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Medicos.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControlPacientesApi.ControlPacienteApi.Medicos.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Medicos
{
    [AbpAuthorize(PermissionNames.Pages_Medicos)]
    public class MedicosAppService : AsyncCrudAppService<Medico, MedicoDto, int, PagedMedicoResultRequestDto, CreateMedicoDto, MedicoDto>
    {
        private readonly IRepository<Medico> _medicosRepository;
        public MedicosAppService(IRepository<Medico> repository) : base(repository)
        {
            _medicosRepository = repository;
        }

        public async Task<ListResultDto<MedicoDto>> GetAllMedicos()
        {
            var medicos = await _medicosRepository.GetAll()
                .Include(m => m.DatosPersonales)
                .ToListAsync();

            return new ListResultDto<MedicoDto>(ObjectMapper.Map<List<MedicoDto>>(medicos));
        }

        public async Task<ListResultDto<UserNameMedicoDto>> GetAllUserNameMedicos()
        {
            var medicos = await _medicosRepository.GetAll()
                .Include(m => m.DatosPersonales)
                .ToListAsync();

            return new ListResultDto<UserNameMedicoDto>(ObjectMapper.Map<List<UserNameMedicoDto>>(medicos));
        }


    }
}
