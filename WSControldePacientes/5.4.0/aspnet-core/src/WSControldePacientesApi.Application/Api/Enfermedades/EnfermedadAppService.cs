using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.ControlPacientes.Enfermedades;
using WSControlPacientesApi.ControlPacienteApi.Enfermedades.Dto;

namespace WSControldePacientesApi.Api.Enfermedades
{
    public class EnfermedadAppService : ApplicationService
    {
        private IRepository<Enfermedad> _enfermedadrepository;

        public EnfermedadAppService(IRepository<Enfermedad> repository)
        {
            _enfermedadrepository = repository;
        }

        public async Task<ListResultDto<EnfermedadDto>> GetAll()
        {
            var enfermedades = await _enfermedadrepository.GetAll().ToListAsync();

            return new ListResultDto<EnfermedadDto>(ObjectMapper.Map<List<EnfermedadDto>>(enfermedades));
        }

        public async Task<EnfermedadDto> Create(EnfermedadDto enfermedad)
        {
            var enfer = ObjectMapper.Map<Enfermedad>(enfermedad);
            await _enfermedadrepository.InsertAsync(enfer);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<EnfermedadDto>(enfer);
        }
    }
}
