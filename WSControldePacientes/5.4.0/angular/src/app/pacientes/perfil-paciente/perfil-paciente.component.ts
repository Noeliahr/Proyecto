import { Component,  Injector } from '@angular/core';
import {PacienteMedicoCabeceraServiceProxy, PacienteDto, AuthenticateResultModel, DatosPacienteServiceProxy, MedicoDto, PacienteCompletoDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';
import { MostrarConversacionDialogComponent } from '@app/chats/mostrarConversacion/mostrarConversacion-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './perfil-paciente.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class PerfilPacienteComponent extends AppComponentBase {

    paciente: PacienteCompletoDto = new PacienteCompletoDto();
    filterText = '';
    constructor(
        injector: Injector,
        private _pacienteService: DatosPacienteServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    ngOnInit() {
        this._pacienteService.datos()
            .subscribe(result => this.paciente = result);
    }


    delete(){}


    contactar(){
        this._dialog.open(MostrarConversacionDialogComponent, {data : this.paciente.miMedicoCabeceraDatosPersonalesUserName});
    }



}
