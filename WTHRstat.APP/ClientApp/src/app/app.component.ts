import { Component, Inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from './data.service';
import { Emission } from './emission';
import { Source } from './source';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [DataService]
})
export class AppComponent implements OnInit{
    emission: Emission = new Emission();   // изменяемый товар
    emissions: Emission[] = [];                // массив товаров
    emissionTableMode: boolean = true;          // табличный режим
    source: Source = new Source();
    sources: Source[] = [];
    sourceTableMode: boolean = true;          // табличный режим
 
    constructor(@Inject(DataService)private dataService: DataService) { }
 
    ngOnInit() {
        this.loadEmissions();    // загрузка данных при старте компонента  
        this.loadSources();
    }
    // получаем данные через сервис
    loadEmissions() {
      console.log(this.dataService.getEmissions());
          this.dataService.getEmissions()
              .subscribe((data: Emission[]) => {console.log(data); this.emissions = data});
    }
    loadSources() {
      console.log(this.dataService.getSources());
          this.dataService.getSources()
              .subscribe((data: Source[]) => {console.log(data); this.sources = data});
      }
    // сохранение данных
    saveEmission() {
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
      // сохранение данных
      saveSource() {
          if (this.source.id == null) {
              this.dataService.createSource(this.source)
                  .subscribe((data: Source) => this.sources.push(data));
          } else {
              this.dataService.updateSource(this.source)
                  .subscribe(data => this.loadSources());
          }
          this.cancelEmission();
      }
      editSource(p: Source) {
          this.source = p;
      }
      cancelSource() {
          this.source = new Source();
          this.sourceTableMode = true;
      }
      deleteSource(p: Source) {
          this.dataService.deleteSource(p.id)
              .subscribe(data => this.loadSources());
      }
      addSource() {
          this.cancelSource();
          this.sourceTableMode = false;
      }
    }
