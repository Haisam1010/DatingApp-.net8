import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  title = 'client';
  http = inject(HttpClient);
  user: any;

  ngOnInit(): void {
    this.http.get('localhost:5001/api/users').subscribe({
      next: response => this.user = response,
      error: error => console.log(error),
      complete: ()=> console.log('Request has Completed')
    })
  }

}
