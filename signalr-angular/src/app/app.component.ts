import { NotificationService } from './services/notification.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'signalr-angular';

  constructor(public notificationService: NotificationService, private http: HttpClient){

  }
  ngOnInit() {
    this.notificationService.startConnection();
    this.notificationService.addTransferChartDataListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:5001/api/notification')
      .subscribe(res => {
        console.log(res);
      })
  }
}
