using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Extensions;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Citas.Dto;
using WSControldePacientesApi.Api.Medicos.Dto;
using WSControldePacientesApi.Api.Mensajes.Dto;
using WSControldePacientesApi.Authorization;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControlPacientesApi.ControlPacienteApi.Medicos.Dto;

namespace WSControldePacientesApi.Api.Medicos
{
    [AbpAuthorize(PermissionNames.Pages_DatosPersonalesMedico)]
    public class DatosMedicoAppService : ApplicationService
    {
        private IRepository<Medico> _medicoRepository;
        private UserManager _userManager;

        public DatosMedicoAppService(IRepository<Medico> repository, UserManager userManager)
        {
            _medicoRepository = repository;
            _userManager = userManager;
        }

        public async Task<MedicoDto> GetMedico()
        {
            var medicoActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            DateTime today = DateTime.Now;

            var medico = await _medicoRepository.GetAll()
                .Include(m=> m.MisPacientes)
                .Include(m=> m.Agenda)
                .Where(m => m.Id == medicoActual.medicoId)
                .FirstOrDefaultAsync();

            var medicoDto= ObjectMapper.Map<MedicoDto>(medico);

            if (medicoDto.Agenda.Count > 0)
            {
                for (int i=0; i<medicoDto.Agenda.Count; i++)
                {
                    if (medicoDto.Agenda.ElementAt(i).FechaHora.Date != today.Date)
                    {
                        medicoDto.Agenda.Remove(medicoDto.Agenda.ElementAt(i));
                        i--;
                    }
                }
            }
            medicoDto.TotalCitasHoy = medicoDto.Agenda.Count();


            return medicoDto;
        }

        public async Task<MedicoDto> UpdateAsync(EditMedicoDto input)
        {

            var medico = ObjectMapper.Map<Medico>(input);


            var user = await _userManager.FindByNameAsync(input.DatosPersonalesUserName);

            user.UserName = input.DatosPersonalesUserName;
            user.Name = input.DatosPersonalesName;
            user.Surname = input.DatosPersonalesSurname;
            user.Telefono = input.DatosPersonalesTelefono;
            user.EmailAddress = input.DatosPersonalesEmailAddress;

            medico.DatosPersonales = user;

            await _medicoRepository.UpdateAsync(medico);

            return ObjectMapper.Map<MedicoDto>(medico);
        }
    }
}
