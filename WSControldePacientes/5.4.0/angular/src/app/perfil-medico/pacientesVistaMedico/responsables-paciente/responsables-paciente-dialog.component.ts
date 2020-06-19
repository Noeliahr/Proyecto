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
import {PacienteMedicoCabeceraServiceProxy, PacienteCompletoDto, MisResponsables, ResponsableDto, PacienteDto, PacienteMedicoServiceProxy } from '@shared/service-proxies/service-proxies';
import { AsociarResponsableDialogComponent } from './asociar-responsable/asociar-responsables-paciente-dialog.component';
import { ActivatedRoute } from '@angular/router';
import { MostrarConversacionDialogComponent } from '@app/chats/mostrarConversacion/mostrarConversacion-dialog.component';

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
    idPaciente:number;
    filter='';
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoServiceProxy,
        private _dialog: MatDialog,
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this.idPaciente=this.rutaActiva.snapshot.params.id;

        this._pacienteService.getMisResponsables(this.idPaciente)
            .subscribe(result =>
        this.responsables = result);
    }   

    buscar(){

        if (this.filter==""){
            this.ngOnInit()
        }else {
            this._pacienteService.buscarResponsableByUserName(this.idPaciente, this.filter)
            .subscribe(result =>this.responsables = result);
        }
       
    }

    desasociar( responsable : ResponsableDto){
        abp.message.confirm(
            this.l('¿Esta seguro que quiere desasociar a ?', responsable.datosPersonalesUserName),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._pacienteService
                        .desasociarResponsable(this.idPaciente, responsable)
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

        for (let enf of this.responsables.responsables){
            enfer[enfer.length]=enf.responsable.id;
        }

        this._dialog.open(AsociarResponsableDialogComponent, {
            data: enfer
        });
    }

    contactar(responsable : ResponsableDto){
        this._dialog.open(MostrarConversacionDialogComponent, {data:responsable.datosPersonalesUserName});
    }

}
