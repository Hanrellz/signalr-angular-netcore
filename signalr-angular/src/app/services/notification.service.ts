import { Injectable } from "@angular/core";

import * as signalR from "@aspnet/signalr";
import { NotificationModel } from '../models/NotificationModel';

@Injectable({
  providedIn: "root"
})
export class NotificationService {
  public data: NotificationModel[];

  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:5001/notification")
      .build();

    this.hubConnection
      .start()
      .then(() => console.log("Connection started"))
      .catch(err => console.log("Error while starting connection: " + err));
  };

  public addTransferChartDataListener = () => {
    this.hubConnection.on('notificationsdata', (data) => {
      this.data = data;
      console.log(data);
    });
  }
  constructor() {}
}
