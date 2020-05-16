using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControlPacientesApi.Authorization.ControlPacienteApi.Pacientes
{
    [AbpAuthorize(PermissionNames.Pages_Pacientes)]
    public class PacientesAppService : AsyncCrudAppService<Paciente, PacienteDto, int, PagedPacienteResultRequestDto, CreatePacienteDto, PacienteDto>
    {
        private readonly IRepository<Paciente> _pacienteRepository;

        private readonly UserManager _userManager;

        public PacientesAppService(IRepository<Paciente> repository, UserManager userManager) : base(repository)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<PacienteDto>> GetAllPacientes()
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.DatosPersonales)
                .Include(pacientes => pacientes.Termometro).ToListAsync();
            return new ListResultDto<PacienteDto>(ObjectMapper.Map<List<PacienteDto>>(pacientes));
        }

        public async Task<ListResultDto<MisResponsables>> GetMisResponsables(int id)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.MisResponsables)
                    .ThenInclude(pacientes => pacientes.Responsable)
                        .ThenInclude(pacientes => pacientes.DatosPersonales)
                .Where(pacientes => pacientes.Id == id)
                .ToListAsync();
            return new ListResultDto<MisResponsables>(ObjectMapper.Map<List<MisResponsables>>(pacientes));
        }


        public async Task<MisResponsables> AsociarResponsables(int id, ResponsableDto responsable)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.MisResponsables)
                    .ThenInclude(pacientes => pacientes.Responsable)
                        .ThenInclude(pacientes => pacientes.DatosPersonales)
                .Where(pacientes => pacientes.Id == id)
                .FirstOrDefaultAsync();

            PacienteResponsableDto pacienteResponsableDto = new PacienteResponsableDto();
            pacienteResponsableDto.Paciente = ObjectMapper.Map<PacienteDto>(pacientes);
            pacienteResponsableDto.Responsable = responsable;

            pacientes.MisResponsables.Add(ObjectMapper.Map<PacienteResponsable>(pacienteResponsableDto));

            await _pacienteRepository.UpdateAsync(pacientes);

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
                if (respon.Responsable.Equals(responsable))
                {
                    respon.IsDeleted = false;
                }
            }

            await _pacienteRepository.UpdateAsync(pacientes);

            return ObjectMapper.Map<MisResponsables>(pacientes);
        }


        //public async Task<ListResultDto<MisMedicosDto>> GetMisMedicos(int Id)
        //{
        //    var medicos = await _pacienteRepository.GetAll()
        //        .Include(p => p.MisMedicos)
        //            .ThenInclude(p => p.Medico)
        //                .ThenInclude(p=> p.Persona)
        //        .Where(p => p.Id == Id)
        //        .ToListAsync();

        //    return new ListResultDto<MisMedicosDto>(ObjectMapper.Map<List<MisMedicosDto>>(medicos));
        //}


        public async Task<ListResultDto<MisEnfermedades>> GetMisEnfermedades(int Id)
        {
            var medicos = await _pacienteRepository.GetAll()
                .Include(p => p.MisEnfermedades)
                    .ThenInclude(p => p.Enfermedad)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<MisEnfermedades>(ObjectMapper.Map<List<MisEnfermedades>>(medicos));
        }


        //public override async Task<PacienteDto> UpdateAsync(PacienteDto input)
        //{
        //    CheckUpdatePermission();

        //    var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

        //    var paciente = await _pacienteRepository.GetAll()
        //        .Where(paciente => paciente.Id == input.Id)
        //        .FirstOrDefaultAsync();

        //    paciente = ObjectMapper.Map<Paciente>(input);

        //    await _pacienteRepository.UpdateAsync(paciente);

        //    return ObjectMapper.Map<PacienteDto>(paciente);

        //}

        public async Task<ListResultDto<MisDirecciones>> GetMisDirecciones(int Id)
        {
            var direcciones = await _pacienteRepository.GetAll()
                .Include(p => p.DatosPersonales)
                //.ThenInclude(p => p.Ubicaciones)
                //.ThenInclude(P=>P.Direccion)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<MisDirecciones>(ObjectMapper.Map<List<MisDirecciones>>(direcciones));
        }


        public async Task<ListResultDto<MiEvolucionTemperatura>> GetEvoluciondeTemperatura(int Id)
        {
            var temperaturas = await _pacienteRepository.GetAll()
                .Include(p => p.Control_de_Temperatura)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<MiEvolucionTemperatura>(ObjectMapper.Map<List<MiEvolucionTemperatura>>(temperaturas));
        }

        public async Task<ListResultDto<MiEvolucionTemperatura>> GetEvoluciondeTemperaturaByFecha(int Id, DateTime fecha)
        {
            var temperaturas = await _pacienteRepository.GetAll()
                .Include(p => p.Control_de_Temperatura)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();


            for (int i = 0; i < temperaturas.Control_de_Temperatura.Count; i++)
            {
                if (!temperaturas.Control_de_Temperatura.ElementAt(i).Fecha.Equals(fecha))
                {
                    temperaturas.Control_de_Temperatura.Remove(temperaturas.Control_de_Temperatura.ElementAt(i));
                }
            }

            return new ListResultDto<MiEvolucionTemperatura>(ObjectMapper.Map<List<MiEvolucionTemperatura>>(temperaturas));
        }

    }
}
