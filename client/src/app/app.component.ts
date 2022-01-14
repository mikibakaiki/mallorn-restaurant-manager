import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    title = 'Restaurant Manager';
    restaurants: any;

    constructor(private http: HttpClient) {

    }

    ngOnInit(): void {
        this.http.get('https://localhost:5000/api/restaurants').subscribe(rest => {
            this.restaurants = rest;
            console.log("restaurants => ", this.restaurants);
        });

    }
}
