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
    [AbpAuthorize(PermissionNames.Pages_Citas)]
    public class PacienteCitaAppService : ApplicationService
    {
        private IRepository<Cita> _citaRepository;
        private UserManager _userManager;

        public PacienteCitaAppService(IRepository<Cita> repository, UserManager userManager)
        {
            _citaRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<CitaDto>> GetCitasByPaciente(int id)
        {
            var citas = await _citaRepository.GetAll()
                .Include(c => c.Direccion)
                .Include(c => c.Medico)
                    .ThenInclude(c => c.DatosPersonales)
                .Where(c => c.PacienteId == id)
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();

            return new ListResultDto<CitaDto>(ObjectMapper.Map<List<CitaDto>>(citas));

        }

        public async Task Citar (CreateCitaDto cita)
        {
            var medicoActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId()); 
            var citanueva = ObjectMapper.Map<Cita>(cita);

            citanueva.Medico = medicoActual.medico;

            await _citaRepository.InsertAsync(citanueva);
            CurrentUnitOfWork.SaveChanges();

        }
    }
}
