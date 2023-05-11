import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SnackResultSnackDto } from '../models/Snacks/SnackResultSnackDto';
import { SnackInsertSnackDto } from '../models/Snacks/SnackInsertSnackDto';
@Injectable({
  providedIn: 'root'
})
export class SnackService {

  private apiUrl: string

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiURL + "snacks"
  }

  Get(): Observable<Array<SnackResultSnackDto>> {
    let url = this.apiUrl
    return this.http.get<Array<SnackResultSnackDto>>(url)
  }

  Insert(snack: SnackInsertSnackDto): Observable<SnackResultSnackDto> {
    return this.http.post<SnackResultSnackDto>(this.apiUrl, snack)
  }

  Delete(id: Number) {
    return this.http.delete(this.apiUrl + "/" + id.toString())
  }

  buySnack(ticketId: String, snacks: Array<SnackResultSnackDto>){
    return this.http.post<{ticketId: String, snacks:Array<SnackResultSnackDto>}>(this.apiUrl,{ticketId, snacks})
  }

}
