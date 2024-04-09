import { Component } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { RouterLink, RouterOutlet, RouterLinkActive } from '@angular/router';
import { CommonModule } from '@angular/common';
import { bootstrapHouseFill, bootstrapPersonFill, bootstrapCarFrontFill, bootstrapGeoAltFill, bootstrapMapFill, bootstrapInfoCircleFill } from '@ng-icons/bootstrap-icons';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [NgIconComponent, CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
  viewProviders: [provideIcons({ bootstrapHouseFill, bootstrapPersonFill, bootstrapCarFrontFill, bootstrapGeoAltFill, bootstrapMapFill, bootstrapInfoCircleFill })]
})
export class NavBarComponent {
  title = 'routing-app';
}
