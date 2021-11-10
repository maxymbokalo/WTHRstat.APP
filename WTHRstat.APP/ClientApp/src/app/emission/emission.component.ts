import { Component, Inject, OnInit } from '@angular/core';
import { Emission } from '../models/emission';
import { Source } from '../models/source';
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
  source: Source = new Source();   
  sources: Source[] = [];  

  constructor(@Inject(DataService)private dataService: DataService) { }

  ngOnInit() {
    this.loadEmissions(); 
    this.loadSources();
  }

  formChanged(): void {
    this.emission.source_Id = +this.emission.source_Id!;
}

  loadSources() {
    this.dataService.getSources()
        .subscribe((data: Source[]) => {console.log(data); this.sources = data});
}

  loadEmissions() {
    console.log(this.dataService.getEmissions());
        this.dataService.getEmissions()
            .subscribe((data: Emission[]) => {console.log(data); this.emissions = data});
  }

  saveEmission() {
    this.emissionTableMode = true;
      if (this.emission.id == null) {
        console.log(this.emission);
          this.dataService.createEmission(this.emission)
              .subscribe((data: Emission) => this.emissions.push(data));
      } else {
        console.log(this.emission);
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
    console.log(this.emission);
      this.cancelEmission();
      this.emissionTableMode = false;
  }

}
