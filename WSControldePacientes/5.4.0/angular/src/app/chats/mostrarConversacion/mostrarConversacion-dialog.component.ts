import { Component, Injector, Optional, Inject, AfterViewChecked, ElementRef, ViewChild, OnInit } from '@angular/core';
import * as moment from 'moment';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {PacienteMedicoCabeceraServiceProxy, PacienteCompletoDto, MensajeDto, MensajeServiceProxy, CreateMensajeDto,
   
} from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase } from '@shared/paged-listing-component-base';

@Component({
    templateUrl: 'mostrarConversacion-dialog.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 0px;
            size : 100 %;
          }
        `
    ]
})
export class MostrarConversacionDialogComponent extends PagedListingComponentBase<MensajeDto>  {
    saving = false;
    mensajes: MensajeDto[] = [];
    nuevoMensaje: CreateMensajeDto = new CreateMensajeDto();
    texto : string;
   // @ViewChild('scrollMe') private myScrollContainer: ElementRef;

    constructor(
        injector: Injector,
        private _mensajesService: MensajeServiceProxy,
        private _dialogRef: MatDialogRef<MostrarConversacionDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _username : string
    ) {
        super(injector);
    }

   /* ngAfterViewChecked() {        
        this.scrollToBottom();        
    } 


    scrollToBottom(): void {
        try {
            this.myScrollContainer.nativeElement.scrollTop = this.myScrollContainer.nativeElement.scrollHeight;
        } catch(err) { }                 
    }*/
  
    list(): void {
        this._mensajesService.getChat(this._username)
            .subscribe(result =>
        this.mensajes = result.items);

        //this.scrollToBottom();
                
    }   

    close(result: any): void {
        this._dialogRef.close(result);
    }


    enviar(){
        this.nuevoMensaje.fecha=moment();
        this.nuevoMensaje.personaDestinoUserName= this._username;
        this.nuevoMensaje.texto= this.texto;

        this._mensajesService.create(this.nuevoMensaje).pipe(
            finalize(() => {
                this.saving = false;
            })
        ).subscribe(() => { this.refresh();
            this.texto="";
            
        }); 
    }


    delete(){}
}
