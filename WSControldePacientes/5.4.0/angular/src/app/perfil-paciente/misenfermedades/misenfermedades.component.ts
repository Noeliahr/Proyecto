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
import { DatosPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, MisEnfermedades } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute } from '@angular/router';
import { result } from 'lodash';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    templateUrl: 'misenfermedades.component.html',
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
export class MisEnfermedadesComponent extends AppComponentBase  {
    saving = false;
    enfermedades: MisEnfermedades = new MisEnfermedades;
    paciente: PacienteDto= new PacienteDto();
    idPaciente : number;
    filter='';
      
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
        this._pacienteService.getMisEnfermedades(this.idPaciente)
                .subscribe(result=> this.enfermedades= result);
    }

    buscar(){
        if (this.filter==''){
            this.ngOnInit();
        }else {
            this._pacienteService.buscarEnfermedadesByNombre(this.idPaciente, this.filter)
                .subscribe(result=>this.enfermedades=result);
        }

        
    }

    

}
