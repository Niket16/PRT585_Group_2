import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Unit {
  unitId: number;
  unitCode: string;
  unitName: string;
}

@Injectable({
  providedIn: 'root'
})
export class UnitService {
  private apiUrl = 'http://localhost:7246/api/unit'; // Update with your API URL

  constructor(private http: HttpClient) { }

  // Get all units
  getUnits(): Observable<Unit[]> {
    console.log("Calling API to get units...");
    return this.http.get<Unit[]>(this.apiUrl);
  }

  // Get a unit by ID
  getUnitById(id: number): Observable<Unit> {
    return this.http.get<Unit>(`${this.apiUrl}/${id}`);
  }

  // Create a new unit
  createUnit(unit: Unit): Observable<Unit> {
    return this.http.post<Unit>(this.apiUrl, unit);
  }

  // Update an existing unit
  updateUnit(id: number, unit: Unit): Observable<Unit> {
    return this.http.put<Unit>(`${this.apiUrl}/${id}`, unit);
  }

  // Delete a unit
  deleteUnit(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
