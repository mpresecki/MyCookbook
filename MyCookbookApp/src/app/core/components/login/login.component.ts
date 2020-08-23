import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { UserService } from '../../services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserRegistration } from 'src/app/shared/models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email: string;
  password: string;
  error = '';

  user: UserRegistration;

  constructor(
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute)
    {
      // redirect to recipes if already logged in
      if (this.authenticationService.currentUserValue) {
        this.router.navigate(['/recipes']);
      }

      this.user = new UserRegistration();
    }

  ngOnInit(): void {
  }

  login(): void {
    this.authenticationService.login(this.email, this.password)
    .subscribe(
        data => {
          this.router.navigate(['/recipes']);
        },
        error => {
          this.error = error;
        });
  }

  register(): void {
    this.userService.addUser(this.user).subscribe(_ => {
      this.email = this.user.email;
      this.password = this.user.password;
      this.login();
    });
  }
}
