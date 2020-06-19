import { Component,  Injector } from '@angular/core';
import {PacienteMedicoServiceProxy, PacienteMedicoCabeceraServiceProxy, PacienteDto, AuthenticateResultModel, PacienteResponsableServiceProxy } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import {MoreDetailsDialogRComponent} from './moredetails/moredetails-paciente-dialog.component'; 
import { style } from '@angular/animations';
import { MostrarConversacionDialogComponent } from '@app/chats/mostrarConversacion/mostrarConversacion-dialog.component';
import { RecordatorioComponent } from 'app/perfil-medico/pacientesVistaMedico/recordatorios/recordatorio.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './pacientes.component.html',
    animations: [appModuleAnimation()],
    styleUrls: ['./pacientes.component.css']
})


export class PacientesVistaResponsableComponent extends PagedListingComponentBase<PacienteDto> {

    pacientes: PacienteDto[] = [];
    filterText = '';
    isMedicoCabecera : boolean = false;

    buscar:string;
    valor:string;

    constructor(
        injector: Injector,
        private _pacienteService: PacienteResponsableServiceProxy,
        private _pacienteMedicoService: PacienteMedicoCabeceraServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    list(): void {

        this._pacienteService
            .getAllPacientes()
            .subscribe(result  => {
                this.pacientes = result.items;
            });
    }


    delete(){}
    

    contactar(paciente:PacienteDto){
        this._dialog.open(MostrarConversacionDialogComponent, {data:paciente.datosPersonalesUserName});
    }

    search(){
        if (this.buscar=="nombre"){
            this._pacienteService.buscarPorNombre(this.valor).subscribe(result  => {
                this.pacientes = result.items;
            });
        }else if (this.buscar=="login"){
            this._pacienteService.buscarPorLogin(this.valor).subscribe(result  => {
                this.pacientes = result.items;
            });
        }else if (this.buscar=="numSeguridadSocial"){
            var num: number= +this.valor;
            this._pacienteService.buscarPorNumSS(num).subscribe(result  => {
                this.pacientes = result.items;
            });
        }
    }
}
