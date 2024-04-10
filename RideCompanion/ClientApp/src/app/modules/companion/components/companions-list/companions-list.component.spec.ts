import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanionsListComponent } from './companions-list.component';

describe('CompanionsListComponent', () => {
  let component: CompanionsListComponent;
  let fixture: ComponentFixture<CompanionsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanionsListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompanionsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
