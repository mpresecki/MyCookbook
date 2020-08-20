import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { User } from 'src/app/shared/models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {
  currentUser: User;
  navLinks = [
    { path: '/recipes', label: 'Dashboard' },
    { path: '/recipes/cookbook', label: 'Cookbook' },
    { path: '/meals', label: 'Meal planning' }
  ];
  activeLink = this.navLinks[0].path;

  constructor(
    private router: Router,
    public authenticationService: AuthenticationService
) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
}

  ngOnInit() {
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
