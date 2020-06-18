import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {PacienteResponsableServiceProxy, PacienteCompletoDto,
   
} from '@shared/service-proxies/service-proxies';
import { ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: 'moredetails-paciente-dialog.component.html',
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
export class MoreDetailsDialogRComponent extends AppComponentBase  {
    saving = false;
    paciente: PacienteCompletoDto = new PacienteCompletoDto();
    idPaciente: number;
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteResponsableServiceProxy,
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this.idPaciente=this.rutaActiva.snapshot.params.id;
        this._pacienteService.getDatosCompletosByPaciente(this.idPaciente)
            .subscribe(result =>
        this.paciente = result);
    }   
}
