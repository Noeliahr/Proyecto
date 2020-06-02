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
import { PacientesComponent } from '@app/pacientes/pacientes.component';
import { PacienteMedicoCabeceraServiceProxy, ResponsableServiceProxy, MisResponsablesServiceProxy, CitasServiceProxy, EnfermedadPacienteServiceProxy, EnfermedadServiceProxy, DatosPacienteServiceProxy, PacienteCitaServiceProxy, MisPrescripciones } from '@shared/service-proxies/service-proxies';
import { CreatePacienteDialogComponent } from './pacientes/create-paciente/create-paciente-dialog.component';
import {MoreDetailsDialogComponent} from './pacientes/moredetails/moredetails-paciente-dialog.component';
import {ResponsablesDialogComponent} from './pacientes/responsables-paciente/responsables-paciente-dialog.component';
import {AsociarResponsableDialogComponent} from './pacientes/responsables-paciente/asociar-responsable/asociar-responsables-paciente-dialog.component';
import { EditPacienteDialogComponent } from './pacientes/edit-paciente/edit-paciente-dialog.component'; 
import { CitaPacienteComponent } from './pacientes/citas-paciente/citas-paciente.component';
import {CitarPacienteDialogComponent} from './pacientes/citas-paciente/citar/citarpaciente-dialog.component';
import {EnfermedadesDialogComponent} from './pacientes/enfermedades-paciente/enfermedades-paciente-dialog.component';
import {AgregarEnfermedadDialogComponent} from './pacientes/enfermedades-paciente/agregarEnfermedad/agregarEnfermedades-paciente-dialog.component';
import {PerfilPacienteComponent} from './pacientes/perfil-paciente/perfil-paciente.component';
import {MisCitasComponent} from './pacientes/miscitas/miscitas.component';
import {MisResponsablesComponent} from './pacientes/misresponsables/misrespnsables-dialog.component';
import { MisEnfermedadesComponent } from './pacientes/misenfermedades/misenfermedades.component';

import { from } from 'rxjs';
import { MisPrescripcionesComponent } from './pacientes/misprescripciones/misprescripciones.component';
import { MisRecordatoriosComponent } from './pacientes/misrecordatorios/misrecordatorios.component';

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
    PerfilPacienteComponent,
    MisCitasComponent,
    MisResponsablesComponent,
    MisEnfermedadesComponent,
    MisPrescripcionesComponent,
    MisRecordatoriosComponent


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
    NgxPaginationModule
  ],
  providers: [PacienteMedicoCabeceraServiceProxy, ResponsableServiceProxy, MisResponsablesServiceProxy,CitasServiceProxy,EnfermedadPacienteServiceProxy, EnfermedadServiceProxy, DatosPacienteServiceProxy, PacienteCitaServiceProxy],
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

    //Pacientes
    CreatePacienteDialogComponent,
    MoreDetailsDialogComponent,
    ResponsablesDialogComponent,
    EditPacienteDialogComponent,
    AsociarResponsableDialogComponent,
    CitarPacienteDialogComponent,
    EnfermedadesDialogComponent,
    AgregarEnfermedadDialogComponent
    
  ]
})
export class AppModule {}
