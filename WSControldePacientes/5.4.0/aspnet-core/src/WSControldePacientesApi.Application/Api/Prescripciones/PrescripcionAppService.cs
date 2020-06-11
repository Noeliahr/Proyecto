using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        public async Task<ListResultDto<PrescripcionDto>> GetAll(int id)
        {
            var prescripcion = await _precripcionesRepository.GetAll()
                .Include(c => c.Medicamento)
                .Where(c => c.Paciente.Id== id)
                .ToListAsync();

            return new ListResultDto<PrescripcionDto>(ObjectMapper.Map<List<PrescripcionDto>>(prescripcion));
        }

        public async Task<PrescripcionDto> CreateAsync(CreatePrescripcionDto input, int idPaciente)
        {
            var prescripcion = ObjectMapper.Map<Prescripcion>(input);

            prescripcion.PacienteId = idPaciente;

            await _precripcionesRepository.InsertAsync(prescripcion);
            CurrentUnitOfWork.SaveChanges();

            var nuevaPrescripcion = await _precripcionesRepository.GetAll()
                .Include(p=>p.Medicamento)
                .ToListAsync();

            return ObjectMapper.Map<PrescripcionDto>(nuevaPrescripcion.ElementAt(nuevaPrescripcion.Count-1));

        }


        public async Task<PrescripcionDto> UpdateAsync (PrescripcionDto input, int idPaciente)
        {
            var prescripcion = ObjectMapper.Map<Prescripcion>(input);
            prescripcion.PacienteId = idPaciente;

            await _precripcionesRepository.UpdateAsync(prescripcion);

            return ObjectMapper.Map<PrescripcionDto>(prescripcion);

        }

        public async Task<PrescripcionDto> GetPrescripcion(int id)
        {
            var prescripcion = await _precripcionesRepository.GetAll()
                .Include(p => p.Medicamento)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<PrescripcionDto>(prescripcion);
        }

        public async Task Delete (int id)
        {
            var prescripcion = _precripcionesRepository.Get(id);

            await _precripcionesRepository.DeleteAsync(prescripcion);
        }


    }
}
