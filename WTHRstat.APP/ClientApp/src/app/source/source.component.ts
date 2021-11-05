import { Component, Inject, OnInit } from '@angular/core';
import { Source } from '../models/source';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-source',
  templateUrl: './source.component.html',
  styleUrls: ['./source.component.scss'],
  providers: [DataService]
})
export class SourceComponent implements OnInit {

  source: Source = new Source();
    sources: Source[] = [];
    sourceTableMode: boolean = true;     
  constructor(@Inject(DataService)private dataService: DataService) { }

  ngOnInit(){
    this.loadSources();
  }

  
  loadSources() {
    console.log(this.dataService.getSources());
        this.dataService.getSources()
            .subscribe((data: Source[]) => {console.log(data); this.sources = data});
    }

  saveSource() {
      this.sourceTableMode = true;
      
        if (this.source.id == null) {
            this.dataService.createSource(this.source)
                .subscribe((data: Source) => this.sources.push(data));
        } else {
            this.dataService.updateSource(this.source)
                .subscribe(data => this.loadSources());
        }
        this.cancelSource();
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
