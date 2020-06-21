using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Mensajes;

namespace WSControldePacientesApi.Termometro
{
    public class MandarFiebre : ApplicationService
    {
        private IRepository<Mensaje> _mensajeRepository;
        private UserManager _userManager;

        public MandarFiebre(IRepository<Mensaje> repository, UserManager user)
        {
            _mensajeRepository = repository;
            _userManager = user;
        }

        public async Task<bool> Notificar(string personaDestino, string texto) {

            var personaOrigen = await _userManager.FindByNameOrEmailAsync("Notificaciones");

            var destino = await _userManager.FindByNameOrEmailAsync(personaDestino);

            Mensaje mensaje = new Mensaje();
            mensaje.PersonaOrigen = personaOrigen;
            mensaje.PersonaDestino = destino;
            mensaje.Texto = texto;
            mensaje.Fecha = DateTime.Now;

            await _mensajeRepository.InsertAsync(mensaje);

            CurrentUnitOfWork.SaveChanges();

            return true;

        }

    }
}
