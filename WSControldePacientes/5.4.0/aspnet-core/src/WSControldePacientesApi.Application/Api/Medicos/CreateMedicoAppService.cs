using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Medicos.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Medicos;

namespace WSControldePacientesApi.Api.Medicos
{
    [AbpAuthorize(PermissionNames.Pages_Medicos)]
    public class CreateMedicoAppService : ApplicationService
    {
        private IRepository<Medico> _repository;
        private UserManager _userManager;

        public CreateMedicoAppService(IRepository<Medico> repository, UserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task Create (CreateMedicoDto createMedicoDto)
        {
            User user = new User();
            user.UserName = createMedicoDto.DatosPersonalesUserName;
            user.Name = createMedicoDto.DatosPersonalesName;
            user.Surname = createMedicoDto.DatosPersonalesSurname;
            user.Telefono = createMedicoDto.DatosPersonalesTelefono;
            user.EmailAddress = createMedicoDto.DatosPersonalesEmailAddress;

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);


            CheckErrors(await _userManager.CreateAsync(user, createMedicoDto.DatosPersonalesPassword));

            if (createMedicoDto.DatosPersonalesRoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, createMedicoDto.DatosPersonalesRoleNames));
            }

            CurrentUnitOfWork.SaveChanges();


            var medico = ObjectMapper.Map<Medico>(createMedicoDto);
            await _repository.InsertAsync(medico);
            CurrentUnitOfWork.SaveChanges();
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
