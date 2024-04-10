import { Component, Input, TemplateRef, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NgbActiveOffcanvas, NgbDatepickerModule, NgbOffcanvas, OffcanvasDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-offcanvas',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './offcanvas.component.html',
    styleUrls: ['./offcanvas.component.scss'],
})
export class OffcanvasComponent {
    @Input() content!: TemplateRef<any>;

    private offcanvasService = inject(NgbOffcanvas);
    closeResult = '';

    openOffcanvas(content: TemplateRef<any>) {
        this.offcanvasService.open(content, { ariaLabelledBy: 'offcanvas-basic-title' }).result.then(
            (result) => {
                this.closeResult = `Closed with: ${result}`;
            },
            (reason) => {
                this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
            },
        );
    }

    private getDismissReason(reason: any): string {
        switch (reason) {
            case OffcanvasDismissReasons.ESC:
                return 'by pressing ESC';
            case OffcanvasDismissReasons.BACKDROP_CLICK:
                return 'by clicking on the backdrop';
            default:
                return `with: ${reason}`;
        }
    }

    activeOffcanvas = inject(NgbActiveOffcanvas);
}
