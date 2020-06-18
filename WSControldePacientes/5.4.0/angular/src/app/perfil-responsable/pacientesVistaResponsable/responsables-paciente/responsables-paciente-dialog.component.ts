import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange,
    MatDialog} from '@angular/material';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {PacienteMedicoCabeceraServiceProxy, PacienteCompletoDto, MisResponsables, ResponsableDto, PacienteDto, PacienteMedicoServiceProxy, PacienteResponsableServiceProxy } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute } from '@angular/router';
import { MostrarConversacionDialogComponent } from '@app/chats/mostrarConversacion/mostrarConversacion-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'responsables-paciente-dialog.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 0px;
            size : 100 %;
          }
        `
    ]
})
export class ResponsablesDialogRComponent extends AppComponentBase  {
    saving = false;
    responsables: MisResponsables = new MisResponsables();
    idPaciente: number;
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteResponsableServiceProxy,
        private _dialog: MatDialog,
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this.idPaciente=this.rutaActiva.snapshot.params.id;
        this._pacienteService.getMisResponsables(this.idPaciente)
            .subscribe(result =>
        this.responsables = result);
    }   

    contactar(responsable : ResponsableDto){
        this._dialog.open(MostrarConversacionDialogComponent, {data:responsable.datosPersonalesUserName});
    }


}
