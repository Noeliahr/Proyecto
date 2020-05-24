import { Component,  Injector } from '@angular/core';
import {PacienteMedicoCabeceraServiceProxy, PacienteDto, AuthenticateResultModel, PacienteDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreatePacienteDialogComponent } from './create-paciente/create-paciente-dialog.component';
//import { EditPacienteDialogComponent } from './edit-paciente/edit-paciente-dialog.component';
import {MoreDetailsDialogComponent} from './moredetails/moredetails-paciente-dialog.component'; 
import {ResponsablesDialogComponent} from './responsables-paciente/responsables-paciente-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './pacientes.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class PacientesComponent extends PagedListingComponentBase<PacienteDto> {

    pacientes: PacienteDto[] = [];
    filterText = '';
    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoCabeceraServiceProxy,
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

        this._pacienteService
            .getAllPacientes()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.pacientes = result.items;
            });

    //ngOnInit() {
    //    this._pacienteService.getAll('', 0, 20)
    //        .subscribe(result =>
    //        this.pacientes = result.items);
    }

    delete(paciente: PacienteDto): void {
        abp.message.confirm(
            this.l('PacienteDeleteWarningMessage', paciente.id),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._pacienteService
                        .delete(paciente.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.refresh();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    createPaciente(): void {
        this.showCreateOrEditPacienteDialog();
    }

    editPaciente(paciente: PacienteDto): void {
        this.showCreateOrEditPacienteDialog(paciente.id);
    }

    showCreateOrEditPacienteDialog(id?: number): void {
        let createOrEditPacienteDialog;
        if (id === undefined || id <= 0) {
            createOrEditPacienteDialog = this._dialog.open(CreatePacienteDialogComponent);
        } /*else {
            createOrEditPacienteDialog = this._dialog.open(EditPacienteDialogComponent, {
                data: id
            });
        }*/

        createOrEditPacienteDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }


    masDetalles (paciente: PacienteDto){
        this._dialog.open(MoreDetailsDialogComponent, {data : paciente.id});
    }

    misResponsables (paciente: PacienteDto){
        this._dialog.open(ResponsablesDialogComponent, {data : paciente.id});
    }


}
