using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.ControlTemperaturas;
using WSControlPacientesApi.ControlPacienteApi.ControlesTemperaturas.Dto;

namespace WSControldePacientesApi.Api.ControlesTemperaturas
{
    public class ControldeTemperaturaAppService : ApplicationService
    {
        private IRepository<ControlTemperatura> _controlTemperaturaRepository;
        private UserManager _userManager;

        public ControldeTemperaturaAppService(IRepository<ControlTemperatura> repository, UserManager userManager)
        {
            _controlTemperaturaRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<ControlTemperaturaDto>> Get(int user)
        {
            //var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var evolucion = await _controlTemperaturaRepository.GetAll()
                .Include(c => c.Paciente)
                .Where(c => c.Paciente.DatosPersonalesId == user)
                .OrderBy(c=> c.Fecha)
                .ToListAsync();

            return new ListResultDto<ControlTemperaturaDto>(ObjectMapper.Map<List<ControlTemperaturaDto>>(evolucion));
        }

        public async Task<ListResultDto<ControlTemperaturaDto>> GetByToday(int user)
        {
            //var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            DateTime today = DateTime.Now;

            var evolucion = await _controlTemperaturaRepository.GetAll()
                .Include(c => c.Paciente)
                .Where(c => c.Paciente.DatosPersonalesId == user && c.Fecha.Date==today.Date)
                .OrderBy(c => c.Fecha)
                .ToListAsync();

            return new ListResultDto<ControlTemperaturaDto>(ObjectMapper.Map<List<ControlTemperaturaDto>>(evolucion));
        }

        public async Task<ListResultDto<ControlTemperaturaDto>> GetByFecha(int user, DateTime fecha)
        {
            //var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var evolucion = await _controlTemperaturaRepository.GetAll()
                .Include(c => c.Paciente)
                .Where(c => c.Paciente.DatosPersonalesId == user && c.Fecha.Date == fecha.Date)
                .OrderBy(c => c.Fecha)
                .ToListAsync();

            return new ListResultDto<ControlTemperaturaDto>(ObjectMapper.Map<List<ControlTemperaturaDto>>(evolucion));
        }

        public async Task AddNuevaTemperatura (int idPaciente,decimal temp)
        {
            DateTime today = DateTime.Now;

            ControlTemperatura controlTemperatura = new ControlTemperatura();
            controlTemperatura.PacienteId = idPaciente;
            controlTemperatura.Temperatura = temp;
            controlTemperatura.Fecha = today;

            await _controlTemperaturaRepository.InsertAsync(controlTemperatura);
            CurrentUnitOfWork.SaveChanges();

        }

    }
}
