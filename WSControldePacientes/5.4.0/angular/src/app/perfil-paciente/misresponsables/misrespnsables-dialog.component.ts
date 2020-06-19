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
import {DatosPacienteServiceProxy, PacienteCompletoDto, MisResponsables, ResponsableDto, PacienteDto } from '@shared/service-proxies/service-proxies';
import { MostrarConversacionDialogComponent } from '@app/chats/mostrarConversacion/mostrarConversacion-dialog.component';
import { ActivatedRoute } from '@angular/router';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'misresponsables-dialog.component.html',
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
export class MisResponsablesComponent extends AppComponentBase  {
    saving = false;
    responsables: MisResponsables = new MisResponsables();
    idPaciente : number;
    filter='';
      
    constructor(
        injector: Injector,
        private _pacienteService: DatosPacienteServiceProxy,
        //private _dialogRef: MatDialogRef<MisResponsablesComponent>,
        private _dialog: MatDialog,
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this.idPaciente=this.rutaActiva.snapshot.params.id;

        if (this.idPaciente==0 || this.idPaciente== null){
            this.idPaciente= this.appSession.userId;
        }
        this._pacienteService.getMisResponsables(this.idPaciente)
            .subscribe(result =>
        this.responsables = result);
    }  
    
    

    contactar(responsable : ResponsableDto){
        this._dialog.open(MostrarConversacionDialogComponent, {data:responsable.datosPersonalesUserName});
    }

    buscar(){
        if(this.filter==''){
            this.ngOnInit()
        }else {
            this._pacienteService.buscarResponsableByUserName(this.idPaciente, this.filter)
                .subscribe(result=>this.responsables=result);
        }

        
    }


}
