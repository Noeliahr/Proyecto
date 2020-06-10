import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { ControlTemperaturaDto, ControldeTemperaturaServiceProxy } from '@shared/service-proxies/service-proxies';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { Moment } from 'moment';
import { PedirTemperaturaComponent } from './pedirTemperatura/pedir-temperatura.component';


class PagedPacientesRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({
  selector: 'app-evolucion-temperatura',
  templateUrl: './evolucion-temperatura.component.html'
})
export class EvolucionTemperaturaComponent extends PagedListingComponentBase<ControlTemperaturaDto>  {

  controles: ControlTemperaturaDto[] = [];
  evolucion: ControlTemperaturaDto[] = [];
  evoluciondeDia: ControlTemperaturaDto[] = [];
  fechaInicio: Moment;
  fechaFinal: Moment;
  fecha: Moment;
  idPaciente: number

  constructor(
    injector: Injector,
    private _controlService:ControldeTemperaturaServiceProxy,
    private _dialog: MatDialog,
    ) {
      super(injector);
     }



  list(request: PagedPacientesRequestDto,
    pageNumber: number,
    finishedCallback: Function
    ): void{
      this._controlService.get().pipe(
        finalize(() => {
            finishedCallback();
        })
    )
      .subscribe(result  => {
          this.controles = result.items;
          this.fechaInicio= this.controles[0].fecha;
          this.idPaciente=this.controles[0].pacienteId;
          this.fechaFinal= this.controles[this.controles.length-1].fecha;
      });

      this._controlService.getByToday().pipe(
        finalize(() => {
            finishedCallback();
        })
    )
      .subscribe(result  => {
          this.evolucion = result.items;
      });


      this._controlService.getByFecha(this.fecha).pipe(
        finalize(() => {
            finishedCallback();
        })
    )
      .subscribe(result  => {
          this.evoluciondeDia = result.items;
      });

    }


    search(){
      this._controlService.getByFecha(this.fecha)
      .subscribe(result  => {
          this.evoluciondeDia = result.items;
      });

    }

    create(){
      this._dialog.open(PedirTemperaturaComponent, {
        data: this.idPaciente
       });
    }


  delete(){}

}
