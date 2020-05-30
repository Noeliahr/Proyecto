import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {CitasServiceProxy, PacienteDto, CreatePacienteDto, CreateCitaDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'citarpaciente-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class CitarPacienteDialogComponent extends AppComponentBase  {
    saving = false;
    cita: CreateCitaDto = new CreateCitaDto(); 
    selected : string = "";  

    constructor(
        injector: Injector,
        private _citaService: CitasServiceProxy,
        private _dialogRef: MatDialogRef<CitarPacienteDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }
    
    
    save(): void {
        this.saving = true;
        const cita_ = new CreateCitaDto();
        cita_.init(this.cita);
        console.log(cita_);

        cita_.pacienteId= this._id;
        cita_.direccionTipo = this.selected;
        
        this._citaService
            .citar(cita_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
