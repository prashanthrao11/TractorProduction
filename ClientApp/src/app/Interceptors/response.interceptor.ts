import { Injectable } from '@angular/core';
import { Response } from 'src/app/Models/response';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { tap } from 'rxjs/operators';

@Injectable()
export class ResponseInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(tap((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
        event = event.clone({ body: this.modifyBody(event.body, request) });
      }
      return event;
    }));
  }

  private modifyBody(body: Response<any>, request: HttpRequest<any>) {
    if (body == null) {

    } else
      if (!body.IsSuccess) {
        if (body.MessageType === 4) {
          this.toastr.error(body.Errors ? body.Errors.join('<br>') : body.Message, 'Validations', { 'enableHtml': true });
        }
        if (body.MessageType === 1) {
          this.toastr.error(body.Errors ? body.Errors.join('<br>') : body.Message + "</br>", 'Error', { 'enableHtml': true });
        }
        if (body.MessageType === 3) {
          this.toastr.error(body.Errors ? body.Errors.join('<br>') : body.Message, 'Info', { 'enableHtml': true });
        }
        else {
          //this.toastr.error(body.Message, 'Error', { 'enableHtml': true });
        }
      } else {
        if (body.Message != null && (request.method.toUpperCase() === 'POST' || request.method.toUpperCase() === 'DELETE')) {
          this.toastr.success(body.Message, 'Success');
        }
      }
    /*
    * write your logic to modify the body
    * */
  }
}
