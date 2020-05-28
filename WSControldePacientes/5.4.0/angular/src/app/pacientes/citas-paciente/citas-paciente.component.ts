import { Component,  Injector, Optional, Inject } from '@angular/core';
import {CitasServiceProxy, PacienteDto, AuthenticateResultModel, CitaDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { ActivatedRoute, Params } from '@angular/router';
import { from } from 'rxjs';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './citas-paciente.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class CitaPacienteComponent extends PagedListingComponentBase<PacienteDto> {

    citas: CitaDto[] = [];
    filterText = '';
    idPaciente : number;
    constructor(
        injector: Injector,
        private _citasService: CitasServiceProxy,
        private _dialog: MatDialog,
        //private _route : ActivatedRoute,
        
        private rutaActiva: ActivatedRoute,
    ) {
        super(injector);
    }


    list(
        request: PagedPacientesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        this.idPaciente=this.rutaActiva.snapshot.params.id;
        request.filter = this.filterText;

        this._citasService
            .getCitasByPaciente(this.idPaciente)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.citas = result.items;
            });

    //ngOnInit() {
    //    this._pacienteService.getAll('', 0, 20)
    //        .subscribe(result =>
    //        this.pacientes = result.items);
    }

    

    delete(){}

}
