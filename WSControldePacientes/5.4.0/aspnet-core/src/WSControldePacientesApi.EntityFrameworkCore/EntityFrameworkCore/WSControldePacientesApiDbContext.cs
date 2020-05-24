using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WSControldePacientesApi.Authorization.Roles;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.MultiTenancy;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControldePacientesApi.ControlPacientes.Citas;
using ApiControldePacientes.ControlPacientes.Termometros;
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
using WSControldePacientesApi.ControlPacientes.ControlTemperaturas;

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

        public DbSet<ControlTemperatura> temperaturaPacientes { get; set; }

        public DbSet<Termometro> termometros { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Herencia de User para Paciente / Medico / Responsable
            modelBuilder.Entity<User>()
                .HasOne<Paciente>()
                .WithOne(p => p.DatosPersonales);

            modelBuilder.Entity<User>()
                .HasOne<Medico>()
                .WithOne(m => m.DatosPersonales);

            modelBuilder.Entity<User>()
                .HasOne<Responsable>()
                .WithOne(r => r.DatosPersonales);


            //Relaciones de Paciente => MedicoDeCabecera / Direccion / Termometro
            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.MiMedicoCabecera)
                .WithMany(m => m.MisPacientes)
                .HasForeignKey(p=> p.MiMedicoCabeceraId);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.DondeVive)
                .WithMany(d => d.pacientes)
                .HasForeignKey(p=> p.DondeViveId);

            modelBuilder.Entity<Termometro>()
                .HasOne<Paciente>()
                .WithOne(p => p.Termometro);

            //Relacion de Cita => Direccion / Paciente / Medico
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Direccion)
                .WithMany(d =>d.citas)
                .HasForeignKey(c=> c.DireccionId);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.MisCitasMedicas)
                .HasForeignKey(c=> c.PacienteId);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Agenda)
                .HasForeignKey(c=> c.MedicoId);


            //Relacion de Enfermedad con Paciente
            modelBuilder.Entity<EnfermedadPaciente>()
                .HasOne(ep => ep.Paciente)
                .WithMany(p => p.MisEnfermedades)
                .HasForeignKey(ep=> ep.PacienteId);

            modelBuilder.Entity<EnfermedadPaciente>()
                .HasOne(ep => ep.Enfermedad)
                .WithMany(e => e.enfermedadPacientes)
                .HasForeignKey(ep=>ep.EnfermedadId);


            //Relacion de Prescripcion => Paciente / Medicamento
            modelBuilder.Entity<Prescripcion>()
                .HasOne(pr => pr.Medicamento)
                .WithMany(m => m.prescripciones)
                .HasForeignKey(pr=> pr.MedicamentoId);

            modelBuilder.Entity<Prescripcion>()
                .HasOne(pr => pr.Paciente)
                .WithMany(p => p.MisPrescripciones)
                .HasForeignKey(pr=> pr.PacienteId);


            //Relacion de Recordatorios => Prescripcion
            modelBuilder.Entity<Recordatorio>()
                .HasOne(r => r.Prescripcion)
                .WithMany(pr => pr.recordatorios)
                .HasForeignKey(r => r.PrescripcionId);


            //Relacion de ControlTemperaturas => Paciente
            modelBuilder.Entity<ControlTemperatura>()
                .HasOne(ct => ct.Paciente)
                .WithMany(p => p.ControlTemperatura)
                .HasForeignKey(ct => ct.PacienteId);


            //Relacion de Pacientes con Responsables
            modelBuilder.Entity<PacienteResponsable>()
                .HasOne(pr => pr.Paciente)
                .WithMany(p => p.MisResponsables)
                .HasForeignKey(pr => pr.PacienteId);

            modelBuilder.Entity<PacienteResponsable>()
                .HasOne(pr => pr.Responsable)
                .WithMany(r => r.MisPacientes)
                .HasForeignKey(pr => pr.ResponsableId);


            //Relacion de Mensajes => UserOrigen / UserDestino
            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.PersonaOrigen)
                .WithMany(u => u.MensajesEnviados)
                .HasForeignKey(m => m.PersonaOrigenId);

            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.PersonaDestino)
                .WithMany(u => u.MensajesRecibidos)
                .HasForeignKey(m => m.PersonaDestinoId);


        }

    }
}
