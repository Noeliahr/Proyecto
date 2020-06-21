using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.ControlPacientes.Recordatorios;

namespace WSControldePacientesApi.Termometro
{
    public class RecorAppService : ApplicationService
    {
        private IRepository<Recordatorio> _recordatorioRepository;
        
        public RecorAppService(IRepository<Recordatorio> repository)
        {
            _recordatorioRepository = repository;
        }


        public async Task<string []> GetisRecordatorio (){
            DateTime today = DateTime.Now;
            var recordatorios = await _recordatorioRepository.GetAll()
                .Where(r => r.FechaHora.Date == today.Date && r.Texto.Contains("Temperatura"))
                .ToListAsync();

            DateTime mas5 = today.AddMinutes(5);
            DateTime menos5 = today.AddMinutes(-5);

            string[] idPacientes = new string[recordatorios.Count];
            bool entra = false;

            for (int i=0; i<recordatorios.Count; i++)
            {
                if (recordatorios.ElementAt(i).FechaHora> menos5 && recordatorios.ElementAt(i).FechaHora < mas5)
                {
                    idPacientes[i] = recordatorios.ElementAt(i).PacienteId.ToString();
                    entra = true;
                }
            }
            if (!entra)
            {
                idPacientes[0] = "null";
            }

            return idPacientes;
        }
    }
}
