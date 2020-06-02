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
import { PacientesComponent } from '@app/pacientes/pacientes.component';
import { CitaPacienteComponent } from './pacientes/citas-paciente/citas-paciente.component';
import {PerfilPacienteComponent} from './pacientes/perfil-paciente/perfil-paciente.component';
import {MisCitasComponent} from './pacientes/miscitas/miscitas.component';
import {MisResponsablesComponent} from './pacientes/misresponsables/misrespnsables-dialog.component';
import { from } from 'rxjs';
import { MisEnfermedadesComponent } from './pacientes/misenfermedades/misenfermedades.component';
import { MisPrescripcionesComponent } from './pacientes/misprescripciones/misprescripciones.component';
import { MisRecordatoriosComponent } from './pacientes/misrecordatorios/misrecordatorios.component';

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

                    { path: 'pacientesMedicoCabecera', component: PacientesComponent, data: { permission: 'Pages.PacientesMedicoCabecera' }},
                    { path: 'paciente**', component: PerfilPacienteComponent, data: { permission: 'Pages.Pacientes' }},

                    { path: 'citas/:id', component: CitaPacienteComponent, data: { permission: 'Pages.Citas'},},
                    { path: 'miscitas', component: MisCitasComponent, data: { permission: 'Pages.PacienteCita'},},

                    { path: 'misresponsables', component: MisResponsablesComponent, data: { permission: 'Pages.MisResponsables'},},

                    { path: 'misenfermedades', component: MisEnfermedadesComponent, data: { permission: 'Pages.MisEnfermedades'},},

                    { path: 'misprescripciones', component: MisPrescripcionesComponent, data: { permission: 'Pages.MisPrescripciones'},},
                    { path: 'misrecordatorios', component: MisRecordatoriosComponent, data: { permission: 'Pages.MisRecordatorios'},},
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
