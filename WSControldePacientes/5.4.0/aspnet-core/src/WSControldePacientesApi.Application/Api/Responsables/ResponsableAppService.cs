using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Extensions;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Responsables;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControldePacientesApi.Api.Responsables
{
    public class ResponsableAppService : ApplicationService
    {
        private readonly IRepository<Responsable> _responsableRepository;

        private readonly UserManager _userManager;

        public ResponsableAppService(IRepository<Responsable> repository, UserManager userManager) 
        {
            _responsableRepository = repository;
            _userManager = userManager;
        }

        public async Task<ResponsableDto> CreateAsync(CreateResponsableDto input)
        {
            User user = new User();
            user.UserName = input.DatosPersonalesUserName;
            user.Name = input.DatosPersonalesName;
            user.Surname = input.DatosPersonalesSurname;
            user.Telefono = input.DatosPersonalesTelefono;
            user.EmailAddress = input.DatosPersonalesEmailAddress;

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            string[] roles = new string[1];
            roles[0] = "Responsable";

            CheckErrors(await _userManager.CreateAsync(user, input.DatosPersonalesPassword));

            CheckErrors(await _userManager.SetRolesAsync(user, roles));
            CurrentUnitOfWork.SaveChanges();

            var responsable = ObjectMapper.Map<Responsable>(input);
            responsable.DatosPersonales = user;

            await _responsableRepository.InsertAsync(responsable);
            
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<ResponsableDto>(responsable);
        }


        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }


        public async Task<ListResultDto<ResponsableDto>> GetAll(int [] ids)
        {
            var responsables = await _responsableRepository.GetAll()
                .Include(r=> r.DatosPersonales)
                .ToListAsync();

            List<Responsable> enfers = new List<Responsable>();
            enfers = responsables;

            for (int i = 1; i < ids.Length; i++)
            {
                for (int j = 0; j < responsables.Count; j++)
                {
                    if (responsables.ElementAt(j).Id == ids[i])
                    {
                        enfers.RemoveAt(j);
                        j--;
                    }
                }
            }

            return new ListResultDto<ResponsableDto>(ObjectMapper.Map<List<ResponsableDto>>(enfers));
        }


        public async Task<ListResultDto<ResponsableDto>> BuscarByUserNameOrName(string name)
        {
            var responsables = await _responsableRepository.GetAll()
                .Include(r=> r.DatosPersonales)
                .Where(r=> r.DatosPersonales.UserName==name)
                .ToListAsync();

            

            return new ListResultDto<ResponsableDto>(ObjectMapper.Map<List<ResponsableDto>>(responsables));
        }
    }

}
