import { Component, OnInit } from '@angular/core';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { SnackService } from 'src/app/services/snack.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackBuySnackDto } from 'src/app/models/Snacks/SnackBuySnackDto';

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
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.ticketId = params["ticketId"];
      console.log(params["ticketId"]);
    });
    this.GetData();
  }

  GetData() {
    this.service.Get().subscribe(res => {
      this.snackList = res;
      this.snackList.forEach(snack => {
        snack!.amount = 0;
      });
    })
  }

  addSnack(id: string) {
    this.snackList.forEach(snack => {
      if(snack.id === id) snack!.amount = snack!.amount! +1;
    });
    console.log(this.snackList);
  }

  removeSnack(id: string) {
    this.snackList.forEach(snack => {
      if(snack.id === id) snack.amount === 0? snack.amount = 0 : snack!.amount = snack!.amount! -1;
    });
    console.log(this.snackList);
  }

  buySnacks(): void {
    let snackListBuy : Array<SnackBuySnackDto> = new Array<SnackBuySnackDto>();
    this.snackList.forEach(element => {
      let amount = element.amount as number +"";
      if(element.amount as number > 0 )
      snackListBuy.push({id: element.id +"",amount: amount })
    });
    this.service.buySnack(this.ticketId,snackListBuy).subscribe(res => {
      this.toastr.success("compra realizada con exito");
      this.router.navigate(["/home"]);
    }, error => {
      this.toastr.error(error.error)
    })
  }

}
