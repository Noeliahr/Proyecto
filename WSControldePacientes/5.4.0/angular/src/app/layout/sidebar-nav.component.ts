import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

    menuItems: MenuItem[] = [
        new MenuItem(this.l('Datos Personales'), 'Pages.MisResponsables', 'person_pin', '/app/DatosPersonales'),
        new MenuItem(this.l('Datos Personales'), 'Pages.DatosPersonalesMedico', 'person_pin', '/app/DatosPersonales*'),
        new MenuItem(this.l('Datos Personales'), 'Pages.DatosPersonalesResponsable', 'person_pin', '/app/DatosPersonales**'),
        new MenuItem(this.l('Responsables'), 'Pages.MisResponsables','supervisor_account', '/app/misresponsables/0'),
        new MenuItem(this.l('Citas'), 'Pages.MisCitas','today', '/app/miscitas'),
        new MenuItem(this.l('Agenda'), 'Pages.Agenda','today', '/app/miagenda'),
        new MenuItem(this.l('Enfermedades'), 'Pages.MisEnfermedades','announcement', '/app/misenfermedades/0'),
        new MenuItem(this.l('Control de Temperatura'), 'Pages.MiControldeTemperatura','perm_contact_calendar', '/app/evolucion/0'),
        new MenuItem(this.l('Prescripciones'), 'Pages.MisResponsables','assignment', '/app/misprescripciones/0'),
        new MenuItem(this.l('Recordatorios'), 'Pages.MisResponsables','event_note', '/app/misrecordatorios/0'),
        new MenuItem(this.l('Chat'), 'Pages.Chat','chat', '/app/chat'),

        new MenuItem(this.l('Tenants'), 'Pages.Tenants', 'business', '/app/tenants'),
        new MenuItem(this.l('Users'), 'Pages.Users', 'people', '/app/users'),
        new MenuItem(this.l('Pacientes'), 'Pages.PacienteMedico', 'assignment_ind', '/app/pacientes'),
        new MenuItem(this.l('Mis Pacientes'), 'Pages.MisPacientes', 'assignment_ind', '/app/mispacientes'),
        new MenuItem(this.l('Roles'), 'Pages.Roles', 'local_offer', '/app/roles'),
        new MenuItem(this.l('Medicos'), 'Pages.Medicos', 'local_offer', '/app/medicos'),
        //new MenuItem(this.l('About'), '', 'info', '/app/about'),

        /*new MenuItem(this.l('MultiLevelMenu'), '', 'menu', '', [
            new MenuItem('ASP.NET Boilerplate', '', '', '', [
                new MenuItem('Home', '', '', 'https://aspnetboilerplate.com/?ref=abptmpl'),
                new MenuItem('Templates', '', '', 'https://aspnetboilerplate.com/Templates?ref=abptmpl'),
                new MenuItem('Samples', '', '', 'https://aspnetboilerplate.com/Samples?ref=abptmpl'),
                new MenuItem('Documents', '', '', 'https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl')
            ]),
            new MenuItem('ASP.NET Zero', '', '', '', [
                new MenuItem('Home', '', '', 'https://aspnetzero.com?ref=abptmpl'),
                new MenuItem('Description', '', '', 'https://aspnetzero.com/?ref=abptmpl#description'),
                new MenuItem('Features', '', '', 'https://aspnetzero.com/?ref=abptmpl#features'),
                new MenuItem('Pricing', '', '', 'https://aspnetzero.com/?ref=abptmpl#pricing'),
                new MenuItem('Faq', '', '', 'https://aspnetzero.com/Faq?ref=abptmpl'),
                new MenuItem('Documents', '', '', 'https://aspnetzero.com/Documents?ref=abptmpl')
            ])
        ])*/
    ];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }
}
