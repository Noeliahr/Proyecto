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

            context.CreatePermission(PermissionNames.Pages_CitasMedico, L("Agenda"));
            context.CreatePermission(PermissionNames.Pages_CitasPaciente, L("Citas"));
            context.CreatePermission(PermissionNames.Pages_Direcciones, L("Direcciones"));
            context.CreatePermission(PermissionNames.Pages_Enfermedades, L("Enfermedades"));
            context.CreatePermission(PermissionNames.Pages_EnfermedadesPacientes, L("EnfermedadesDePacientes"));
            context.CreatePermission(PermissionNames.Pages_Medicamentos, L("Medicamentos"));
            context.CreatePermission(PermissionNames.Pages_Medicos, L("Medicos"));
            context.CreatePermission(PermissionNames.Pages_DatosMedico, L("DatosMedicos"));
            context.CreatePermission(PermissionNames.Pages_Mensajes, L("Mensajes"));
            context.CreatePermission(PermissionNames.Pages_PacientesMedicoCabecera, L("MedicoCabecera"));
            context.CreatePermission(PermissionNames.Pages_PacientesMedico, L("Medico"));
            context.CreatePermission(PermissionNames.Pages_Pacientes, L("Pacientes"));
            context.CreatePermission(PermissionNames.Pages_PacienteResponsables, L("ResponsablesPaciente"));
            context.CreatePermission(PermissionNames.Pages_PrescripcionesMedico, L("Recetas"));
            context.CreatePermission(PermissionNames.Pages_Prescripciones, L("Prescripciones"));
            context.CreatePermission(PermissionNames.Pages_Recordatorios, L("Recordatorios"));
            context.CreatePermission(PermissionNames.Pages_Responsables, L("Responsables"));
            context.CreatePermission(PermissionNames.Pages_DatosResponsables, L("DatosResponsables"));
            context.CreatePermission(PermissionNames.Pages_TemperaturasPacientes, L("ControlPacientes"));
            context.CreatePermission(PermissionNames.Pages_Termometros, L("Termometros"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WSControldePacientesApiConsts.LocalizationSourceName);
        }
    }
}
