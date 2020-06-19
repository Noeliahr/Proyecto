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
import { PacienteMedicoCabeceraServiceProxy,EnfermedadPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, PacienteMedicoServiceProxy } from '@shared/service-proxies/service-proxies';
import { AgregarEnfermedadDialogComponent } from './agregarEnfermedad/agregarEnfermedades-paciente-dialog.component';
import { ActivatedRoute } from '@angular/router';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'enfermedades-paciente-dialog.component.html',
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
export class EnfermedadesDialogComponent extends AppComponentBase  {
    saving = false;
    enfermedades: EnfermedadPacienteDto[] = [];
    paciente: PacienteDto= new PacienteDto();
    idPaciente : number;
    filter = '';
      
    constructor(
        injector: Injector,
        private _enfermedadService: EnfermedadPacienteServiceProxy,
        private _pacienteService: PacienteMedicoServiceProxy,
        //private _dialogRef: MatDialogRef<EnfermedadesDialogComponent>,
        private _dialog: MatDialog,
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this.idPaciente=this.rutaActiva.snapshot.params.id;

        this._pacienteService.getDatosCompletosByPaciente(this.idPaciente)
                .subscribe(result=> this.paciente= result);

        this._enfermedadService.getAll(this.idPaciente)
            .subscribe(result =>
        this.enfermedades = result.items);
        
    } 
    
    buscar(){

        if (this.filter!=''){
            this._enfermedadService.buscarByNombre(this.idPaciente,this.filter)
            .subscribe(result  => {this.enfermedades = result.items;});
        }else {
            this.ngOnInit();
        }
        
    }

    desasociar(enfermedad : EnfermedadDto){
        abp.message.confirm(
            this.l('¿Esta seguro que quiere quitarle esta enfermedad ?'),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._enfermedadService
                        .eliminarEnfermedad(this.idPaciente, enfermedad)
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
        const enfer= [];
        enfer[0]= this.idPaciente;

        for (let enf of this.enfermedades){
            enfer[enfer.length]=enf.enfermedad.id;
        }

        this._dialog.open(AgregarEnfermedadDialogComponent, {
            data: enfer
        }).afterClosed().subscribe(result => {
            if (result) {
                this.ngOnInit();
            }
        });
    }


}
