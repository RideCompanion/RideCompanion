import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IDriverComponent } from './idriver.component';

describe('IDriverComponent', () => {
  let component: IDriverComponent;
  let fixture: ComponentFixture<IDriverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IDriverComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
