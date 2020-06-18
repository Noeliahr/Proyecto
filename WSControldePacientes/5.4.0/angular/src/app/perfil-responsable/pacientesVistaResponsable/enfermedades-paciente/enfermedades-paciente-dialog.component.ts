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
import { PacienteMedicoCabeceraServiceProxy,EnfermedadPacienteServiceProxy, EnfermedadPacienteDto, PacienteEnfermedadDto, PacienteDto, EnfermedadDto, PacienteResponsableServiceProxy, MisEnfermedades } from '@shared/service-proxies/service-proxies';
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
export class EnfermedadesDialogRComponent extends AppComponentBase  {
    saving = false;
    enfermedades: EnfermedadPacienteDto[] = [];
    paciente: MisEnfermedades= new MisEnfermedades();
    idPaciente : number;
      
    constructor(
        injector: Injector,
        private _pacienteService: PacienteResponsableServiceProxy,
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }

  
    ngOnInit() {
        this.idPaciente=this.rutaActiva.snapshot.params.id;

        this._pacienteService.getMisEnfermedades(this.idPaciente)
                .subscribe(result=> this.paciente= result);
    }  


}
