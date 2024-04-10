import {Component, ViewChild, TemplateRef} from '@angular/core';
import {RideRouteComponent} from "../../../ride/components/ride-route/ride-route.component";
import {NgbOffcanvas} from '@ng-bootstrap/ng-bootstrap';
import {OffcanvasComponent} from "../../../../components/offcanvas/offcanvas.component";
import {CompanionService} from "../../../../services/data-providers/companion/companion.service";
import { FormControl, ReactiveFormsModule, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-companions-list',
  standalone: true,
  imports: [
    RideRouteComponent,
    OffcanvasComponent,
    ReactiveFormsModule
  ],
  templateUrl: './companions-list.component.html',
  styleUrl: './companions-list.component.scss'
})
export class CompanionsListComponent {
  @ViewChild('createCompanion') createCompanion!: TemplateRef<any>;
  constructor(private _offcanvas: NgbOffcanvas, private companionService: CompanionService) {
  }

  public companionsList = this.companionService.getCompanions();

  name = new FormControl('');

  updateName() {
    this.name.setValue('Nancy');
  }

  profileForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
  });

  onSubmit() {
    console.warn(this.profileForm.value);
  }

  openCreateCompanion() {
    const offcanvasRef = this._offcanvas.open(OffcanvasComponent);
    offcanvasRef.componentInstance.content = this.createCompanion;
  }
}
