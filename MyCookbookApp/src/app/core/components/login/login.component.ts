import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email: string;
  password: string;
  error = '';

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute)
    {
      // redirect to recipes if already logged in
      if (this.authenticationService.currentUserValue) {
        this.router.navigate(['/recipes']);
      }
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

}
