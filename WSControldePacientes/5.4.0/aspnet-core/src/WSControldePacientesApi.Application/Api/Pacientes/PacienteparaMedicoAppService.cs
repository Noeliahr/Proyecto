using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Pacientes.Dto;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControldePacientesApi.Api.Pacientes
{
    [AbpAuthorize(PermissionNames.Pages_PacienteMedico)]
    public class PacienteparaMedicoAppService : ApplicationService
    {
        private readonly IRepository<Paciente> _pacienteRepository;

        private readonly UserManager _userManager;

        public PacienteparaMedicoAppService(IRepository<Paciente> repository, UserManager userManager)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<PacienteDto>> GetAll()
        {
            var citas = await _pacienteRepository.GetAll()
                .Include(c => c.DatosPersonales)
                .ToListAsync();

            return new ListResultDto<PacienteDto>(ObjectMapper.Map<List<PacienteDto>>(citas));
        }


        public async Task<ListResultDto<PacienteCompletoDto>> MasDetalles(int id)
        {
            var citas = await _pacienteRepository.GetAll()
                .Include(p => p.DatosPersonales)
                .Include(p=> p.DondeVive)
                .Include(p=> p.Termometro)
                .Include(p=> p.MiMedicoCabecera)
                    .ThenInclude(p=> p.DatosPersonales)
                .Where(p=> p.Id == id)
                .ToListAsync();

            return new ListResultDto<PacienteCompletoDto>(ObjectMapper.Map<List<PacienteCompletoDto>>(citas));
        }


        public async Task<ListResultDto<MisResponsables>> SusResponsables(int id)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.MisResponsables)
                    .ThenInclude(pacientes => pacientes.Responsable)
                        .ThenInclude(pacientes => pacientes.DatosPersonales)
                .Where(pacientes => pacientes.Id == id)
                .ToListAsync();
            return new ListResultDto<MisResponsables>(ObjectMapper.Map<List<MisResponsables>>(pacientes));
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
                if (respon.Responsable.Equals(responsable))
                {
                    respon.IsDeleted = false;
                }
            }

            await _pacienteRepository.UpdateAsync(pacientes);

            return ObjectMapper.Map<MisResponsables>(pacientes);
        }


        public async Task<ListResultDto<MisEnfermedades>> SusEnfermedades(int Id)
        {
            var medicos = await _pacienteRepository.GetAll()
                .Include(p => p.MisEnfermedades)
                    .ThenInclude(p => p.Enfermedad)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<MisEnfermedades>(ObjectMapper.Map<List<MisEnfermedades>>(medicos));
        }

        public async Task<ListResultDto<MiEvolucionTemperatura>> EvoluciondeTemperatura(int Id)
        {
            var temperaturas = await _pacienteRepository.GetAll()
                .Include(p => p.ControlTemperatura)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<MiEvolucionTemperatura>(ObjectMapper.Map<List<MiEvolucionTemperatura>>(temperaturas));
        }

        public async Task<ListResultDto<MiEvolucionTemperatura>> EvoluciondeTemperaturaByFecha(int Id, DateTime fecha)
        {
            var temperaturas = await _pacienteRepository.GetAll()
                .Include(p => p.ControlTemperatura)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();


            for (int i = 0; i < temperaturas.ControlTemperatura.Count; i++)
            {
                if (!temperaturas.ControlTemperatura.ElementAt(i).Fecha.Equals(fecha))
                {
                    temperaturas.ControlTemperatura.Remove(temperaturas.ControlTemperatura.ElementAt(i));
                }
            }

            return new ListResultDto<MiEvolucionTemperatura>(ObjectMapper.Map<List<MiEvolucionTemperatura>>(temperaturas));
        }


        public async Task<ListResultDto<PacienteCompletoDto>> GetDatosCompletosByPaciente(int Id)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(p => p.DatosPersonales)
                .Include(p => p.DondeVive)
                .Include(p => p.Termometro)
                .Include(p => p.MiMedicoCabecera)
                    .ThenInclude(p => p.DatosPersonales)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<PacienteCompletoDto>(ObjectMapper.Map<List<PacienteCompletoDto>>(pacientes));
        }



    }
}
