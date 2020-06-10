import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { ControldeTemperaturaServiceProxy } from '@shared/service-proxies/service-proxies';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
  //selector: 'app-pedir-temperatura',
  templateUrl: './pedir-temperatura.component.html',
})
export class PedirTemperaturaComponent extends AppComponentBase {

  temperatura:number;
  saving= false;
  constructor(
    injector: Injector,
    private _controlService:ControldeTemperaturaServiceProxy,
    private _dialogRef: MatDialogRef<PedirTemperaturaComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
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
    this._controlService.addNuevaTemperatura(this._id, this.temperatura).pipe(
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
