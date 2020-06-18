import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { ControldeTemperaturaServiceProxy, CitaDto, MensajeServiceProxy, CreateMensajeDto } from '@shared/service-proxies/service-proxies';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';

@Component({
  //selector: 'app-pedir-temperatura',
  templateUrl: './anularCita.component.html',
})
export class AnularCitaComponent extends AppComponentBase {

  motivo:string;
  saving= false;
  constructor(
    injector: Injector,
    private _mensajeService:MensajeServiceProxy,
    private _dialogRef: MatDialogRef<AnularCitaComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _parametros: string[]
    ) {
      super(injector);
     }

  ngOnInit() {
  }


  close(result: any): void {
    this._dialogRef.close(result);
  }

  save(){
    this.saving = true;
    const nuevoMensaje = new CreateMensajeDto();

    if (this._parametros[1]=="Paciente"){
      nuevoMensaje.personaDestinoUserName = this._parametros[2];
      nuevoMensaje.texto= "La cita asignada " + this._parametros[0] + " ha sido anulada por el motivo: '" + this.motivo + "'.";
      nuevoMensaje.fecha= moment();
    } else {
      nuevoMensaje.personaDestinoUserName = this._parametros[2];
      nuevoMensaje.texto= "La cita asignada " + this._parametros[0] + " ha sido anulada por el motivo: '" + this.motivo + "'.";
      nuevoMensaje.fecha= moment();
    }

    
    this._mensajeService.anularCitaDarMotivo(nuevoMensaje).pipe(
        finalize(() => {
            this.saving = false;
        })
    )
    .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
    });
  }

  

}
