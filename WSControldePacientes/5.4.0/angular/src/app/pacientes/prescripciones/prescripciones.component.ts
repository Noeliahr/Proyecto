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
import { DatosPacienteServiceProxy, PacienteDto, MisPrescripciones, PrescripcionServiceProxy, PrescripcionDto } from '@shared/service-proxies/service-proxies';
import { CreatePrescripcionDialogComponent } from './create-prescripcion/create-prescripcion-dialog.component';

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
export class PrescripcionesComponent  extends AppComponentBase  {
    saving = false;
    prescripciones: PrescripcionDto[] = [];
    paciente: PacienteDto= new PacienteDto();
      
    constructor(
        injector: Injector,
        private _prescripcionesService: PrescripcionServiceProxy,
        private _dialogRef: MatDialogRef<PrescripcionesComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number,
        private _dialog: MatDialog,
    ) {
        super(injector);
    }

  
    ngOnInit(){ 
        this._prescripcionesService.getAll(this._id)
            .subscribe(result=> this.prescripciones= result.items);
    }   

    close(result: any): void {
        this._dialogRef.close(result);
    }

    delete(prescripcion: PrescripcionDto): void {
        abp.message.confirm(
            this.l('¿Seguro que quiere borrar la prescripcion?',),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._prescripcionesService.delete(prescripcion.id).subscribe(() => {
                        abp.notify.success(this.l('SuccessfullyDeleted'));
                        this.ngOnInit();
                    });
                }
            }
        );
    }

    edit(prescripcion: PrescripcionDto){

    }

    create(){
        this._dialog.open(CreatePrescripcionDialogComponent, {data: this._id});
    }

}
