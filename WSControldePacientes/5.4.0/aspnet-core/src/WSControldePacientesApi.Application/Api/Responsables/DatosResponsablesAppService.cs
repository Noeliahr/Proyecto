using Abp.Application.Services;
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
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Responsables;

namespace WSControldePacientesApi.Api.Responsables
{
    public class DatosResponsablesAppService : ApplicationService
    {
        private IRepository<Responsable> _responsableRepository;
        private UserManager _userManager;

        public DatosResponsablesAppService(IRepository<Responsable> repository, UserManager userManager)
        {
            _responsableRepository = repository;
            _userManager = userManager;
        }

        public async Task<DatosResponsableDto> GetDatos()
        {
            var responsableActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var responsable = await _responsableRepository.GetAll()
                .Include(r => r.MisPacientes)
                .Where(r => r.DatosPersonales == responsableActual)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<DatosResponsableDto>(responsable);
        }


        public async Task<ResponsableDto> UpdateAsync(EditResponsableDto input)
        {

            var responsable = ObjectMapper.Map<Responsable>(input);


            var user = await _userManager.FindByNameAsync(input.DatosPersonalesUserName);

            user.UserName = input.DatosPersonalesUserName;
            user.Name = input.DatosPersonalesName;
            user.Surname = input.DatosPersonalesSurname;
            user.Telefono = input.DatosPersonalesTelefono;
            user.EmailAddress = input.DatosPersonalesEmailAddress;

            responsable.DatosPersonales = user;

            await _responsableRepository.UpdateAsync(responsable);

            return ObjectMapper.Map<ResponsableDto>(responsable);
        }
    }
}
