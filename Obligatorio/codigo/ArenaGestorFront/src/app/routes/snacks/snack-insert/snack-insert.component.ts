import { Component, OnInit } from '@angular/core';
import { SnackInsertSnackDto } from 'src/app/models/Snacks/SnackInsertSnackDto';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { SnackService } from '../../../services/snack.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-snack-insert',
  templateUrl: './snack-insert.component.html',
})
export class SnackInsertComponent implements OnInit {

  mode: String = "Insertar";
  model: SnackInsertSnackDto = new SnackInsertSnackDto()
  usersList: Array<SnackResultSnackDto> = new Array()

  constructor(
    private service: SnackService,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
  
  }

  Confirmar() {
    if(this.model.price){
      this.service.Insert(this.model).subscribe(res => {
        this.toastr.success("Snack agregado correctamente", "Éxito")
        this.router.navigate(["/administracion/snacks"])
      },
        err => {
          this.toastr.error(err.error, "Error")
        })
    } else {
      this.toastr.error("Error ingrese bien los datos", "Error ingrese bien los datos")
    }
      
  }

}
