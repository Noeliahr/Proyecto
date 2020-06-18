import { Component,  Injector, Optional, Inject } from '@angular/core';
import {MiCitaMedicaServiceProxy, PacienteDto, AuthenticateResultModel, CitaDto, DatosPacienteServiceProxy } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { ActivatedRoute, Params } from '@angular/router';
import { from } from 'rxjs';
import { AnularCitaComponent } from './anularCita/anularCita.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './miscitas.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class MisCitasComponent extends PagedListingComponentBase<PacienteDto> {

    citas: CitaDto[] = [];
    filterText = '';
    idPaciente : number;

    parametros : string [] = [];

    paciente : PacienteDto = new PacienteDto();
        constructor(
        injector: Injector,
        private _citasService: MiCitaMedicaServiceProxy,
        private _pacienteService : DatosPacienteServiceProxy,
        private _dialog: MatDialog,
    ) {
        super(injector);
    }


    list(
        request: PagedPacientesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
        request.filter = this.filterText;

        this._pacienteService.datos().subscribe(result =>
            this.paciente = result);

        this._citasService
            .getMisCitas()
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

    cancelar(cita: CitaDto){
        this.parametros[0]= cita.fechaHora.toLocaleString();
        this.parametros[1]= "Paciente";
        this.parametros[2]= cita.medicoDatosPersonalesUserName;


        this._citasService.anularCita(cita.id)
        .subscribe(()=> {
            this._dialog.open(AnularCitaComponent, { data: this.parametros });
            this.refresh();
        });

        
    }

}
