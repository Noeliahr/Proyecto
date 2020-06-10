import { Component,  Injector } from '@angular/core';
import { DatosResponsablesServiceProxy, MedicoDto, DatosResponsableDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';
import { EditResponsableDialogComponent } from './edit-responsable/edit-responsable-dialog.component';

class PagedPacientesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-pacientes',
    templateUrl: './perfil-responsable.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class PerfilResponsableComponent extends AppComponentBase {

    responsable: DatosResponsableDto = new DatosResponsableDto();
    filterText = '';
    constructor(
        injector: Injector,
        private _medicoService: DatosResponsablesServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    ngOnInit() {
        this._medicoService.getDatos()
            .subscribe(result =>
            this.responsable = result);
    }


    delete(){}

    modificar(){
        let EditResponsableDialog;
        EditResponsableDialog= this._dialog.open(EditResponsableDialogComponent);

        EditResponsableDialog.afterClosed().subscribe(result => {
            if (result) {
                this.ngOnInit();
            }
        });
    }



}
