import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeftNavbarComponent } from './left-navbar.component';

describe('LeftNavbarComponent', () => {
  let component: LeftNavbarComponent;
  let fixture: ComponentFixture<LeftNavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeftNavbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeftNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
