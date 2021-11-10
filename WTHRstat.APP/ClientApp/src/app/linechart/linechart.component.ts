import { Component, Inject, OnInit } from '@angular/core';  
import { Chart, registerables  } from 'chart.js';  
import { HttpClient } from '@angular/common/http';
import { ChartInf } from '../models/chartInf';
import { Search } from '../models/search';
import { DataService } from '../services/data.service';
import { Emission } from '../models/emission';
import { Source } from '../models/source';
@Component({  
  selector: 'app-linechart',  
  templateUrl: './linechart.component.html',  
  styleUrls: ['./linechart.component.scss'],
  providers: [DataService] 
})  
export class LinechartComponent implements OnInit {  
  emission: Emission = new Emission();   
  emissions: Emission[] = [];            
  emissionTableMode: boolean = true;

  source: Source = new Source();   
  sources: Source[] = [];  

  chartData: ChartInf[] = [];  
  Pollutant: string[] = [];  
  Concentration: number[] = [];
  Date: Date[] = [];
  SearchSource: Search = new Search();
  myChart: Chart;


  constructor(@Inject(DataService)private dataService: DataService, private httpClient: HttpClient)
   {
     this.myChart = new Chart("canvas", {  
      type: 'line',  
      data: {  
        labels: this.Date,  
    
        datasets: [  
          {  
            data: this.Concentration,  
            borderColor: '#3cb371',  
            backgroundColor: "#0000FF", 
            label:this.emission.pollutant 
          }
        ]  
      }
    });
   }

  ngOnInit() {
    this.loadEmissions(); 
    this.loadSources();
    this.myChart.destroy();
    Chart.register(...registerables);
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
  
  showChart(){
    this.myChart.destroy();
    this.Concentration = [];
    this.Date = [];
    this.Pollutant = [];
    console.log(this.SearchSource);
    var filteredEmissions = this.emissions.filter(em => {
        return em.source_Id == this.SearchSource.source_Id && em.date! >= this.SearchSource.startDate! && em.date! <= this.SearchSource.endDate!;
      });
      //var sortedEmissions = filteredEmissions.sort
      filteredEmissions.forEach(em => {
        this.Concentration.push(em.concentration!);  
        this.Pollutant.push(em.pollutant!);
        this.Date.push(em.date!);
      });
      console.log(filteredEmissions);
      var canvas = <HTMLCanvasElement> document.getElementById('canvas');
      canvas = <HTMLCanvasElement> document.getElementById('canvas');
      const res = canvas.getContext('2d');
      if (!res || !(res instanceof CanvasRenderingContext2D)) {
        throw new Error('Failed to get 2D context');
    }
    const ctx: CanvasRenderingContext2D = res;
this.myChart = new Chart(ctx, {  
  type: 'line',  
  data: {  
    labels: this.Date,  

    datasets: [  
      {  
        data: this.Concentration,  
        borderColor: '#3cb371',  
        backgroundColor: "#0000FF", 
        label:this.emission.pollutant 
      }
    ]  
  }
});
  }
}