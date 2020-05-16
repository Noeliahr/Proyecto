using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WSControldePacientesApi.Authorization.Roles;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.MultiTenancy;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControldePacientesApi.ControlPacientes.Citas;
using ApiControldePacientes.ControlPacientes.Termometros;
using WSControldePacientesApi.ControlPacientes.TemperaturasPacientes;
using WSControldePacientesApi.ControlPacientes.Responsables;
using WSControldePacientesApi.ControlPacientes.Recordatorios;
using WSControldePacientesApi.ControlPacientes.Prescripciones;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.Mensajes;
using WSControldePacientesApi.ControlPacientes.Medicamentos;
using WSControldePacientesApi.ControlPacientes.EnfermadesPacientes;
using WSControldePacientesApi.ControlPacientes.Enfermedades;
using WSControldePacientesApi.ControlPacientes.Direcciones;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;

namespace WSControldePacientesApi.EntityFrameworkCore
{
    public class WSControldePacientesApiDbContext : AbpZeroDbContext<Tenant, Role, User, WSControldePacientesApiDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WSControldePacientesApiDbContext(DbContextOptions<WSControldePacientesApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cita> citas { get; set; }

        public DbSet<Direccion> direcciones { get; set; }

        public DbSet<Enfermedad> enfermedades { get; set; }

        public DbSet<Medicamento> medicamentos { get; set; }

        public DbSet<Medico> medicos { get; set; }

        public DbSet<Mensaje> mensajes { get; set; }

        public DbSet<Paciente> pacientes { get; set; }

        public DbSet<Prescripcion> prescripciones { get; set; }

        public DbSet<Recordatorio> recordatorios { get; set; }

        public DbSet<Responsable> responsables { get; set; }

        public DbSet<TemperaturaPaciente> temperaturaPacientes { get; set; }

        public DbSet<Termometro> termometros { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>()
                 .HasOne(paciente => paciente.MiMedicoCabecera)
                 .WithMany(medico => medico.MisPacientes)
                 .HasForeignKey(paciente => paciente.MiMedicoCabeceraId);


            modelBuilder.Entity<EnfermedadPaciente>()
                .HasOne(enfermedadPaciente => enfermedadPaciente.Paciente)
                .WithMany(paciente => paciente.MisEnfermedades)
                .HasForeignKey(enfermedadPaciente => enfermedadPaciente.PacienteId);
            modelBuilder.Entity<EnfermedadPaciente>()
                .HasOne(enfermedadPaciente => enfermedadPaciente.Enfermedad)
                .WithMany(enfermedad => enfermedad.enfermedadPacientes)
                .HasForeignKey(enfermedadPaciente => enfermedadPaciente.EnfermedadId);


            modelBuilder.Entity<Mensaje>()
                .HasOne(mensaje => mensaje.PersonaOrigen)
                .WithMany(user => user.MensajesEnviados)
                .HasForeignKey(mensaje => mensaje.PersonaOrigenId);
            modelBuilder.Entity<Mensaje>()
                .HasOne(mensaje => mensaje.PersonaDestino)
                .WithMany(user => user.MensajesRecibidos)
                .HasForeignKey(mensaje => mensaje.PersonaDestinoId);


            modelBuilder.Entity<Cita>()
               .HasOne(cita => cita.Paciente)
               .WithMany(paciente => paciente.MisCitasMedicas)
               .HasForeignKey(cita => cita.PacienteId);
            modelBuilder.Entity<Cita>()
              .HasOne(cita => cita.Medico)
              .WithMany(medico => medico.Agenda)
              .HasForeignKey(cita => cita.MedicoId);


            modelBuilder.Entity<PacienteResponsable>()
                .HasOne(pacienteResponsable => pacienteResponsable.Paciente)
                .WithMany(paciente => paciente.MisResponsables)
                .HasForeignKey(pacienteResponsable => pacienteResponsable.PacienteId);
            modelBuilder.Entity<PacienteResponsable>()
                .HasOne(pacienteResponsable => pacienteResponsable.Responsable)
                .WithMany(responsable => responsable.MisPacientes)
                .HasForeignKey(pacienteResponsable => pacienteResponsable.ResponsableId);


            modelBuilder.Entity<TemperaturaPaciente>()
                .HasOne(temperaturaPaciente => temperaturaPaciente.Paciente)
                .WithMany(paciente => paciente.Control_de_Temperatura)
                .HasForeignKey(temperaturaPaciente => temperaturaPaciente.PacienteId);


        }

    }
}
