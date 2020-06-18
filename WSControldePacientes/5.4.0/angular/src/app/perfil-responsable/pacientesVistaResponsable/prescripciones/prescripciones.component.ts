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
import { DatosPacienteServiceProxy, PacienteDto, MisPrescripciones, PrescripcionServiceProxy, PrescripcionDto, PacienteResponsableServiceProxy } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute } from '@angular/router';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: './prescripciones.component.html',
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
export class PrescripcionesRComponent  extends AppComponentBase  {
    saving = false;
    prescripciones: MisPrescripciones = new MisPrescripciones();
    paciente: PacienteDto= new PacienteDto();
    idPaciente : number;

      
    constructor(
        injector: Injector,
        private _prescripcionesService: PacienteResponsableServiceProxy,
        //private _dialogRef: MatDialogRef<PrescripcionesRComponent>,
        private _dialog: MatDialog,
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }

  
    ngOnInit(){ 
        this.idPaciente=this.rutaActiva.snapshot.params.id;
        this._prescripcionesService.getPrescripciones(this.idPaciente)
            .subscribe(result=> this.prescripciones= result);
        
    }   


}
