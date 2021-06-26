import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit, OnDestroy {
  authStatusSub?: Subscription;
  isLoading = false;
  constructor(private authService: AuthService) {}

  onLogin(form: NgForm) {
    this.isLoading = true;
    this.authService.loginUser(form.value.email, form.value.password);
  }
  ngOnDestroy(): void {
    this.authStatusSub?.unsubscribe();
  }

  ngOnInit(): void {
    this.authStatusSub = this.authService
      .getAuthStatusListener()
      .subscribe((authStatus) => {
        this.isLoading = false;
      });
  }
}
