import { Component,  Injector } from '@angular/core';
import {PacienteMedicoCabeceraServiceProxy, PacienteDto, AuthenticateResultModel, DatosMedicoServiceProxy, MedicoDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './perfil-medico.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class PerfilMedicoComponent extends AppComponentBase {

    medico: MedicoDto = new MedicoDto();
    filterText = '';
    constructor(
        injector: Injector,
        private _medicoService: DatosMedicoServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    ngOnInit() {
        this._medicoService.getMedico()
            .subscribe(result =>
            this.medico = result);
    }


    delete(){}



}