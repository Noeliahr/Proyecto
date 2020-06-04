import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EvolucionTemperaturaComponent } from './evolucion-temperatura.component';

describe('EvolucionTemperaturaComponent', () => {
  let component: EvolucionTemperaturaComponent;
  let fixture: ComponentFixture<EvolucionTemperaturaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EvolucionTemperaturaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EvolucionTemperaturaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
