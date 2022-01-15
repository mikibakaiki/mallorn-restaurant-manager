import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
    @Input() restaurants: any;
    @Output() cancelRegister = new EventEmitter<boolean>();
    model: any = {}
    constructor(private accountService: AccountService) { }

    ngOnInit(): void {
    }

    register() {
        this.accountService.register(this.model).subscribe(response => {
            this.cancel();
        }, error => {
            console.log(error);
        })
    }

    cancel() {
        this.cancelRegister.emit(false);
        console.log("cancelled")
    }

}
