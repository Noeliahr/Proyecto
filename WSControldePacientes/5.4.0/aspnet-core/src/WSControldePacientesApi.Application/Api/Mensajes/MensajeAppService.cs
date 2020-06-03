using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Api.Mensajes.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Mensajes;

namespace WSControldePacientesApi.Api.Mensajes
{
    public class MensajeAppService : AsyncCrudAppService<Mensaje, MensajeDto, int, PagedMensajeResultRequestDto, CreateMensajeDto, MensajeDto>
    {
        private IRepository<Mensaje> _mensajeRepository;
        private UserManager _userManager;

        public MensajeAppService(IRepository<Mensaje> repository, UserManager userManager) : base(repository)
        {
            _mensajeRepository = repository;
            _userManager = userManager;
        }

        public override async Task<MensajeDto> CreateAsync(CreateMensajeDto input)
        {
            CheckCreatePermission();
            var personaOrigen = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var personaDestino = await _userManager.FindByNameOrEmailAsync(input.PersonaDestinoUserName);

            var mensaje = ObjectMapper.Map<Mensaje>(input);

            mensaje.PersonaOrigen = personaOrigen;
            mensaje.PersonaDestino = personaDestino;
            mensaje.Fecha = DateTime.Now;

            await _mensajeRepository.InsertAsync(mensaje);

            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(mensaje);
        }

        public async Task<ListResultDto<MensajeSimple>> GetMensaje()
        {

            var personaOrigen = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var mensajes = await _mensajeRepository.GetAll()
                .Include(m => m.PersonaDestino)
                .Include(m => m.PersonaOrigen)
                .Where(m => m.PersonaDestino == personaOrigen || m.PersonaOrigen == personaOrigen)
                .OrderByDescending(m => m.Fecha)
                .ToListAsync();

            List<Mensaje> mensajesAgrupados = new List<Mensaje>();
            string login = "";

            for (int i = 0; i < mensajes.Count; i++)
            {
                if (!mensajes.ElementAt(i).PersonaOrigen.UserName.Equals(personaOrigen.UserName))
                {
                    login = mensajes.ElementAt(i).PersonaOrigen.UserName;
                    mensajesAgrupados.Add(mensajes.ElementAt(i));
                }
                else
                {
                    login = mensajes.ElementAt(i).PersonaDestino.UserName;
                    mensajesAgrupados.Add(mensajes.ElementAt(i));
                }

                for (int j = i+1; j < mensajes.Count; j++)
                {
                    if (mensajes.ElementAt(j).PersonaOrigen.UserName.Equals(login))
                    {
                        mensajes.RemoveAt(j);
                        j--;
                    }
                    else if (mensajes.ElementAt(j).PersonaDestino.UserName.Equals(login))
                    {
                        mensajes.RemoveAt(j);
                        j--;
                    }
                }
            }

            List<MensajeSimple> message = new List<MensajeSimple>();

            for (int i=0; i<mensajesAgrupados.Count; i++)
            {
                if (!mensajes.ElementAt(i).PersonaOrigen.UserName.Equals(personaOrigen.UserName))
                {
                    MensajeSimple mensajeSimple = new MensajeSimple();
                    mensajeSimple.personaId = mensajes.ElementAt(i).PersonaOrigenId;
                    mensajeSimple.personaUserName = mensajes.ElementAt(i).PersonaOrigen.UserName;
                    mensajeSimple.Texto = mensajes.ElementAt(i).Texto;
                    mensajeSimple.fechaHora = mensajes.ElementAt(i).Fecha;
                    message.Add(mensajeSimple);
                }
                else
                {
                    MensajeSimple mensajeSimple = new MensajeSimple();
                    mensajeSimple.personaId = mensajes.ElementAt(i).PersonaDestinoId;
                    mensajeSimple.personaUserName = mensajes.ElementAt(i).PersonaDestino.UserName;
                    mensajeSimple.Texto = mensajes.ElementAt(i).Texto;
                    mensajeSimple.fechaHora = mensajes.ElementAt(i).Fecha;
                    message.Add(mensajeSimple);
                }
            }


            return new ListResultDto<MensajeSimple>(ObjectMapper.Map<List<MensajeSimple>>(message));
        }

        public async Task<ListResultDto<MensajeDto>> GetChat(string userName)
        {
            var personaOrigen = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

            var mensajes = await _mensajeRepository.GetAll()
                .Include(m => m.PersonaDestino)
                .Include(m => m.PersonaOrigen)
                .Where(m => m.PersonaDestino == personaOrigen && m.PersonaOrigen.UserName.Equals(userName) || m.PersonaOrigen == personaOrigen && m.PersonaDestino.UserName.Equals(userName))
                .OrderBy(m => m.Fecha)
                .ToListAsync();

            return new ListResultDto<MensajeDto>(ObjectMapper.Map<List<MensajeDto>>(mensajes));

        }
    }
}
