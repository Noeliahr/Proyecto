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
import {PacienteMedicoCabeceraServiceProxy, PacienteCompletoDto, MisResponsables, ResponsableDto } from '@shared/service-proxies/service-proxies';

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
export class AsociarResponsableDialogComponent extends AppComponentBase  {
    saving = false;
    responsables: MisResponsables = new MisResponsables();
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoCabeceraServiceProxy,
        private _dialogRef: MatDialogRef<AsociarResponsableDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this._pacienteService.getMisResponsables(this._id)
            .subscribe(result =>
        this.responsables = result);
    }   

    close(result: any): void {
        this._dialogRef.close(result);
    }

    desasociar(id : number, responsable : ResponsableDto){
        abp.message.confirm(
            this.l('¿Esta seguro que quiere desasociar a ?', responsable.responsableDatosPersonalesUserName),
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

    asociar(id: number){
        this._dialog.open(AsociarResponsableDialogComponent, {
            data: id
        });
    }


}
