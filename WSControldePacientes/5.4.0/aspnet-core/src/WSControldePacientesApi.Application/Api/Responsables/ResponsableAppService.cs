using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Responsables;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControldePacientesApi.Api.Responsables
{
    public class ResponsableAppService : AsyncCrudAppService<Responsable, ResponsableDto, int, PagedResponsableResultRequestDto, ResponsableDto, ResponsableDto>
    {
        private readonly IRepository<Responsable> _pacienteRepository;

        private readonly UserManager _userManager;

        public ResponsableAppService(IRepository<Responsable> repository, UserManager userManager) : base(repository)
        {
            _pacienteRepository = repository;
            _userManager = userManager;
        }


    }

}
