import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { ControlTemperaturaDto, ControldeTemperaturaServiceProxy } from '@shared/service-proxies/service-proxies';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { Moment } from 'moment';


class PagedPacientesRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({
  selector: 'app-evolucion-temperatura',
  templateUrl: './evolucion-temperatura.component.html',
  styleUrls: ['./evolucion-temperatura.component.css']
})
export class EvolucionTemperaturaComponent extends PagedListingComponentBase<ControlTemperaturaDto>  {

  controles: ControlTemperaturaDto[] = [];
  fechaInicio: Moment;
  fechaFinal: Moment;

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
          this.fechaFinal= this.controles[this.controles.length-1].fecha;
      });
    }


  delete(){}

}
