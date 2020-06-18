import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {PacienteMedicoCabeceraServiceProxy, PacienteDto, CreatePacienteDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-paciente-dialog.component.html',
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
export class CreatePacienteDialogComponent extends AppComponentBase  {
    saving = false;
    paciente: CreatePacienteDto = new CreatePacienteDto();
    selected : string = "";  

    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoCabeceraServiceProxy,
        private _dialogRef: MatDialogRef<CreatePacienteDialogComponent>
    ) {
        super(injector);
    }
    
    
    save(): void {
        this.saving = true;
        const paciente_ = new CreatePacienteDto();
        paciente_.init(this.paciente);

        paciente_.dondeViveTipo= this.selected;
        
        this._pacienteService
            .create(paciente_)
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
