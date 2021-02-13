import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Source } from './source';
import { Emission } from './emission';
import { Observable } from 'rxjs';
 
@Injectable()
export class DataService {
 
    private url = "/api/wthrstat";
 
    constructor(private http: HttpClient) {
    }
 
    getEmissions() : Observable<Emission[]> {
        return this.http.get<Emission[]>(this.url + "/getemissions");
    }
     
    getSources() {
        return this.http.get<Source[]>(this.url + "/getsources");
    }
     
  createEmission(emission: Emission) {
        return this.http.post(this.url + "/addemission", emission);
    }
    createSource(source: Source) {
        return this.http.post(this.url + "/addsource", source);
    }
    updateEmissions(emission: Emission) {
  
        return this.http.put(this.url + "/updateemission", emission);
    }
    updateSource(source: Source) {
  
        return this.http.put(this.url + "/updatesource", source);
    }
    deleteEmission(id?: number) {
        return this.http.delete(this.url + "/deleteemission/" + id);
    }
    deleteSource(id?: number) {
        return this.http.delete(this.url + "/deletesource/" + id);
    }
}
