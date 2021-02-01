import { Component, OnInit, OnDestroy } from '@angular/core';
import { DataService } from '../data.service';
import {  takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-organizationsummary',
  templateUrl: './organizationsummary.component.html',
  styleUrls: ['./organizationsummary.component.css']
})
export class OrganizationsummaryComponent implements OnInit, OnDestroy {
  phones = [];
  destroy$: Subject<boolean> = new Subject<boolean>();


  constructor(private dataService: DataService) { }

  ngOnInit() {

    this.dataService.sendGetRequest().pipe(takeUntil(this.destroy$)).subscribe((data: any[])=>{
      console.log(data);
      this.phones = data;
    })  
  }
  ngOnDestroy() {
    this.destroy$.next(true);
    // Unsubscribe from the subject
    this.destroy$.unsubscribe();
  }

}
