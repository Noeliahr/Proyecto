using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace WSControldePacientesApi.Authorization
{
    public class WSControldePacientesApiAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            //context.CreatePermission(PermissionNames.Pages_CitasMedico, L("Agenda"));
            //context.CreatePermission(PermissionNames.Pages_CitasPaciente, L("Citas"));
            //context.CreatePermission(PermissionNames.Pages_Citas, L("PacienteCita"));
            //context.CreatePermission(PermissionNames.Pages_Direcciones, L("Direcciones"));
            //context.CreatePermission(PermissionNames.Pages_Enfermedades, L("Enfermedades"));
            //context.CreatePermission(PermissionNames.Pages_EnfermedadesPacientes, L("EnfermedadesDePacientes"));
            //context.CreatePermission(PermissionNames.Pages_Medicamentos, L("Medicamentos"));
            //context.CreatePermission(PermissionNames.Pages_Medicos, L("Medicos"));
            //context.CreatePermission(PermissionNames.Pages_DatosMedico, L("DatosMedicos"));
            //context.CreatePermission(PermissionNames.Pages_Mensajes, L("Mensajes"));
            //context.CreatePermission(PermissionNames.Pages_PacientesMedicoCabecera, L("MedicoCabecera"));
            //context.CreatePermission(PermissionNames.Pages_PacientesMedico, L("Medico"));
            //context.CreatePermission(PermissionNames.Pages_Pacientes, L("Pacientes"));
            //context.CreatePermission(PermissionNames.Pages_PacienteResponsables, L("ResponsablesPaciente"));
            //context.CreatePermission(PermissionNames.Pages_PrescripcionesMedico, L("Recetas"));
            //context.CreatePermission(PermissionNames.Pages_Prescripciones, L("Prescripciones"));
            //context.CreatePermission(PermissionNames.Pages_Recordatorios, L("Recordatorios"));
            //context.CreatePermission(PermissionNames.Pages_Responsables, L("Responsables"));
            //context.CreatePermission(PermissionNames.Pages_DatosResponsables, L("DatosResponsables"));
            //context.CreatePermission(PermissionNames.Pages_TemperaturasPacientes, L("ControlPacientes"));
            //context.CreatePermission(PermissionNames.Pages_Termometros, L("Termometros"));


            //para el paciente
            context.CreatePermission(PermissionNames.Pages_DatosPersonalesPaciente, L("DatosPersonalesPaciente"));
            context.CreatePermission(PermissionNames.Pages_MisCitas, L("MisCitas"));
            context.CreatePermission(PermissionNames.Pages_MisResponsables, L("MisResponsables"));
            context.CreatePermission(PermissionNames.Pages_MisRecordatorios, L("MisRercodatorios"));
            context.CreatePermission(PermissionNames.Pages_MisEnfermedades, L("MisEnfermedades"));
            context.CreatePermission(PermissionNames.Pages_Chat, L("Chat"));
            context.CreatePermission(PermissionNames.Pages_MiControldeTemperatura, L("MiControldeTemperatura"));
            context.CreatePermission(PermissionNames.Pages_MisPrescripciones, L("MisPrescripciones"));

            //para el medico
            context.CreatePermission(PermissionNames.Pages_DatosPersonalesMedico, L("DatosPersonalesMedico"));
            context.CreatePermission(PermissionNames.Pages_PacienteMedico, L("PacienteMedico"));
            context.CreatePermission(PermissionNames.Pages_PacienteMC, L("PacienteMC"));
            context.CreatePermission(PermissionNames.Pages_Agenda, L("Agenda"));
            context.CreatePermission(PermissionNames.Pages_CitasPaciente, L("CitasPaciente"));
            context.CreatePermission(PermissionNames.Pages_Responsables, L("Responsables"));
            context.CreatePermission(PermissionNames.Pages_Recordatorios, L("Recordatorios"));
            context.CreatePermission(PermissionNames.Pages_EnfermedadesPaciente, L("EnfermedadesPaciente"));
            context.CreatePermission(PermissionNames.Pages_ControldeTemperatura, L("ControldeTemperatura"));
            context.CreatePermission(PermissionNames.Pages_Prescripciones, L("Prescripciones"));

            //para el responsable
            context.CreatePermission(PermissionNames.Pages_DatosPersonalesResponsable, L("DatosPersonalesResponsable"));
            context.CreatePermission(PermissionNames.Pages_MisPacientes, L("MisPacientes"));
            context.CreatePermission(PermissionNames.Pages_SusCitas, L("SusCitas"));
            context.CreatePermission(PermissionNames.Pages_SusResponsables, L("SusResponsables"));
            context.CreatePermission(PermissionNames.Pages_SusEnfermedades, L("SusEnfermedades"));
            context.CreatePermission(PermissionNames.Pages_SusPrescripciones, L("SusPrescripciones"));


            context.CreatePermission(PermissionNames.Pages_Medicos, L("Medicos"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WSControldePacientesApiConsts.LocalizationSourceName);
        }
    }
}
