import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GenderService } from 'src/app/services/gender.service';
import { ActivatedRoute } from '@angular/router'
import { GenderUpdateGenderDto } from 'src/app/models/Genders/GenderUpdateGenderDto';
import { GenderResultGenderDto } from 'src/app/models/Genders/GenderResultGenderDto';
import { GenderDeleteDto } from 'src/app/models/Genders/GenderDeleteDto';

@Component({
  templateUrl: './gender-delete.component.html'
})
export class GenderDeleteComponent implements OnInit {

  mode: String = "Eliminar"
  model: GenderDeleteDto = new GenderDeleteDto();
  selectedGender: GenderResultGenderDto = new GenderResultGenderDto();

  constructor(private toastr: ToastrService, private service: GenderService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.service.GetById(params["id"]).subscribe(gender => {
        this.model.genderId = gender.genderId
        this.model.name = gender.name
      })
    })
  }

  Confirmar() {
    this.service.Delete(this.model.genderId).subscribe(res => {
      this.toastr.success(`Genero ${this.model.genderId} borrado existosamente`, "Éxito")
      this.router.navigate(["/administracion/generos"])
    },
      err => {
        this.toastr.error(err.error, "Error")
      })
  }

}
