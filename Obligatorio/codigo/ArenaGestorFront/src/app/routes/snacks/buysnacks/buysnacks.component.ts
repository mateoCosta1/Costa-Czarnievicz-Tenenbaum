import { Component, OnInit } from '@angular/core';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { SnackService } from 'src/app/services/snack.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-buysnacks',
  templateUrl: './buysnacks.component.html',
})
export class BuysnacksComponent implements OnInit {

  ticketId: String = "";
  snackList: Array<SnackResultSnackDto> = new Array<SnackResultSnackDto>();
  

  constructor(
    private service: SnackService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.ticketId = params["ticketId"];
      console.log(params["ticketId"]);
    })
  }

  addSnack(id: Number) {
    this.snackList.forEach(snack => {
      if(snack.id === id) snack!.amount = snack!.amount as number +1;
    });
  }

  removeSnack(id: Number) {
    this.snackList.forEach(snack => {
      if(snack.id === id) snack.amount === 0? snack.amount = 0 : snack!.amount = snack!.amount as number -1;
    });
  }

  buySnacks() {
    this.service.buySnack(this.ticketId,this.snackList)
  }

}
