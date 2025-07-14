import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const spinner = inject(NgxSpinnerService);
  const token = localStorage.getItem('token');

  if (token) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
  }

  spinner.show();

  return next(req).pipe(
    catchError((err) => {
      if (err.status === 401) {
        localStorage.removeItem('token');
        router.navigate(['/login']);
      }
      return throwError(() => err);
    }),
    finalize(() => {
      spinner.hide();
    })
  );
};
