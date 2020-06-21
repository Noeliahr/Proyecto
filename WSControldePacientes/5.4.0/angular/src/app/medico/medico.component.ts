import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { UserServiceProxy, UserDto, UserDtoPagedResultDto, MedicosServiceProxy, MedicoDto } from '@shared/service-proxies/service-proxies';
import { Moment } from 'moment';
import { CreateMedicoDialogComponent } from './create-medico/create-medico-dialog.component';

class PagedUsersRequestDto extends PagedRequestDto {
    keyword: string;
    isActive: boolean | null;
}

@Component({
    templateUrl: './medico.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})
export class MedicosComponent extends PagedListingComponentBase<MedicoDto> {
    users: MedicoDto[] = [];
    keyword = '';
    isActive: boolean | null;

    constructor(
        injector: Injector,
        private _userService: MedicosServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    createUser(): void {
        this._dialog.open(CreateMedicoDialogComponent);
    }

    list(
        request: PagedUsersRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;
        request.isActive = this.isActive;

        this._userService.getAllMedicos()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.users = result.items;
            });
    }

    delete(){}


    
}
