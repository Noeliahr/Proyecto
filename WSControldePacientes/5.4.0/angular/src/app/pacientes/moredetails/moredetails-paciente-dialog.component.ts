import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {PacienteMedicoCabeceraServiceProxy, PacienteCompletoDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'moredetails-paciente-dialog.component.html',
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
export class MoreDetailsDialogComponent extends AppComponentBase  {
    saving = false;
    paciente: PacienteCompletoDto = new PacienteCompletoDto();
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoCabeceraServiceProxy,
        private _dialogRef: MatDialogRef<MoreDetailsDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this._pacienteService.getDatosCompletosByPaciente(this._id)
            .subscribe(result =>
        this.paciente = result);
    }   

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
