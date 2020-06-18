import { Component,  Injector } from '@angular/core';
import {MensajeServiceProxy, PacienteDto, AuthenticateResultModel, MensajeSimple } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { MostrarConversacionDialogComponent } from './mostrarConversacion/mostrarConversacion-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './chat.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class ChatsComponent extends PagedListingComponentBase<PacienteDto> {

    mensajes: MensajeSimple[] = [];
    filterText = '';
    persona:string;
    constructor(
        injector: Injector,
        private _mensajeService: MensajeServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    list(
        request: PagedPacientesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filterText;

        this._mensajeService.getMensaje()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.mensajes = result.items;
            });

    //ngOnInit() {
    //    this._pacienteService.getAll('', 0, 20)
    //        .subscribe(result =>
    //        this.pacientes = result.items);
    }

    delete() {
    }

    abrirConversacion(userName:string){
        this._dialog.open(MostrarConversacionDialogComponent, {data : userName});
    }

}
