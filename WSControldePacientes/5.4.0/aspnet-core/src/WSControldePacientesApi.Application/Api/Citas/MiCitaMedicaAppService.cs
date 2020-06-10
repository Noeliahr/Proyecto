using Abp.Application.Services;
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
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControldePacientesApi.Api.Citas
{
    [AbpAuthorize(PermissionNames.Pages_MisCitas)]
    public class MiCitaMedicaAppService : ApplicationService
    {
        private IRepository<Cita> _citaRepository;
        private UserManager _userManager;

        public MiCitaMedicaAppService(IRepository<Cita> repository, UserManager userManager)
        {
            _citaRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<CitaDto>> GetMisCitas()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var citas = await _citaRepository.GetAll()
                .Include(c => c.Direccion)
                .Include(c => c.Medico)
                    .ThenInclude(c => c.DatosPersonales)
                .Include(c=> c.Paciente)
                    .ThenInclude(c=> c.DatosPersonales)
                .Where(c => c.Paciente.DatosPersonales== user)
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();

            return new ListResultDto<CitaDto>(ObjectMapper.Map<List<CitaDto>>(citas));

        }

        public async Task AnularCita(int input)
        {
            var cita = _citaRepository.Get(input);
            await _citaRepository.DeleteAsync(cita);
        }
    }
}
