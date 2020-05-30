/*import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange,
    MatDialog} from '@angular/material';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { EnfermedadPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto } from '@shared/service-proxies/service-proxies';



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
export class AgregarEnfermedadDialogComponent extends PagedListingComponentBase<EnfermedadDto>  {
    saving = false;
    enfermedades: EnfermedadDto[] =[];
    enfermedad : EnfermedadDto = new EnfermedadDto();
    filter = ' ';
      
    constructor(
        injector: Injector,
        
        private _enfermedadesService: EnfermedadPacienteServiceProxy,
        //private _misresponService: MisResponsablesServiceProxy,
        private _dialogRef: MatDialogRef<AgregarEnfermedadDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _paciente: PacienteDto
    ) {
        super(injector);
    }

    list(
        request: PagedResponsablesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filter;

        this._enfermedadesService
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
            this.l('¿Esta seguro que quiere asociarle?', this._paciente),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._misresponService
                        .asociarResponsables(this._paciente.id, responsable.id)
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
                result  => {
                    this.responsable = result;
                }
            });

        this.save(this.responsable);
    }

    delete(){}

} */
