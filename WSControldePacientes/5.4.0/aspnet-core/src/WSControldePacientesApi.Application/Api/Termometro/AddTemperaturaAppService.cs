using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.ControlPacientes.ControlTemperaturas;

namespace WSControldePacientesApi.Termometro
{
    public class AddTemperaturaAppService : ApplicationService
    {
        private IRepository<ControlTemperatura> _repository;

        public AddTemperaturaAppService(IRepository<ControlTemperatura> repository)
        {
            _repository = repository;
        }

        public async Task Add (int idPaciente, decimal temperatura)
        {
            ControlTemperatura controlTemperatura = new ControlTemperatura();
            controlTemperatura.PacienteId = idPaciente;
            controlTemperatura.Temperatura = temperatura;
            controlTemperatura.Fecha = DateTime.Now;

            await _repository.InsertAsync(controlTemperatura);

            CurrentUnitOfWork.SaveChanges();
        }
    }
}
