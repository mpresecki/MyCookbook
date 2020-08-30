import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthenticationService } from '../services/authentication.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add auth header with jwt if user is logged in and request is to the api url
        const currentUser = this.authenticationService.currentUserValue;
        const isLoggedIn = currentUser && currentUser.token;
        const isApiUrl = request.url.startsWith(environment.userApi)
            || request.url.startsWith(environment.recipeApi)
            || request.url.startsWith(environment.mealApi);
        if (isLoggedIn && isApiUrl) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser.token}`,
                    'Access-Control-Allow-Origin': '*'
                }
            });
        }
        if (!isLoggedIn && isApiUrl) {
            request = request.clone({
                setHeaders: {
                    'Access-Control-Allow-Origin': '*'
                }
            });
        }

        return next.handle(request);
    }
}
