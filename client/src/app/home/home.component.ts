import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    registerMode = false;
    restaurants: any;

    constructor(private http: HttpClient) { }

    ngOnInit(): void {
        this.getRestaurants();
    }

    registerToggle() {
        this.registerMode = !this.registerMode;
    }

    getRestaurants() {
        this.http.get('https://localhost:5000/api/restaurants').subscribe(rest => {
            this.restaurants = rest;
            console.log("restaurants => ", this.restaurants);
        });
    }

    cancelRegisterMode(event: boolean) {
        this.registerMode = event;
    }

}
