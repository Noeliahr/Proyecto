import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';

import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AbpModule } from '@abp/abp.module';

import { ChartsModule } from 'ng2-charts';

import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
import { TopBarComponent } from '@app/layout/topbar.component';
import { TopBarLanguageSwitchComponent } from '@app/layout/topbar-languageswitch.component';
import { SideBarUserAreaComponent } from '@app/layout/sidebar-user-area.component';
import { SideBarNavComponent } from '@app/layout/sidebar-nav.component';
import { SideBarFooterComponent } from '@app/layout/sidebar-footer.component';
import { RightSideBarComponent } from '@app/layout/right-sidebar.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';


// paciente
import { PacientesComponent } from './perfil-medico/pacientesVistaMedico/pacientes.component';
import { PacienteMedicoCabeceraServiceProxy, ResponsableServiceProxy, MisResponsablesServiceProxy, CitasServiceProxy, EnfermedadPacienteServiceProxy, EnfermedadServiceProxy, DatosPacienteServiceProxy, MiCitaMedicaServiceProxy, MensajeServiceProxy, ControldeTemperaturaServiceProxy, DatosMedicoServiceProxy, DatosResponsablesServiceProxy, AgendaServiceProxy, PrescripcionServiceProxy, MedicamentosServiceProxy, RecordatorioServiceProxy, PacienteMedicoServiceProxy, PacienteResponsableServiceProxy, CreateMedicoServiceProxy, MedicosServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreatePacienteDialogComponent } from './perfil-medico/pacientesVistaMedico/create-paciente/create-paciente-dialog.component';
import {MoreDetailsDialogComponent} from './perfil-medico/pacientesVistaMedico/moredetails/moredetails-paciente-dialog.component';
import {ResponsablesDialogComponent} from './perfil-medico/pacientesVistaMedico/responsables-paciente/responsables-paciente-dialog.component';
import {AsociarResponsableDialogComponent} from './perfil-medico/pacientesVistaMedico/responsables-paciente/asociar-responsable/asociar-responsables-paciente-dialog.component';
import { EditPacienteDialogComponent } from './perfil-medico/pacientesVistaMedico/edit-paciente/edit-paciente-dialog.component'; 
import { CitaPacienteComponent } from './perfil-medico/pacientesVistaMedico/citas-paciente/citas-paciente.component';
import {CitarPacienteDialogComponent} from './perfil-medico/pacientesVistaMedico/citas-paciente/citar/citarpaciente-dialog.component';
import {EnfermedadesDialogComponent} from './perfil-medico/pacientesVistaMedico/enfermedades-paciente/enfermedades-paciente-dialog.component';
import {AgregarEnfermedadDialogComponent} from './perfil-medico/pacientesVistaMedico/enfermedades-paciente/agregarEnfermedad/agregarEnfermedades-paciente-dialog.component';
import {PerfilPacienteComponent} from './perfil-paciente/perfil-paciente.component';
import {MisCitasComponent} from './perfil-paciente/miscitas/miscitas.component';
import {MisResponsablesComponent} from './perfil-paciente/misresponsables/misrespnsables-dialog.component';
import { MisEnfermedadesComponent } from './perfil-paciente/misenfermedades/misenfermedades.component';

import { from } from 'rxjs';
import { MisPrescripcionesComponent } from './perfil-paciente/misprescripciones/misprescripciones.component';
import { MisRecordatoriosComponent } from './perfil-paciente/misrecordatorios/misrecordatorios.component';
import { ChatsComponent } from './chats/chat.component';
import { MostrarConversacionDialogComponent } from './chats/mostrarConversacion/mostrarConversacion-dialog.component';
import { ControlesdeTemperaturaComponent } from './controlesdetemperatura/controlesdetemperatura.component';
import { EvolucionTemperaturaComponent } from './controlesdeTemperatura/evolucion-temperatura/evolucion-temperatura.component';
import { PedirTemperaturaComponent } from './controlesdeTemperatura/evolucion-temperatura/pedirTemperatura/pedir-temperatura.component';
import { AnularCitaComponent } from './perfil-paciente/miscitas/anularCita/anularCita.component';
import { PerfilMedicoComponent } from './perfil-medico/perfil-medico.component';
import { PerfilResponsableComponent } from './perfil-responsable/perfil-responsable.component';
import { EditMedicoDialogComponent } from './perfil-medico/edit-medico/edit-medico-dialog.component';
import { EditResponsableDialogComponent } from './perfil-responsable/edit-responsable/edit-responsable-dialog.component';
import { MiAgendaComponent } from './perfil-medico/agenda/miagenda.component';
import { PrescripcionesComponent } from './perfil-medico/pacientesVistaMedico/prescripciones/prescripciones.component';
import { CreatePrescripcionDialogComponent } from './perfil-medico/pacientesVistaMedico/prescripciones/create-prescripcion/create-prescripcion-dialog.component';
import { RecordatorioComponent } from './perfil-medico/pacientesVistaMedico/recordatorios/recordatorio.component';
import { CreateRecordatorioDialogComponent } from './perfil-medico/pacientesVistaMedico/recordatorios/create-recordatorios/create-recordatorio-dialog.component';
import { PacientesVistaResponsableComponent } from './perfil-responsable/pacientesVistaResponsable/pacientes.component';
import { MoreDetailsDialogRComponent } from './perfil-responsable/pacientesVistaResponsable/moredetails/moredetails-paciente-dialog.component';
import { CitaPacienteRComponent } from './perfil-responsable/pacientesVistaResponsable/citas-paciente/citas-paciente.component';
import { CreateMedicoDialogComponent } from './medico/create-medico/create-medico-dialog.component';
import { MedicosComponent } from './medico/medico.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    TopBarComponent,
    TopBarLanguageSwitchComponent,
    SideBarUserAreaComponent,
    SideBarNavComponent,
    SideBarFooterComponent,
    RightSideBarComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,

    // pacientes
    PerfilPacienteComponent,
    MisCitasComponent,
    AnularCitaComponent,
    MisResponsablesComponent,
    MisEnfermedadesComponent,
    MisPrescripcionesComponent,
    MisRecordatoriosComponent,
    ControlesdeTemperaturaComponent,
    EvolucionTemperaturaComponent,
    PedirTemperaturaComponent,



    //medicos
    PacientesComponent,
    CreatePacienteDialogComponent,
    MoreDetailsDialogComponent,
    ResponsablesDialogComponent,
    EditPacienteDialogComponent,
    AsociarResponsableDialogComponent,
    CitaPacienteComponent,
    CitarPacienteDialogComponent,
    EnfermedadesDialogComponent,
    AgregarEnfermedadDialogComponent,
    PerfilMedicoComponent,
    EditMedicoDialogComponent, 
    MiAgendaComponent,
    PrescripcionesComponent,
    CreatePrescripcionDialogComponent,
    

    //responsables
    PerfilResponsableComponent,
    EditResponsableDialogComponent,
    PacientesVistaResponsableComponent,
    MoreDetailsDialogRComponent,
    CitaPacienteRComponent,
    


    ChatsComponent,
    MostrarConversacionDialogComponent,
    

    RecordatorioComponent,
    CreateRecordatorioDialogComponent,

    MedicosComponent,
    CreateMedicoDialogComponent
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forRoot(),
    AbpModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
    ChartsModule
  ],
  providers: [PacienteMedicoCabeceraServiceProxy, ResponsableServiceProxy, MisResponsablesServiceProxy,
    CitasServiceProxy,EnfermedadPacienteServiceProxy, EnfermedadServiceProxy, DatosPacienteServiceProxy, 
    MiCitaMedicaServiceProxy,MensajeServiceProxy, ControldeTemperaturaServiceProxy,DatosMedicoServiceProxy,
    DatosResponsablesServiceProxy, AgendaServiceProxy, PrescripcionServiceProxy, MedicamentosServiceProxy, 
    RecordatorioServiceProxy, PacienteMedicoServiceProxy, PacienteResponsableServiceProxy,CreateMedicoServiceProxy, MedicosServiceProxy],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,

    // pacientes
    PerfilPacienteComponent,
    MisCitasComponent,
    AnularCitaComponent,
    MisResponsablesComponent,
    MisEnfermedadesComponent,
    MisPrescripcionesComponent,
    MisRecordatoriosComponent,
    ControlesdeTemperaturaComponent,
    EvolucionTemperaturaComponent,
    PedirTemperaturaComponent,



    //medicos
    PacientesComponent,
    CreatePacienteDialogComponent,
    MoreDetailsDialogComponent,
    ResponsablesDialogComponent,
    EditPacienteDialogComponent,
    AsociarResponsableDialogComponent,
    CitaPacienteComponent,
    CitarPacienteDialogComponent,
    EnfermedadesDialogComponent,
    AgregarEnfermedadDialogComponent,
    PerfilMedicoComponent,
    EditMedicoDialogComponent, 
    MiAgendaComponent,
    PrescripcionesComponent,
    CreatePrescripcionDialogComponent,
    

    //responsables
    PerfilResponsableComponent,
    EditResponsableDialogComponent,
    PacientesVistaResponsableComponent,
    MoreDetailsDialogRComponent,
    CitaPacienteRComponent,
    


    ChatsComponent,
    MostrarConversacionDialogComponent,
    

    RecordatorioComponent,
    CreateRecordatorioDialogComponent,

    MedicosComponent,
    CreateMedicoDialogComponent

  ]
})
export class AppModule {}
