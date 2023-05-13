import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { SnackService } from 'src/app/services/snack.service';

@Component({
  templateUrl: './snacks.component.html',
})
export class SnacksComponent implements OnInit {

  snackList: Array<SnackResultSnackDto> = new Array<SnackResultSnackDto>();
  
  snackToDelete: string = "";

  constructor(
    private toastr: ToastrService, 
    private service: SnackService, 
    private router: Router) { }

  ngOnInit(): void {
    this.GetData();
  }

  GetData() {
    this.service.Get().subscribe(res => {
      this.snackList = res
    })
  }

  SetSnackToDelete(id: string) {
    this.snackToDelete = id;
  }

  Delete() {
    this.service.Delete(this.snackToDelete).subscribe(res => {
      this.toastr.success("Snack eliminado correctamente", "Éxito")
      this.GetData();
    },
      err => {
        this.toastr.error(err.error, "Error")
      })
  }

}
