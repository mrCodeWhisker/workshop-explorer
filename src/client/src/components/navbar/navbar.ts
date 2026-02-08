import {Component} from '@angular/core';
import {NgIcon, provideIcons} from '@ng-icons/core';
import {gameArchiveResearch} from '@ng-icons/game-icons';

@Component({
  selector: 'navbar',
  imports: [NgIcon],
  viewProviders: [provideIcons({ gameArchiveResearch })],
  templateUrl: 'navbar.html',
})
export class NavbarComponent {

}
