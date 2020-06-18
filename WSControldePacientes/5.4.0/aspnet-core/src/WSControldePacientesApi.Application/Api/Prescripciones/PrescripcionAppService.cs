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

        public async Task<List<PrescripcionDto>> GetAll(int id)
        {
            var prescripcion = await _precripcionesRepository.GetAll()
                .Include(c => c.Medicamento)
                .Where(c => c.Paciente.Id== id)
                .ToListAsync();
            var prescripciones = new List<PrescripcionDto>(ObjectMapper.Map<List<PrescripcionDto>>(prescripcion));

            for(int i=0; i<prescripcion.Count; i++)
            {
                string trocear = prescripcion.ElementAt(i).Como_Tomar;
                string[] cadena = trocear.Split("-");

                if (cadena[0] == "1")
                {
                    prescripciones.ElementAt(i).isManana = true;
                }
                else
                {
                    prescripciones.ElementAt(i).isManana = false;
                }

                if (cadena[1] == "1")
                {
                    prescripciones.ElementAt(i).isTarde = true;
                }
                else
                {
                    prescripciones.ElementAt(i).isTarde = false;
                }

                if (cadena[2] == "1")
                {
                    prescripciones.ElementAt(i).isNoche = true;
                }
                else
                {
                    prescripciones.ElementAt(i).isNoche = false;
                }
            }

            

            return prescripciones;
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

            var pres = ObjectMapper.Map<PrescripcionDto>(nuevaPrescripcion.ElementAt(nuevaPrescripcion.Count - 1));

            string trocear = nuevaPrescripcion.ElementAt(nuevaPrescripcion.Count - 1).Como_Tomar;
            string [] cadena = trocear.Split("-");

            if (cadena[0] == "1")
            {
                pres.isManana = true;
            }else
            {
                pres.isManana = false;
            }

            if (cadena[1] == "1"){
                pres.isTarde = true;
            }
            else
            {
                pres.isTarde = false;
            }

            if (cadena[2] == "1")
            {
                pres.isNoche = true;
            }
            else
            {
                pres.isNoche = false;
            }



            return pres;

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
