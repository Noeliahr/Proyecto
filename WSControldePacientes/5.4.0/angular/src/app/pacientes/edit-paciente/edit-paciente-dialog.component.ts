import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {PacienteMedicoCabeceraServiceProxy, PacienteCompletoDto, UserNameMedicosCabecera, EditPacienteDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-paciente-dialog.component.html',
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
export class EditPacienteDialogComponent extends AppComponentBase  {
    saving = false;
    paciente: PacienteCompletoDto = new PacienteCompletoDto();
    medicosCabecera : UserNameMedicosCabecera[] = [];


    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoCabeceraServiceProxy,
        private _dialogRef: MatDialogRef<EditPacienteDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

    ngOnInit(){
        this._pacienteService.getDatosCompletosByPaciente(this._id).subscribe(result =>
            this.paciente = result);
        
        this._pacienteService.getAllMedicosCabecera().subscribe(result=> this.medicosCabecera= result.items);
        
    }

  
    save(): void {
        this.saving = true;
        const paciente_ = new EditPacienteDto();
        paciente_.init(this.paciente);
        console.log(paciente_);

        paciente_.dondeViveTipo= this.paciente.dondeViveTipo;

        paciente_.medicoCabeceraUserName= this.paciente.miMedicoCabeceraDatosPersonalesUserName;

        paciente_.dondeViveCodigoPostal = this.paciente.dondeViveCodigo_Postal;
        
        this._pacienteService
            .update(paciente_)
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
