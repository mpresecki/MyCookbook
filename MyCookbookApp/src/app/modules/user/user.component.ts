import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';
import { UserUpdate, User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  user: UserUpdate;

  currentUser: User;

  constructor(
    private authenticationService: AuthenticationService,
    private userService: UserService,
  ) { }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.getUser();
  }

  getUser(){
    this.userService.getUser(this.currentUser.id).subscribe(x => this.user = x);
  }

  save(){
    this.userService.updateUser(this.user).subscribe(_ => this.getUser());
  }
}
