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
import { ActivatedRoute } from '@angular/router';

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
    recordatoriosHoy: RecordatorioDto[] = [];
    //paciente: PacienteDto= new PacienteDto();
    idPaciente:number;
    hoy: Date = new Date();
    hoy_mas_10m: Date = new Date();
    hoy_menos_10m: Date = new Date();
      
    constructor(
        injector: Injector,
        private _recordatorioesService: RecordatorioServiceProxy,
        //private _dialogRef: MatDialogRef<RecordatorioComponent>,
        private rutaActiva: ActivatedRoute,
        private _dialog: MatDialog,
    ) {
        super(injector);
    }

  
    ngOnInit(){ 

        this.hoy_mas_10m.setMinutes(this.hoy.getMinutes() + 30);
        this.hoy_menos_10m.setMinutes(this.hoy.getMinutes() - 30);

        this.idPaciente=this.rutaActiva.snapshot.params.id;
        this._recordatorioesService.getRecordatoriosToday(this.idPaciente)
            .subscribe(result=> this.recordatoriosHoy= result.items);

        this._recordatorioesService.getAll(this.idPaciente)
            .subscribe(result=> this.recordatorios= result.items);
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
        let createDialog= this._dialog.open(CreateRecordatorioDialogComponent, {data: this.idPaciente});
        createDialog.afterClosed().subscribe(result => {
            if (result) {
                this.ngOnInit();
            }
        });
    }

}
