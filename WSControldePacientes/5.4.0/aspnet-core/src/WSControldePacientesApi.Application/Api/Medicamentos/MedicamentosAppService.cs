using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Medicamentos.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Medicamentos;

namespace WSControldePacientesApi.Api.Medicamentos
{
    public class MedicamentosAppService : ApplicationService
    {
        private IRepository<Medicamento> _medicamentoRepository;
        private UserManager _userManager;

        public MedicamentosAppService(IRepository<Medicamento> repository, UserManager user) {
            _medicamentoRepository = repository;
            _userManager = user;
        }

        public async Task<ListResultDto<MedicamentoDto>> GetAll()
        {
            var medicamentos = await _medicamentoRepository.GetAll()
               .ToListAsync();
            return new ListResultDto<MedicamentoDto>(ObjectMapper.Map<List<MedicamentoDto>>(medicamentos));
        }

        public async Task<MedicamentoDto> Create (MedicamentoDto input)
        {
            var medicamento = ObjectMapper.Map<Medicamento>(input);
            await _medicamentoRepository.InsertAsync(medicamento);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<MedicamentoDto>(medicamento);
        }

        public async Task<MedicamentoDto> Get(int id)
        {
            var medicamento = await _medicamentoRepository.GetAll()
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            return ObjectMapper.Map<MedicamentoDto>(medicamento);
        }

        public async Task<MedicamentoDto> Update (MedicamentoDto input)
        {
            var medicamento = ObjectMapper.Map<Medicamento>(input);
            await _medicamentoRepository.UpdateAsync(medicamento);

            return ObjectMapper.Map<MedicamentoDto>(medicamento);
        }


    }
}
