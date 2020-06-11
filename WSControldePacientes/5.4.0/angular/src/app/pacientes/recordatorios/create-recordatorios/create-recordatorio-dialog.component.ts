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
import { MedicamentoDto, RecordatorioServiceProxy, RecordatorioDto } from '@shared/service-proxies/service-proxies';



class PagedResponsablesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'create-recordatorio-dialog.component.html',
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
export class CreateRecordatorioDialogComponent extends PagedListingComponentBase<RecordatorioDto>  {
    saving = false;
    medicamentos: MedicamentoDto[] =[];
    recordatorio : RecordatorioDto = new RecordatorioDto();
    
    filter = ' ';
      
    constructor(
        injector: Injector,
        
        private _recordatorioService: RecordatorioServiceProxy,
        private _dialogRef: MatDialogRef<CreateRecordatorioDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _paciente: number
    ) {
        super(injector);
        console.log("id de paciente vale " + this._paciente);
    }

    list(
        request: PagedResponsablesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filter;
        
    }

    buscar(){
       /* this._medicamentosService.buscarByUserNameOrName(this.filter)
        .subscribe(result  => {
            this.enfermedades = result.items;
        });*/
    }
  

    close(result: any): void {
        this._dialogRef.close(result);
    }

    save(){
        
        abp.message.confirm(
            this.l('¿Esta seguro que quiere asociarle?', this._paciente),
            undefined,
            (result: boolean) => {
                if (result) {
                    console.log("id de paciente vale " + this._paciente);
                    this._recordatorioService.create(this._paciente, this.recordatorio)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('recordatorio Añadida'));
                                this.close(result);
                            })
                        )
                        .subscribe(()=> {
                        });
                }
            }
        );
    }

    delete(){}

} 
