using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Prescripciones.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Prescripciones;

namespace WSControldePacientesApi.Api.Prescripciones
{
    public class PrescripcionAppService : ApplicationService
    {
        private readonly IRepository<Prescripcion> _precripcionesRepository;

        private readonly UserManager _userManager;

        public PrescripcionAppService(IRepository<Prescripcion> repository, UserManager userManager)
        {
            _precripcionesRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<PrescripcionDto>> GetAll()
        {
            var pacienteActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var citas = await _precripcionesRepository.GetAll()
                .Include(c => c.Medicamento)
                .Where(c => c.Paciente.DatosPersonalesId == pacienteActual.Id)
                .ToListAsync();

            return new ListResultDto<PrescripcionDto>(ObjectMapper.Map<List<PrescripcionDto>>(citas));
        }
    }
}
