import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { ControlTemperaturaDto, ControldeTemperaturaServiceProxy, PacienteMedicoServiceProxy, MiEvolucionTemperatura, PacienteResponsableServiceProxy } from '@shared/service-proxies/service-proxies';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { Moment } from 'moment';
import { ActivatedRoute } from '@angular/router';


class PagedPacientesRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({
  selector: 'app-evolucion-temperatura',
  templateUrl: './control-pacienteVR.component.html'
})
export class ControlpacienteVRComponent extends PagedListingComponentBase<ControlTemperaturaDto>  {


  hoy: any = new Date();
  controles: ControlTemperaturaDto[] = [];
  evolucion: ControlTemperaturaDto[] = [];
  fechaInicio: Moment;
  fechaFinal: Moment;
  fecha: Moment;
  idPaciente: number;

  constructor(
    injector: Injector,
    private _controlService:PacienteResponsableServiceProxy,
    private _dialog: MatDialog,
    private rutaActiva: ActivatedRoute,
    ) {
      super(injector);
     }



  list(request: PagedPacientesRequestDto,
    pageNumber: number,
    finishedCallback: Function
    ): void{

      this.idPaciente=this.rutaActiva.snapshot.params.id;

      this._controlService.getEvoluciondeTemperatura(this.idPaciente).pipe(
        finalize(() => {
            finishedCallback();
        })
    )
      .subscribe(result  => {
          this.controles = result.control_de_Temperatura;
          this.fechaInicio= this.controles[0].fecha;
          this.fechaFinal= this.controles[this.controles.length-1].fecha;
      });

    
      this._controlService.getEvoluciondeTemperaturaByFecha(this.idPaciente,this.hoy).pipe(
        finalize(() => {
            finishedCallback();
        })
    )
      .subscribe(result  => {
          this.evolucion = result.control_de_Temperatura;
      });

    }


    search(){
      this._controlService.getEvoluciondeTemperaturaByFecha(this.idPaciente,this.fecha)
      .subscribe(result  => {
          this.evolucion = result.control_de_Temperatura;
      });

    }



  delete(){}

}
