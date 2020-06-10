import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,
    MatDialogRef,
    MatCheckboxChange} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {MedicoDto, DatosMedicoServiceProxy, EditMedicoDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-medico-dialog.component.html',
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
export class EditMedicoDialogComponent extends AppComponentBase  {
    saving = false;
    medico : MedicoDto = new MedicoDto();

    


    constructor(
        injector: Injector,
        private _medicoService: DatosMedicoServiceProxy,
        private _dialogRef: MatDialogRef<EditMedicoDialogComponent>,
    ) {
        super(injector);
    }

    ngOnInit(){
        this._medicoService.getMedico().subscribe(result =>
            this.medico = result);
        
    }

  
    save(): void {
        this.saving = true;
        const medico_ = new EditMedicoDto();
        medico_.init(this.medico);
        console.log(medico_);

        
        this._medicoService
            .update(medico_)
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
