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
import { DatosPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, MisEnfermedades, MisPrescripciones, MisRecordatorios } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute } from '@angular/router';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'misrecordatorios.component.html',
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
export class MisRecordatoriosComponent extends AppComponentBase  {
    saving = false;
    recordatorios: MisRecordatorios = new MisRecordatorios;
    recordatoriosHoy: MisRecordatorios = new MisRecordatorios;
    paciente: PacienteDto= new PacienteDto();
    idPaciente : number;

    hoy:any = new Date();
      
    constructor(
        injector: Injector,
        private _pacienteService: DatosPacienteServiceProxy,
        //private _dialogRef: MatDialogRef<EnfermedadesDialogComponent>,
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
        this._pacienteService.getMisRecordatoriosByFecha(this.idPaciente, this.hoy)
                .subscribe(result=> this.recordatoriosHoy= result);

        this._pacienteService.getMisRecordatorios(this.idPaciente)
                .subscribe(result=> this.recordatorios= result);
    }   

    
    

}
