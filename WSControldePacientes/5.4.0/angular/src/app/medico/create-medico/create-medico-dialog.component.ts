import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateMedicoDto, CreateMedicoServiceProxy, RoleDto, UserServiceProxy,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-medico-dialog.component.html',
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
export class CreateMedicoDialogComponent extends AppComponentBase  {
    saving = false;
    medico: CreateMedicoDto = new CreateMedicoDto();
    selected : string = "";  
    roles: RoleDto[] = [];
    checkedRolesMap: any;
    defaultRoleCheckedStatus: boolean;

    constructor(
        injector: Injector,
        private _medicoService: CreateMedicoServiceProxy,
        public _userService: UserServiceProxy,
        private _dialogRef: MatDialogRef<CreateMedicoDialogComponent>
    ) {
        super(injector);
    }
    
    ngOnInit(): void {
        this.medico.datosPersonalesIsActive = true;
    
        this._userService.getRoles().subscribe(result => {
          this.roles = result.items;
          this.setInitialRolesStatus();
        });
      }
    
      setInitialRolesStatus(): void {
        _.map(this.roles, item => {
          this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
            item.normalizedName
          );
        });
      }
    
      isRoleChecked(normalizedName: string): boolean {
        // just return default role checked status
        // it's better to use a setting
        return this.defaultRoleCheckedStatus;
      }
    
      onRoleChange(role: RoleDto, $event: MatCheckboxChange) {
        this.checkedRolesMap[role.normalizedName] = $event.checked;
      }
    
      getCheckedRoles(): string[] {
        const roles: string[] = [];
        _.forEach(this.checkedRolesMap, function(value, key) {
          if (value) {
            roles.push(key);
          }
        });
        return roles;
      }
    
    save(): void {
        this.saving = true;
        const medico_ = new CreateMedicoDto();
        medico_.init(this.medico);

        this.medico.datosPersonalesRoleNames = this.getCheckedRoles();
        
        this._medicoService.create(medico_)
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
