using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<EnfermedadDto> Get(int id)
        {
            var enfer = await _enfermedadrepository.GetAll()
                .Where(e => e.Id == id).FirstOrDefaultAsync();

            return ObjectMapper.Map<EnfermedadDto>(enfer);       
        }

        public async Task<EnfermedadDto> Update (EnfermedadDto input)
        {
            var enfer = ObjectMapper.Map<Enfermedad>(input);
            await _enfermedadrepository.UpdateAsync(enfer);

            return ObjectMapper.Map<EnfermedadDto>(enfer);
        }

        public async Task Delete(int id)
        {
            await _enfermedadrepository.DeleteAsync(id);
        }
    }
}
