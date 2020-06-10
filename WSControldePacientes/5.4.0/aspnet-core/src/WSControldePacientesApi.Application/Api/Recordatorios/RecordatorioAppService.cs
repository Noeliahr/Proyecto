using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Prescripciones.Dto;
using WSControldePacientesApi.Api.Recordatorios.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Recordatorios;

namespace WSControldePacientesApi.Api.Recordatorios
{
    public class RecordatorioAppService : ApplicationService
    {
        private IRepository<Recordatorio> _recordatorioRepositoy;
        private UserManager _userManager;

        public RecordatorioAppService(IRepository<Recordatorio> repository, UserManager userManager)
        {
            _recordatorioRepositoy = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<RecordatorioDto>> GetAll(int id)
        {
            var recordatorios = await _recordatorioRepositoy.GetAll()
                .Where(r => r.PacienteId == id)
                .ToListAsync();
            return new ListResultDto<RecordatorioDto>(ObjectMapper.Map<List<RecordatorioDto>>(recordatorios));
        }

        public async Task CreateByPrescripcion (PrescripcionDto input)
        {
            double cuantoSumar=0;

            if (input.Como_Tomar.Equals("1-1-1"))
            {
                cuantoSumar = 8;
            }
            else if (input.Como_Tomar.Equals("1-0-1"))
            {
                cuantoSumar = 12;
            }
            else if (input.Como_Tomar.Equals("1-0-0"))
            {
                cuantoSumar = 24;
            }
            else if (input.Como_Tomar.Equals("0-1-0"))
            {
                cuantoSumar = 24;
            }
            else if (input.Como_Tomar.Equals("0-0-1"))
            {
                cuantoSumar = 24;
            }


            for (DateTime dateTime = input.Fecha_Inicio; dateTime<= input.Fecha_Final; dateTime=dateTime.AddHours(cuantoSumar))
            {
                Recordatorio nuevo_recordatorio = new Recordatorio();
                nuevo_recordatorio.Texto = "Tomar " + input.MedicamentoNombre;
                nuevo_recordatorio.PacienteId = input.PacienteId;
                nuevo_recordatorio.FechaHora = dateTime;

                await _recordatorioRepositoy.InsertAsync(nuevo_recordatorio);
                CurrentUnitOfWork.SaveChanges();
            }

        }

        public async Task Create (int idPaciente, RecordatorioDto recordatorioDto)
        {
            var recordatorio = ObjectMapper.Map<Recordatorio>(recordatorioDto);
            recordatorio.PacienteId = idPaciente;

            await _recordatorioRepositoy.InsertAsync(recordatorio);
            CurrentUnitOfWork.SaveChanges();
        }

        public async Task Delete (int id)
        {
            await _recordatorioRepositoy.DeleteAsync(id);
        }
        

        public async Task Update(RecordatorioDto recordatorioDto)
        {
            var recordatorio = ObjectMapper.Map<Recordatorio>(recordatorioDto);
            await _recordatorioRepositoy.UpdateAsync(recordatorio);
        }


        public async Task<RecordatorioDto> Get(int id)
        {
            var recordatorio = await _recordatorioRepositoy.GetAll()
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
            return ObjectMapper.Map<RecordatorioDto>(recordatorio);
        }

    }
}
