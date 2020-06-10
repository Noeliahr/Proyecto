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
import { EnfermedadPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, EnfermedadServiceProxy, MedicamentoDto, MedicamentosServiceProxy, PrescripcionServiceProxy, PrescripcionDto } from '@shared/service-proxies/service-proxies';



class PagedResponsablesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'create-prescripcion-dialog.component.html',
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
export class CreatePrescripcionDialogComponent extends PagedListingComponentBase<EnfermedadDto>  {
    saving = false;
    medicamentos: MedicamentoDto[] =[];
    prescripcion : PrescripcionDto = new PrescripcionDto();
    medicamento: MedicamentoDto= new MedicamentoDto();
    filter = ' ';
    manana:boolean= false;
    tarde: boolean= false;
    noche: boolean= false;
      
    constructor(
        injector: Injector,
        
        private _prescripcionService: PrescripcionServiceProxy,
        private _medicamentosService : MedicamentosServiceProxy,
        //private _misresponService: MisResponsablesServiceProxy,
        private _dialogRef: MatDialogRef<CreatePrescripcionDialogComponent>,
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
        this._medicamentosService
            .getAll()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.medicamentos = result.items;
            });
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

    save(prescripcion : PrescripcionDto){
        
        if (this.manana==true && this.tarde==true && this.noche==true){
            this.prescripcion.como_Tomar="1-1-1";
        }else if (this.manana==true && this.tarde==false && this.noche==true){
            this.prescripcion.como_Tomar="1-0-1";
        }else if (this.manana==false && this.tarde==false && this.noche==true){
            this.prescripcion.como_Tomar="0-0-1";
        }else if (this.manana==true && this.tarde==false && this.noche==false){
            this.prescripcion.como_Tomar="1-0-0";
        }else if (this.manana==false && this.tarde==true && this.noche==false){
            this.prescripcion.como_Tomar="0-1-0";
        }
        console.log("id de paciente vale " + this._paciente);
        abp.message.confirm(
            this.l('¿Esta seguro que quiere asociarle?', this._paciente),
            undefined,
            (result: boolean) => {
                if (result) {
                    console.log("id de paciente vale " + this._paciente);
                    this._prescripcionService.create(this._paciente, prescripcion)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('Prescripcion Añadida'));
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
        const medicamento_ = new MedicamentoDto();
        medicamento_.init(this.medicamento);
        console.log(medicamento_);

        this._medicamentosService
            .create(medicamento_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('Medicamento Creada'));
                this.close(true);
                result  => {
                    this.medicamento = result;
                }
            });

        this.prescripcion.medicamentoId= this.medicamento.id;

        this.save(this.prescripcion);
    }

    delete(){}

} 
