import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalespersonreportComponent } from './salespersonreport.component';

describe('SalespersonreportComponent', () => {
  let component: SalespersonreportComponent;
  let fixture: ComponentFixture<SalespersonreportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalespersonreportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalespersonreportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
