import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { ControlTemperaturaDto, ControldeTemperaturaServiceProxy, PacienteMedicoServiceProxy, MiEvolucionTemperatura } from '@shared/service-proxies/service-proxies';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { Moment } from 'moment';
import { ActivatedRoute } from '@angular/router';


class PagedPacientesRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({
  selector: 'app-evolucion-temperatura',
  templateUrl: './control-pacienteVM.component.html'
})
export class ControlpacienteVMComponent extends PagedListingComponentBase<ControlTemperaturaDto>  {


  hoy:any =new Date();
  controles: ControlTemperaturaDto[] = [];
  evolucion: ControlTemperaturaDto[] = [];
  fechaInicio: Moment;
  fechaFinal: Moment;
  fecha: Moment;
  idPaciente: number;

  constructor(
    injector: Injector,
    private _controlService:PacienteMedicoServiceProxy,
    private _dialog: MatDialog,
    private rutaActiva: ActivatedRoute,
    ) {
      super(injector);
     }



  list(): void{

      this.idPaciente=this.rutaActiva.snapshot.params.id;


      this._controlService.getEvoluciondeTemperatura(this.idPaciente)
      .subscribe(result  => {
          this.controles = result.control_de_Temperatura;
          this.fechaInicio= this.controles[0].fecha;
          this.fechaFinal= this.controles[this.controles.length-1].fecha;
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
