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
import {MisResponsablesServiceProxy, ResponsableServiceProxy, MisResponsables, ResponsableDto, PacienteDto, CreateResponsableDto } from '@shared/service-proxies/service-proxies';


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
        
        private _responsableService: ResponsableServiceProxy,
        private _misresponService: MisResponsablesServiceProxy,
        private _dialogRef: MatDialogRef<AsociarResponsableDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _paciente: number[]
    ) {
        super(injector);
    }

    list(): void {

        this._responsableService
            .getAll(this._paciente)
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
            this.l('¿Esta seguro que quiere asociarle?', this._paciente),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._misresponService
                        .asociarResponsables(this._paciente[0], responsable.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('Responsable Asociado'));
                                this.close(result);
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    saveyguardar(){
        this.saving = true;
        const responsable_ = new CreateResponsableDto();
        responsable_.init(this.responsable);

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
                result  => {
                    this.responsable = result;
                }
            });

        this.save(this.responsable);
    }

    delete(){}

}
