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
import { PacienteDto } from '@shared/service-proxies/service-proxies';

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

                    { path: 'citas/:id', component: CitaPacienteComponent, data: { permission: 'Pages.Citas' },}
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
