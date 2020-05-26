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
import {PacienteMedicoCabeceraServiceProxy, ResponsableServiceProxy, MisResponsables, ResponsableDto } from '@shared/service-proxies/service-proxies';


class PagedResponsablesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'asociar-responsables-paciente-dialog.component.html',
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
export class AsociarResponsableDialogComponent extends PagedListingComponentBase<ResponsableDto>  {
    saving = false;
    responsables: ResponsableDto[] =[];
    responsable : ResponsableDto = new ResponsableDto();
    filter = ' ';
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoCabeceraServiceProxy,
        private _responsableService: ResponsableServiceProxy,
        private _dialogRef: MatDialogRef<AsociarResponsableDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

    list(
        request: PagedResponsablesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filter;

        this._responsableService
            .getAll()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.responsables = result.items;
            });
    }

    buscar(){
        this._responsableService.buscarByUserNameOrName(this.filter)
        .subscribe(result  => {
            this.responsables = result.items;
        });
    }
  

    close(result: any): void {
        this._dialogRef.close(result);
    }

    save(responsable : ResponsableDto){
        abp.message.confirm(
            this.l('¿Esta seguro que quiere asociarle?', this._id),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._pacienteService
                        .asociarResponsables(this._id, responsable)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('Responsable Asociado'));
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    saveyguardar(){
        this.saving = true;
        const responsable_ = new ResponsableDto();
        responsable_.init(this.responsable);
        console.log(responsable_);

        this._responsableService
            .create(responsable_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('Responsable Creado'));
                this.close(true);
            });

        abp.message.confirm(
            this.l('¿Esta seguro que quiere asociarle ?', this._id),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._pacienteService
                        .asociarResponsables(this._id, responsable_)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('Responsable Asociado'));
                                this.ngOnInit();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    delete(){}

}
