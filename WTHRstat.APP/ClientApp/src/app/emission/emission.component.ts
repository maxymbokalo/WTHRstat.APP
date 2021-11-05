import { Component, Inject, OnInit } from '@angular/core';
import { Emission } from '../models/emission';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-emission',
  templateUrl: './emission.component.html',
  styleUrls: ['./emission.component.scss'],
  providers: [DataService]
})
export class EmissionComponent implements OnInit {
  emission: Emission = new Emission();   
  emissions: Emission[] = [];            
  emissionTableMode: boolean = true;
  constructor(@Inject(DataService)private dataService: DataService) { }

  ngOnInit() {
    this.loadEmissions(); 
  }

  loadEmissions() {
    console.log(this.dataService.getEmissions());
        this.dataService.getEmissions()
            .subscribe((data: Emission[]) => {console.log(data); this.emissions = data});
  }

  saveEmission() {
    this.emissionTableMode = true;
      if (this.emission.id == null) {
          this.dataService.createEmission(this.emission)
              .subscribe((data: Emission) => this.emissions.push(data));
      } else {
          this.dataService.updateEmissions(this.emission)
              .subscribe(data => this.loadEmissions());
      }
      this.cancelEmission();
  }
  editEmission(p: Emission) {
      this.emission = p;
  }
  cancelEmission() {
      this.emission = new Emission();
      this.emissionTableMode = true;
  }
  deleteEmission(p: Emission) {
      this.dataService.deleteEmission(p.id)
          .subscribe(data => this.loadEmissions());
  }
  addEmission() {
      this.cancelEmission();
      this.emissionTableMode = false;
  }

}
