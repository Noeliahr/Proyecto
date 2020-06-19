using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Pacientes.Dto;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.ControlTemperaturas;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControlPacientesApi.ControlPacienteApi.ControlesTemperaturas.Dto;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto;

namespace WSControldePacientesApi.Api.Pacientes
{
    [AbpAuthorize(PermissionNames.Pages_PacienteMedico)]
    public class PacienteMedicoAppService : ApplicationService
    {
        private readonly IRepository<Paciente> _pacienteRepository;

        private readonly UserManager _userManager;

        public PacienteMedicoAppService(IRepository<Paciente> repository, UserManager userManager)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }

        public async Task<bool> GetRole()
        {
            bool isMedicoCabecera = false;
            var medicoActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            IList<string> roles = await _userManager.GetRolesAsync(medicoActual);

            foreach(string role in roles)
            {
                if (role== "MedicoCabecera")
                {
                    isMedicoCabecera = true;
                }
            }

            return isMedicoCabecera;
        }

        public async Task<ListResultDto<PacienteDto>> GetAllPacientes()
        {
            var medicoActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.DatosPersonales)
                .Where(pacientes=> pacientes.MiMedicoCabecera== medicoActual.medico)
                .ToListAsync();
            if (pacientes.Count == 0)
            {
                pacientes = await _pacienteRepository.GetAll()
                    .Include(pacientes => pacientes.DatosPersonales)
                    .ToListAsync();
            }

            return new ListResultDto<PacienteDto>(ObjectMapper.Map<List<PacienteDto>>(pacientes));
        }
        
        public async Task<ListResultDto<PacienteDto>> BuscarPorNumSS(long numSS)
        {
            var pacientes = await _pacienteRepository.GetAll()
                    .Include(pacientes => pacientes.DatosPersonales)
                    .Where(pacientes=> pacientes.NumSeguridadSocial==numSS)
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

        public async Task<MisResponsables> DesasociarResponsable(int id, ResponsableDto responsable)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.MisResponsables)
                    .ThenInclude(pacientes => pacientes.Responsable)
                        .ThenInclude(pacientes => pacientes.DatosPersonales)
                .Where(pacientes => pacientes.Id == id)
                .FirstOrDefaultAsync();

            foreach (PacienteResponsable respon in pacientes.MisResponsables)
            {
                if (respon.Responsable.DatosPersonales.UserName.Equals(responsable.DatosPersonalesUserName))
                {
                    respon.IsDeleted = true;
                }
            }

            await _pacienteRepository.UpdateAsync(pacientes);

            return ObjectMapper.Map<MisResponsables>(pacientes);
        }

        public async Task<MisResponsables> BuscarResponsableByUserName(int user, string userName)
        {

            var pacientes = await _pacienteRepository.GetAll()
                .Include(p => p.DatosPersonales)
                .Include(pacientes => pacientes.MisResponsables)
                    .ThenInclude(pacientes => pacientes.Responsable)
                        .ThenInclude(pacientes => pacientes.DatosPersonales)
                .Where(pacientes => pacientes.Id == user)
                .FirstOrDefaultAsync();

            List<PacienteResponsable> misResponsables = new List<PacienteResponsable>();

            foreach (PacienteResponsable miResponsableDto in pacientes.MisResponsables)
            {
                if (miResponsableDto.Responsable.DatosPersonales.UserName == userName)
                {
                    misResponsables.Add(miResponsableDto);
                }
            }

            MisResponsables responsables = new MisResponsables();
            responsables.Responsables = ObjectMapper.Map<List<PacienteMiResponsableDto>>(misResponsables);
            responsables.NumSeguridadSocial = pacientes.NumSeguridadSocial;
            responsables.PacienteDatosPersonalesFullName = pacientes.DatosPersonales.FullName;


            return responsables;
        }


        public async Task<ListResultDto<MisEnfermedades>> GetMisEnfermedades(int Id)
        {
            var medicos = await _pacienteRepository.GetAll()
                .Include(p => p.MisEnfermedades)
                    .ThenInclude(p => p.Enfermedad)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<MisEnfermedades>(ObjectMapper.Map<List<MisEnfermedades>>(medicos));
        }


        public async Task<MiEvolucionTemperatura>  GetEvoluciondeTemperatura(int Id)
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


            foreach (ControlTemperatura control in temperaturas.ControlTemperatura)
            {
                if (control.Fecha.Date.Equals(fecha.Date))
                {
                    // temp.ControlTemperatura.Remove(temp.ControlTemperatura.ElementAt(i));
                    temp.Add(control);
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


    }
}
