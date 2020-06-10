import { Component,  Injector, Optional, Inject } from '@angular/core';
import {MiCitaMedicaServiceProxy, PacienteDto, AuthenticateResultModel, CitaDto, DatosPacienteServiceProxy, AgendaServiceProxy } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { ActivatedRoute, Params } from '@angular/router';
import { from } from 'rxjs';
import { AnularCitaComponent } from 'app/pacientes/miscitas/anularCita/anularCita.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './miagenda.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class MiAgendaComponent extends PagedListingComponentBase<CitaDto> {

    agenda: CitaDto[] = [];
    filterText = '';

    parametros : string [] = [];
        constructor(
        injector: Injector,
        private _agendaService: AgendaServiceProxy,
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

      /*  this._agendaService.getAllToday()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.agenda = result.items;
            }); */

       // if (this.agenda.length==0){
            this._agendaService.getAll()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.agenda = result.items;
            });

       // }

    //ngOnInit() {
    //    this._pacienteService.getAll('', 0, 20)
    //        .subscribe(result =>
    //        this.pacientes = result.items);
    }

    

    delete(){}

    cancelar(cita: CitaDto){
        this.parametros[0]= cita.fechaHora.toLocaleString();
        this.parametros[1]= "Medico";
        this.parametros[2]= cita.medicoDatosPersonalesUserName;


        this._agendaService.anularCita(cita.id)
        .subscribe(()=> {
            this._dialog.open(AnularCitaComponent, { data: this.parametros });
            this.refresh();
        });

        
    }

}
