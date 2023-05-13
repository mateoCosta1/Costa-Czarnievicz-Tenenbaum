import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SnackResultSnackDto } from '../models/Snacks/SnackResultSnackDto';
import { SnackInsertSnackDto } from '../models/Snacks/SnackInsertSnackDto';
import { SnackBuySnackDto } from '../models/Snacks/SnackBuySnackDto';
@Injectable({
  providedIn: 'root'
})
export class SnackService {

  private apiUrl: string

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiURL + "snack"
  }

  Get(): Observable<Array<SnackResultSnackDto>> {
    let url = this.apiUrl
    return this.http.get<Array<SnackResultSnackDto>>(url)
  }

  Insert(snack: SnackInsertSnackDto): Observable<SnackResultSnackDto> {
    return this.http.post<SnackResultSnackDto>(this.apiUrl, snack)
  }

  Delete(id: string) {
    return this.http.delete(this.apiUrl + "/" + id.toString())
  }

  buySnack(ticketId: String, snacks: Array<SnackBuySnackDto>){
    return this.http.post<{ticketId: String, snacks:Array<SnackBuySnackDto>}>(environment.apiURL+"shopp/snack",{ticketId, snacks})
  }

}
