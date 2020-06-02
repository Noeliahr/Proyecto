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
import { EnfermedadPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, EnfermedadServiceProxy } from '@shared/service-proxies/service-proxies';
import { EnfermedadesDialogComponent } from '../enfermedades-paciente-dialog.component';



class PagedResponsablesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'agregarEnfermedades-paciente-dialog.component.html',
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
        
        private _enfermedadesPacienteService: EnfermedadPacienteServiceProxy,
        private _enfermedadesService : EnfermedadServiceProxy,
        //private _misresponService: MisResponsablesServiceProxy,
        private _dialogRef: MatDialogRef<AgregarEnfermedadDialogComponent>,
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
        console.log("id de paciente vale " + this._paciente);
        this._enfermedadesService
            .getAll()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.enfermedades = result.items;
            });
    }

    buscar(){
       /* this._enfermedadesService.buscarByUserNameOrName(this.filter)
        .subscribe(result  => {
            this.enfermedades = result.items;
        });*/
    }
  

    close(result: any): void {
        this._dialogRef.close(result);
    }

    save(enfermedad : EnfermedadDto){
        console.log("id de paciente vale " + this._paciente);
        abp.message.confirm(
            this.l('¿Esta seguro que quiere asociarle?', this._paciente),
            undefined,
            (result: boolean) => {
                if (result) {
                    console.log("id de paciente vale " + this._paciente);
                    this._enfermedadesPacienteService
                        .addEnfermedad(this._paciente, enfermedad)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('Enfermedades Añadida al Paciente'));
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
        const enfermedad_ = new EnfermedadDto();
        enfermedad_.init(this.enfermedad);
        console.log(enfermedad_);

        this._enfermedadesService
            .create(enfermedad_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('Enfermedad Creada'));
                this.close(true);
                result  => {
                    this.enfermedad = result;
                }
            });

        this.save(this.enfermedad);
    }

    delete(){}

} 
