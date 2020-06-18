import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';

import {PerfilPacienteComponent} from './perfil-paciente/perfil-paciente.component';
import {MisResponsablesComponent} from './perfil-paciente/misresponsables/misrespnsables-dialog.component';
import { from } from 'rxjs';
import { MisEnfermedadesComponent } from './perfil-paciente/misenfermedades/misenfermedades.component';
import { MisPrescripcionesComponent } from './perfil-paciente/misprescripciones/misprescripciones.component';
import { MisRecordatoriosComponent } from './perfil-paciente/misrecordatorios/misrecordatorios.component';
import { ChatsComponent } from './chats/chat.component';
import { EvolucionTemperaturaComponent } from './controlesdeTemperatura/evolucion-temperatura/evolucion-temperatura.component';
import { PerfilMedicoComponent } from './perfil-medico/perfil-medico.component';
import { PerfilResponsableComponent } from './perfil-responsable/perfil-responsable.component';
import { MiAgendaComponent } from './perfil-medico/agenda/miagenda.component';
import { CitaPacienteRComponent } from './perfil-responsable/pacientesVistaResponsable/citas-paciente/citas-paciente.component';
import { PacientesComponent } from './perfil-medico/pacientesVistaMedico/pacientes.component';
import { CitaPacienteComponent } from './perfil-medico/pacientesVistaMedico/citas-paciente/citas-paciente.component';
import { MisCitasComponent } from './perfil-paciente/miscitas/miscitas.component';
import { PacientesVistaResponsableComponent } from './perfil-responsable/pacientesVistaResponsable/pacientes.component';
import { ControlpacienteVMComponent } from './controlesdetemperatura/control-pacienteVistaMedico/control-pacienteVM.component';
import { ControlpacienteVRComponent } from './controlesdetemperatura/control-pacienteVistaResponsable/control-pacienteVR.component';
import { EnfermedadesDialogRComponent } from './perfil-responsable/pacientesVistaResponsable/enfermedades-paciente/enfermedades-paciente-dialog.component';
import { EnfermedadesDialogComponent } from './perfil-medico/pacientesVistaMedico/enfermedades-paciente/enfermedades-paciente-dialog.component';
import { PrescripcionesRComponent } from './perfil-responsable/pacientesVistaResponsable/prescripciones/prescripciones.component';
import { PrescripcionesComponent } from './perfil-medico/pacientesVistaMedico/prescripciones/prescripciones.component';
import { RecordatorioComponent } from './perfil-medico/pacientesVistaMedico/recordatorios/recordatorio.component';
import { ResponsablesDialogComponent } from './perfil-medico/pacientesVistaMedico/responsables-paciente/responsables-paciente-dialog.component';
import { ResponsablesDialogRComponent } from './perfil-responsable/pacientesVistaResponsable/responsables-paciente/responsables-paciente-dialog.component';
import { MoreDetailsDialogRComponent } from './perfil-responsable/pacientesVistaResponsable/moredetails/moredetails-paciente-dialog.component';
import { MoreDetailsDialogComponent } from './perfil-medico/pacientesVistaMedico/moredetails/moredetails-paciente-dialog.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent },

                    { path: 'pacientes', component: PacientesComponent, data: { permission: 'Pages.PacienteMedico' }},
                    { path: 'mispacientes', component: PacientesVistaResponsableComponent, data: { permission: 'Pages.MisPacientes' }},
                    { path: 'DatosPersonales', component: PerfilPacienteComponent, data: { permission: 'Pages.DatosPersonalesPaciente' }},
                    { path: 'DatosPersonales*', component: PerfilMedicoComponent, data: { permission: 'Pages.DatosPersonalesMedico' }},
                    { path: 'DatosPersonales**', component: PerfilResponsableComponent, data: { permission: 'Pages.DatosPersonalesResponsable' }},


                    { path: 'citas/:id', component: CitaPacienteComponent, data: { permission: 'Pages.Citas'},},
                    { path: 'controlTemp/:id', component: ControlpacienteVMComponent, data: { permission: 'Pages.PacienteMedico'},},
                    { path: 'controlTemperatura/:id', component: ControlpacienteVRComponent, data: { permission: 'Pages.PacienteMedico'},},
                    { path: 'suscita/:id', component: CitaPacienteRComponent, data: { permission: 'Pages.SusCitas'},},
                    { path: 'susenfermedades/:id', component: EnfermedadesDialogRComponent, data: { permission: 'Pages.SusEnfermedades'},},
                    { path: 'susprescripciones/:id', component: PrescripcionesRComponent, data: { permission: 'Pages.SusPrescripciones'},},
                    { path: 'prescripciones/:id', component: PrescripcionesComponent, data: { permission: 'Pages.Prescripciones'},},
                    { path: 'recordatorios/:id', component: RecordatorioComponent, data: { permission: 'Pages.Recordatorios'},},
                    { path: 'responsables/:id', component: ResponsablesDialogComponent, data: { permission: 'Pages.Responsabes'},},
                    { path: 'susresponsables/:id', component: ResponsablesDialogRComponent, data: { permission: 'Pages.Responsabes'},},
                    
                    { path: 'susdatos/:id', component: MoreDetailsDialogRComponent, data: { permission: 'Pages.MisPacientes'},},
                    { path: 'detalles/:id', component: MoreDetailsDialogComponent, data: { permission: 'Pages.PacienteMedico'},},

                    

                    { path: 'enfermedades/:id', component: EnfermedadesDialogComponent, data: { permission: 'Pages.EnfermedadesPaciente'},},
                    { path: 'miscitas', component: MisCitasComponent, data: { permission: 'Pages.PacienteCita'},},
                    { path: 'miagenda', component: MiAgendaComponent, data: { permission: 'Pages.Agenda'},},

                    { path: 'misresponsables', component: MisResponsablesComponent, data: { permission: 'Pages.MisResponsables'},},

                    { path: 'misenfermedades', component: MisEnfermedadesComponent, data: { permission: 'Pages.MisEnfermedades'},},

                    { path: 'misprescripciones', component: MisPrescripcionesComponent, data: { permission: 'Pages.MisPrescripciones'},},
                    { path: 'misrecordatorios', component: MisRecordatoriosComponent, data: { permission: 'Pages.MisRecordatorios'},},

                    { path: 'chat', component: ChatsComponent, data: { permission: 'Pages.Chat'},},

                    {path: 'evolucion', component: EvolucionTemperaturaComponent, data: {permission: 'MiControldeTemperatura'},}
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
