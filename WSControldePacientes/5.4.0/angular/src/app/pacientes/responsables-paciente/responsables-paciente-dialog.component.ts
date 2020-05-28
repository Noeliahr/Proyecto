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
import {PacienteMedicoCabeceraServiceProxy, PacienteCompletoDto, MisResponsables, ResponsableDto, PacienteDto } from '@shared/service-proxies/service-proxies';
import { AsociarResponsableDialogComponent } from './asociar-responsable/asociar-responsables-paciente-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'responsables-paciente-dialog.component.html',
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
export class ResponsablesDialogComponent extends AppComponentBase  {
    saving = false;
    responsables: MisResponsables = new MisResponsables();
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoCabeceraServiceProxy,
        private _dialogRef: MatDialogRef<ResponsablesDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _paciente: PacienteDto
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this._pacienteService.getMisResponsables(this._paciente.id)
            .subscribe(result =>
        this.responsables = result);
    }   

    close(result: any): void {
        this._dialogRef.close(result);
    }

    desasociar(id : number, responsable : ResponsableDto){
        abp.message.confirm(
            this.l('¿Esta seguro que quiere desasociar a ?', responsable.datosPersonalesUserName),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._pacienteService
                        .desasociarResponsable(id, responsable)
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
        this._dialog.open(AsociarResponsableDialogComponent, {
            data: this._paciente
        });
    }


}
