import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizationsummaryComponent } from './organizationsummary.component';

describe('OrganizationsummaryComponent', () => {
  let component: OrganizationsummaryComponent;
  let fixture: ComponentFixture<OrganizationsummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganizationsummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganizationsummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
