import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PacientesVistaResponsableComponent } from './pacientes.component';

describe('PacientesComponent', () => {
  let component: PacientesVistaResponsableComponent;
  let fixture: ComponentFixture<PacientesVistaResponsableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PacientesVistaResponsableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PacientesVistaResponsableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
