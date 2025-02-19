import { Component,  Injector } from '@angular/core';
import {PacienteMedicoServiceProxy, PacienteMedicoCabeceraServiceProxy, PacienteDto, AuthenticateResultModel } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreatePacienteDialogComponent } from './create-paciente/create-paciente-dialog.component';
import { EditPacienteDialogComponent } from './edit-paciente/edit-paciente-dialog.component';
import {MoreDetailsDialogComponent} from './moredetails/moredetails-paciente-dialog.component'; 
import {ResponsablesDialogComponent} from './responsables-paciente/responsables-paciente-dialog.component';
import { EnfermedadesDialogComponent } from './enfermedades-paciente/enfermedades-paciente-dialog.component';
import { style } from '@angular/animations';
import { MostrarConversacionDialogComponent } from '@app/chats/mostrarConversacion/mostrarConversacion-dialog.component';
import { PrescripcionesComponent } from './prescripciones/prescripciones.component';
import { RecordatorioComponent } from './recordatorios/recordatorio.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './pacientes.component.html',
    animations: [appModuleAnimation()],
    styleUrls: ['./pacientes.component.css']
})


export class PacientesComponent extends PagedListingComponentBase<PacienteDto> {

    pacientes: PacienteDto[] = [];
    filterText = '';
    isMedicoCabecera : boolean = false;

    buscar:string;
    valor:string;

    constructor(
        injector: Injector,
        private _pacienteService: PacienteMedicoServiceProxy,
        private _pacienteMedicoService: PacienteMedicoCabeceraServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    list(): void {

        this._pacienteService.getRole().subscribe(result => {this.isMedicoCabecera=result});

        this._pacienteService
            .getAllPacientes()
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
                    this._pacienteMedicoService
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
        }else {
            createOrEditPacienteDialog = this._dialog.open(EditPacienteDialogComponent, {
                data: id
            });
        }

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
        this._dialog.open(ResponsablesDialogComponent, {data : paciente});
    }

    misEnfermedades (paciente: PacienteDto){
        this._dialog.open(EnfermedadesDialogComponent, {data : paciente});
    }

    contactar(paciente:PacienteDto){
        this._dialog.open(MostrarConversacionDialogComponent, {data:paciente.datosPersonalesUserName});
    }

    misPrescripciones(paciente:PacienteDto){
        this._dialog.open(PrescripcionesComponent, {data: paciente.id});
    }

    misRecordatorios(paciente:PacienteDto){
        this._dialog.open(RecordatorioComponent, {data: paciente.id});
    }



    search(){
        if (this.buscar=="nombre"){
            this._pacienteService.buscarPorNombre(this.valor).subscribe(result  => {
                this.pacientes = result.items;
            });
        }else if (this.buscar=="login"){
            this._pacienteService.buscarPorLogin(this.valor).subscribe(result  => {
                this.pacientes = result.items;
            });
        }else if (this.buscar=="numSeguridadSocial"){
            var num: number= +this.valor;
            this._pacienteService.buscarPorNumSS(num).subscribe(result  => {
                this.pacientes = result.items;
            });
        }
    }

}
