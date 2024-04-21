import { Component, ViewChild, TemplateRef, OnInit } from '@angular/core';
import { RideRouteComponent } from '../../../ride/components/ride-route/ride-route.component';
import { NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { OffcanvasComponent } from '../../../../components/offcanvas/offcanvas.component';
import { CompanionService } from '../../../../shared/services/companion/companion.service';
import { FormControl, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { ConfigService } from '../../../../shared/config/config.service';
import { Config } from '../../../../shared/models/config';

@Component({
  selector: 'app-companions-list',
  standalone: true,
  imports: [RideRouteComponent, OffcanvasComponent, ReactiveFormsModule],
  templateUrl: './companions-list.component.html',
  styleUrl: './companions-list.component.scss',
})
export class CompanionsListComponent implements OnInit {
  @ViewChild('createCompanion') createCompanion!: TemplateRef<any>;

  constructor(
    private _offcanvas: NgbOffcanvas,
    private companionService: CompanionService,
    private configService: ConfigService
  ) {}

  ngOnInit(): void {
    this.showConfig();
  }

  public companionsList = this.companionService.getCompanions();

  name = new FormControl('');

  updateName() {
    this.name.setValue('Nancy');
  }

  profileForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    address: new FormGroup({
      street: new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      zip: new FormControl(''),
    }),
  });

  showConfig() {
    this.configService.getConfig().subscribe((data) => (console.log(data)));
  }

  onSubmit() {
    console.warn(this.profileForm.value);
  }

  openCreateCompanion() {
    const offcanvasRef = this._offcanvas.open(OffcanvasComponent);
    offcanvasRef.componentInstance.content = this.createCompanion;
  }
}
