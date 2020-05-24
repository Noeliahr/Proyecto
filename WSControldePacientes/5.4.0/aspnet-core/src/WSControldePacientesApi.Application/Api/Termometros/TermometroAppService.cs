using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ApiControldePacientes.ControlPacientes.Termometros;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Termometros.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControlPacientesApi.ControlPacienteApi.Termometros.Dto;

namespace WSControldeTermometrosApi.Api.Termometros
{
    [AbpAuthorize(PermissionNames.Pages_Termometros)]
    public class TermometroAppService : AsyncCrudAppService <Termometro, TermometroDto, int,PagedTermometroResultRequest, TermometroDto, TermometroDto>
    {
        private readonly IRepository<Termometro> _termometroRepository;

        private readonly UserManager _userManager;

        public TermometroAppService(IRepository<Termometro> repository, UserManager userManager) : base(repository)
        {
            _termometroRepository = repository;
            _userManager = userManager;
        }
    }
}
