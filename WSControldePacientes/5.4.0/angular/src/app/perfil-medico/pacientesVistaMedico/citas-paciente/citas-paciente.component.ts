import { Component,  Injector, Optional, Inject } from '@angular/core';
import {CitasServiceProxy, PacienteDto, AuthenticateResultModel, CitaDto, PacienteMedicoServiceProxy } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { ActivatedRoute, Params } from '@angular/router';
import { from } from 'rxjs';
import { CitarPacienteDialogComponent } from './citar/citarpaciente-dialog.component';

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

    paciente : PacienteDto = new PacienteDto();
        constructor(
        injector: Injector,
        private _citasService: CitasServiceProxy,
        private _pacienteService : PacienteMedicoServiceProxy,
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

        this._pacienteService.getDatosCompletosByPaciente(this.idPaciente).subscribe(result =>
            this.paciente = result);

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

    citar(){
        
        let paraupdate=this._dialog.open(CitarPacienteDialogComponent, {data :this.idPaciente}); 

        paraupdate.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }

}
