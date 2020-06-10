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
import { PacienteMedicoCabeceraServiceProxy,EnfermedadPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto } from '@shared/service-proxies/service-proxies';
import { AgregarEnfermedadDialogComponent } from './agregarEnfermedad/agregarEnfermedades-paciente-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'enfermedades-paciente-dialog.component.html',
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
export class EnfermedadesDialogComponent extends AppComponentBase  {
    saving = false;
    enfermedades: EnfermedadPacienteDto[] = [];
    paciente: PacienteDto= new PacienteDto();
      
    constructor(
        injector: Injector,
        private _pacienteService: EnfermedadPacienteServiceProxy,
        private _dialogRef: MatDialogRef<EnfermedadesDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _paciente: PacienteDto
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this._pacienteService.getDatosPaciente(this._paciente.id)
                .subscribe(result=> this.paciente= result.paciente);

        this._pacienteService.getAll(this._paciente.id)
            .subscribe(result =>
        this.enfermedades = result.items);
    }   

    close(result: any): void {
        this._dialogRef.close(result);
    }

    desasociar(id : number, enfermedad : EnfermedadDto){
        abp.message.confirm(
            this.l('¿Esta seguro que quiere desasociar a ?', id),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._pacienteService
                        .eliminarEnfermedad(this._paciente.id, enfermedad)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.ngOnInit();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    asociar(){
        this._dialog.open(AgregarEnfermedadDialogComponent, {
            data: this._paciente.id
        });
        this.ngOnInit();
    }


}
