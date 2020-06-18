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
import { EnfermedadPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, EnfermedadServiceProxy, MedicamentoDto, MedicamentosServiceProxy, PrescripcionServiceProxy, PrescripcionDto, CreatePrescripcionDto, RecordatorioServiceProxy } from '@shared/service-proxies/service-proxies';



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
    prescripcion : CreatePrescripcionDto = new CreatePrescripcionDto();
    nuevaPrescripcion: PrescripcionDto = new PrescripcionDto();
    medicamento: MedicamentoDto= new MedicamentoDto();
    filter = ' ';
    manana:boolean= false;
    tarde: boolean= false;
    noche: boolean= false;
    recordatorio: boolean= false;
    medicamentoID: number;
      
    constructor(
        injector: Injector,
        
        private _prescripcionService: PrescripcionServiceProxy,
        private _medicamentosService : MedicamentosServiceProxy,
        private _recordatorioService: RecordatorioServiceProxy,
        private _dialogRef: MatDialogRef<CreatePrescripcionDialogComponent>,
        private _dialog: MatDialog,
        @Optional() @Inject(MAT_DIALOG_DATA) private _paciente: number
    ) {
        super(injector);
    }

    list(
        request: PagedResponsablesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filter;
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

    save(prescripcion : CreatePrescripcionDto){
        
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
        this.prescripcion.medicamentoId= this.medicamento.id;

        abp.message.confirm(
            this.l('¿Esta seguro que quiere asociarle?', this._paciente),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._prescripcionService.create(this._paciente, prescripcion)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('Prescripcion Añadida'));
                                this.close(result);
                            })
                        )
                        .subscribe((result  => {
                            this.nuevaPrescripcion = result;
                            this.nuevaPrescripcion.pacienteId= this._paciente;
                            if (this.recordatorio==true){
                                this._recordatorioService.createByPrescripcion(this.nuevaPrescripcion).pipe(
                                    finalize(() => {
                                        abp.notify.success(this.l('Recordatorio añadido al paciente'));
                                        this.close(result);
                                    })
                                )
                                .subscribe(()=>{

                                })
                            }
                        }))
                }
            }
        );
    }

    saveyguardar(){

        this.saving = true;
        const medicamento_ = new MedicamentoDto();
        medicamento_.init(this.medicamento);

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
