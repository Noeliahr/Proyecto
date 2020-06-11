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
import { DatosPacienteServiceProxy, PacienteDto, RecordatorioDto, RecordatorioServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateRecordatorioDialogComponent } from './create-recordatorios/create-recordatorio-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: './recordatorio.component.html',
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
export class RecordatorioComponent  extends AppComponentBase  {
    saving = false;
    recordatorios: RecordatorioDto[] = [];
    //paciente: PacienteDto= new PacienteDto();
      
    constructor(
        injector: Injector,
        private _recordatorioesService: RecordatorioServiceProxy,
        private _dialogRef: MatDialogRef<RecordatorioComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number,
        private _dialog: MatDialog,
    ) {
        super(injector);
    }

  
    ngOnInit(){ 
        this._recordatorioesService.getAll(this._id)
            .subscribe(result=> this.recordatorios= result.items);
    }   

    close(result: any): void {
        this._dialogRef.close(result);
    }

    delete(recordatorio: RecordatorioDto): void {
        abp.message.confirm(
            this.l('¿Seguro que quiere borrar la recordatorio?',),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._recordatorioesService.delete(recordatorio.id).subscribe(() => {
                        abp.notify.success(this.l('SuccessfullyDeleted'));
                        this.ngOnInit();
                    });
                }
            }
        );
    }

    edit(recordatorio: RecordatorioDto){

    }

    create(){
        let createDialog= this._dialog.open(CreateRecordatorioDialogComponent, {data: this._id});
        createDialog.afterClosed().subscribe(result => {
            if (result) {
                this.ngOnInit();
            }
        });
    }

}
