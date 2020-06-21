using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControldePacientesApi.Termometro
{
    public class PersonasRelacionadasAppService : ApplicationService
    {
        private IRepository<Paciente> _pacienteReposirtory;

        public PersonasRelacionadasAppService(IRepository<Paciente> repository)
        {
            _pacienteReposirtory = repository;
        }

        public async Task<string []> getResponsables(int id)
        {
            var paciente = await _pacienteReposirtory.GetAll()
                .Include(p=> p.DatosPersonales)
                .Include(p => p.MisResponsables)
                    .ThenInclude(p => p.Responsable)
                        .ThenInclude(p => p.DatosPersonales)
                .Include(p => p.MiMedicoCabecera)
                    .ThenInclude(p => p.DatosPersonales)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            
            string[] responsables = new string[paciente.MisResponsables.Count + 2];

            responsables[0] = paciente.DatosPersonales.UserName;
            responsables[1] = paciente.MiMedicoCabecera.DatosPersonales.UserName;

            for(int i=0; i<paciente.MisResponsables.Count; i++)
            {
                responsables[i+2] = paciente.MisResponsables.ElementAt(i).Responsable.DatosPersonales.UserName;
            }

            return responsables;

        }
    }
}
