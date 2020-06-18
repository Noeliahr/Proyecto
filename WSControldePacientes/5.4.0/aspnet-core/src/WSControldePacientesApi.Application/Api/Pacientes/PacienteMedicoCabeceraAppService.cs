using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using AutoMapper;
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
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControldePacientesApi.ControlPacientes.Responsables;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControlPacientesApi.Authorization.ControlPacienteApi.Pacientes
{
    [AbpAuthorize(PermissionNames.Pages_PacienteMC)]
    public class PacienteMedicoCabeceraAppService : ApplicationService /*: AsyncCrudAppService<Paciente, PacienteDto, int, PagedPacienteResultRequestDto, CreatePacienteDto, EditPacienteDto>*/
    {
        private readonly IRepository<Paciente> _pacienteRepository;

        private readonly UserManager _userManager;

        public PacienteMedicoCabeceraAppService(IRepository<Paciente> repository, UserManager userManager)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
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

        public async Task<ListResultDto<UserNameMedicosCabecera>> GetAllMedicosCabecera()
        {
            var medicos = await _userManager.GetUsersInRoleAsync("MedicoCabecera");

            return new ListResultDto<UserNameMedicosCabecera>(ObjectMapper.Map<List<UserNameMedicosCabecera>>(medicos));
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
