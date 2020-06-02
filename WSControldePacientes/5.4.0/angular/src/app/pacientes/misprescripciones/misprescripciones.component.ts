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
import { DatosPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, MisEnfermedades, MisPrescripciones } from '@shared/service-proxies/service-proxies';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'misprescripciones.component.html',
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
export class MisPrescripcionesComponent extends AppComponentBase  {
    saving = false;
    prescripciones: MisPrescripciones = new MisPrescripciones;
    paciente: PacienteDto= new PacienteDto();
      
    constructor(
        injector: Injector,
        private _pacienteService: DatosPacienteServiceProxy,
        //private _dialogRef: MatDialogRef<EnfermedadesDialogComponent>,
        private _dialog: MatDialog,
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this._pacienteService.getMisPrescripciones()
                .subscribe(result=> this.prescripciones= result);
    }   

    

}
