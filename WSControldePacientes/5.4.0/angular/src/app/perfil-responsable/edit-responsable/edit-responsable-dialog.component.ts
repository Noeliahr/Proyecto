import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {DatosResponsableDto, DatosResponsablesServiceProxy, EditResponsableDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-responsable-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class EditResponsableDialogComponent extends AppComponentBase  {
    saving = false;
    responsable : DatosResponsableDto = new DatosResponsableDto();

    


    constructor(
        injector: Injector,
        private _responsableService: DatosResponsablesServiceProxy,
        private _dialogRef: MatDialogRef<EditResponsableDialogComponent>,
    ) {
        super(injector);
    }

    ngOnInit(){
        this._responsableService.getDatos().subscribe(result =>
            this.responsable = result);
        
    }

  
    save(): void {
        this.saving = true;
        const responsable_ = new EditResponsableDto();
        responsable_.init(this.responsable);

        
        this._responsableService
            .update(responsable_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
