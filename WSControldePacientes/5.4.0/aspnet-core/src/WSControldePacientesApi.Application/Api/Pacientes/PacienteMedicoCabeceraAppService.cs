using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using ApiControldePacientes.ControlPacientes.Termometros;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Pacientes.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControldePacientesApi.ControlPacientes.Responsables;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControlPacientesApi.Authorization.ControlPacienteApi.Pacientes
{
    [AbpAuthorize(PermissionNames.Pages_PacientesMedicoCabecera)]
    public class PacienteMedicoCabeceraAppService : ApplicationService /*: AsyncCrudAppService<Paciente, PacienteDto, int, PagedPacienteResultRequestDto, CreatePacienteDto, EditPacienteDto>*/
    {
        private readonly IRepository<Paciente> _pacienteRepository;

        private readonly UserManager _userManager;

        public PacienteMedicoCabeceraAppService(IRepository<Paciente> repository, UserManager userManager)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<PacienteDto>> GetAllPacientes()
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(pacientes => pacientes.DatosPersonales)
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
                if (respon.Responsable.DatosPersonales.UserName.Equals(responsable.ResponsableDatosPersonalesUserName))
                {
                    respon.IsDeleted = true;
                }
            }

            await _pacienteRepository.UpdateAsync(pacientes);

            return ObjectMapper.Map<MisResponsables>(pacientes);
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



        public async Task<ListResultDto<MiEvolucionTemperatura>> GetEvoluciondeTemperatura(int Id)
        {
            var temperaturas = await _pacienteRepository.GetAll()
                .Include(p => p.ControlTemperatura)
                .Where(p => p.Id == Id)
                .ToListAsync();

            return new ListResultDto<MiEvolucionTemperatura>(ObjectMapper.Map<List<MiEvolucionTemperatura>>(temperaturas));
        }

        public async Task<ListResultDto<MiEvolucionTemperatura>> GetEvoluciondeTemperaturaByFecha(int Id, DateTime fecha)
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


        public async Task<PacienteCompletoDto> GetDatosCompletosByPaciente(int Id)
        {
            var pacientes = await _pacienteRepository.GetAll()
                .Include(p => p.DatosPersonales)
                .Include(p => p.DondeVive)
                .Include(p => p.Termometro)
                .Include(p => p.MiMedicoCabecera)
                    .ThenInclude(p => p.DatosPersonales)
                .Where(p => p.Id == Id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<PacienteCompletoDto>(pacientes);
        }

        public async Task<ListResultDto<UserNameMedicosCabecera>> GetAllMedicosCabecera()
        {
            var medicos = await _userManager.GetUsersInRoleAsync("MedicoCabecera");

            return new ListResultDto<UserNameMedicosCabecera>(ObjectMapper.Map<List<UserNameMedicosCabecera>>(medicos));
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<PacienteDto> CreateAsync(CreatePacienteDto input)
        {
            var UsermedicoCabecera = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            User user = new User();
            user.UserName = input.DatosPersonalesUserName;
            user.Name = input.DatosPersonalesName;
            user.Surname = input.DatosPersonalesSurname;
            user.Telefono = input.DatosPersonalesTelefono;
            user.EmailAddress = input.DatosPersonalesEmailAddress;

            string[] roles = new string[1];
            roles[0] = "Paciente";



            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.DatosPersonalesPassword));

            CheckErrors(await _userManager.SetRolesAsync(user, roles));


            CurrentUnitOfWork.SaveChanges();

            var paciente = ObjectMapper.Map<Paciente>(input);
            paciente.DatosPersonales = user;
            paciente.MiMedicoCabeceraId = UsermedicoCabecera.medicoId.Value;

            await _pacienteRepository.InsertAsync(paciente);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<PacienteDto>(paciente);
        }


        public async Task<PacienteDto> UpdateAsync(EditPacienteDto input)
        {
            var UsermedicoCabecera = await _userManager.FindByNameAsync(input.MedicoCabeceraUserName);

            var paciente = ObjectMapper.Map<Paciente>(input);


            var user = await _userManager.FindByNameAsync(input.DatosPersonalesUserName);

            user.UserName = input.DatosPersonalesUserName;
            user.Name = input.DatosPersonalesName;
            user.Surname = input.DatosPersonalesSurname;
            user.Telefono = input.DatosPersonalesTelefono;
            user.EmailAddress = input.DatosPersonalesEmailAddress;

            //CheckErrors(await _userManager.UpdateAsync(user));


            paciente.DatosPersonales = user;
            paciente.MiMedicoCabeceraId= UsermedicoCabecera.medicoId.Value;

            await _pacienteRepository.UpdateAsync(paciente);

            return ObjectMapper.Map<PacienteDto>(paciente);
        }

        public async Task Delete (int id)
        {
            var paciente = _pacienteRepository.Get(id);
            await _pacienteRepository.DeleteAsync(paciente);
        }
    }

}
