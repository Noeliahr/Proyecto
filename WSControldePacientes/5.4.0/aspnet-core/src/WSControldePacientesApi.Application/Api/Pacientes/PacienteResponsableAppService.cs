using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Pacientes.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.ControlTemperaturas;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControlPacientesApi.ControlPacienteApi.ControlesTemperaturas.Dto;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControldePacientesApi.Api.Pacientes
{
    public class PacienteResponsableAppService : ApplicationService
    {
        private readonly IRepository<Paciente> _pacienteRepository;

        private readonly UserManager _userManager;

        public PacienteResponsableAppService(IRepository<Paciente> repository, UserManager userManager)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<PacienteDto>> GetAllPacientes()
        {
            var responsableActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.DatosPersonales)
                .Include(pacientes=> pacientes.MisResponsables)
                    .ThenInclude(pacientes=> pacientes.Responsable)
                        .ThenInclude(p=> p.DatosPersonales)
                .ToListAsync();

            bool esta = false;

            for(int i=0; i<pacientes.Count; i++)
            {
               foreach(PacienteResponsable pacienteResponsable in pacientes.ElementAt(i).MisResponsables)
                {
                    if (pacienteResponsable.Responsable.DatosPersonales== responsableActual)
                    {
                        esta = true;
                    }
                }
               if (esta == false)
                {
                    pacientes.RemoveAt(i);
                    i--;
                }
                esta = false;
            }
          
            return new ListResultDto<PacienteDto>(ObjectMapper.Map<List<PacienteDto>>(pacientes));
        }

        public async Task<ListResultDto<PacienteDto>> BuscarPorNumSS(long numSS)
        {
            var pacientes = await _pacienteRepository.GetAll()
                    .Include(pacientes => pacientes.DatosPersonales)
                    .Where(pacientes => pacientes.NumSeguridadSocial == numSS)
                    .ToListAsync();

            return new ListResultDto<PacienteDto>(ObjectMapper.Map<List<PacienteDto>>(pacientes));
        }

        public async Task<ListResultDto<PacienteDto>> BuscarPorNombre(string nombre)
        {
            var pacientes = await _pacienteRepository.GetAll()
                    .Include(pacientes => pacientes.DatosPersonales)
                    .Where(pacientes => pacientes.DatosPersonales.Name.Equals(nombre))
                    .ToListAsync();

            return new ListResultDto<PacienteDto>(ObjectMapper.Map<List<PacienteDto>>(pacientes));
        }

        public async Task<ListResultDto<PacienteDto>> BuscarPorLogin(string userName)
        {
            var pacientes = await _pacienteRepository.GetAll()
                    .Include(pacientes => pacientes.DatosPersonales)
                    .Where(pacientes => pacientes.DatosPersonales.UserName.Equals(userName))
                    .ToListAsync();

            return new ListResultDto<PacienteDto>(ObjectMapper.Map<List<PacienteDto>>(pacientes));
        }

        public async Task<MisResponsables> GetMisResponsables(int id)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.MisResponsables)
                    .ThenInclude(pacientes => pacientes.Responsable)
                        .ThenInclude(pacientes => pacientes.DatosPersonales)
                .Where(pacientes => pacientes.Id == id)
                .FirstOrDefaultAsync();
            return ObjectMapper.Map<MisResponsables>(pacientes);
        }


        public async Task<MisEnfermedades> GetMisEnfermedades(int Id)
        {
            var enfermedades = await _pacienteRepository.GetAll()
                .Include(p=> p.DatosPersonales)
                .Include(p => p.MisEnfermedades)
                    .ThenInclude(p => p.Enfermedad)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<MisEnfermedades>(enfermedades);
        }



        public async Task<MiEvolucionTemperatura> GetEvoluciondeTemperatura(int Id)
        {
            var temperaturas = await _pacienteRepository.GetAll()
                .Include(p => p.ControlTemperatura)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<MiEvolucionTemperatura>(temperaturas);
        }

        public async Task<MiEvolucionTemperatura> GetEvoluciondeTemperaturaByFecha(int Id, DateTime fecha)
        {
            var temperaturas = await _pacienteRepository.GetAll()
                .Include(p => p.ControlTemperatura)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();


            List<ControlTemperatura> temp = new List<ControlTemperatura>();


            for (int i = 0; i < temperaturas.ControlTemperatura.Count; i++)
            {
                if (temperaturas.ControlTemperatura.ElementAt(i).Fecha.Equals(fecha))
                {
                    // temp.ControlTemperatura.Remove(temp.ControlTemperatura.ElementAt(i));
                    temp.Add(temperaturas.ControlTemperatura.ElementAt(i));
                    i--;
                }
            }

            MiEvolucionTemperatura miEvolucionTemperatura = new MiEvolucionTemperatura();
            miEvolucionTemperatura.Control_de_Temperatura = ObjectMapper.Map<List<ControlTemperaturaDto>>(temp);


            return miEvolucionTemperatura;
        }


        public async Task<PacienteCompletoDto> GetDatosCompletosByPaciente(int Id)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(p => p.DatosPersonales)
                .Include(p => p.DondeVive)
                .Include(p => p.MiMedicoCabecera)
                    .ThenInclude(p => p.DatosPersonales)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<PacienteCompletoDto>(pacientes);
        }


        public async Task<MisPrescripciones> GetPrescripciones(int id)
        {
            var prescripciones = await _pacienteRepository.GetAll()
                .Include(p => p.MisPrescripciones)
                    .ThenInclude(p => p.Medicamento)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            var pres = ObjectMapper.Map<MisPrescripciones>(prescripciones);

            for (int i = 0; i < prescripciones.MisPrescripciones.Count; i++)
            {
                string trocear = prescripciones.MisPrescripciones.ElementAt(i).Como_Tomar;
                string[] cadena = trocear.Split("-");

                if (cadena[0] == "1")
                {
                    pres.misPrescripciones.ElementAt(i).isManana = true;
                }
                else
                {
                    pres.misPrescripciones.ElementAt(i).isManana = false;
                }

                if (cadena[1] == "1")
                {
                    pres.misPrescripciones.ElementAt(i).isTarde = true;
                }
                else
                {
                    pres.misPrescripciones.ElementAt(i).isTarde = false;
                }

                if (cadena[2] == "1")
                {
                    pres.misPrescripciones.ElementAt(i).isNoche = true;
                }
                else
                {
                    pres.misPrescripciones.ElementAt(i).isNoche = false;
                }
            }
            return pres;
        }
    }
}
