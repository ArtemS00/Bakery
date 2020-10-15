import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { BunsService } from '../../services/buns-service';
import { Bun } from '../../entities/bun';
import { Subscription } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-buns-table',
  templateUrl: './buns-table.component.html',
  styleUrls: ['./buns-table.component.css']
})
export class BunsTableComponent implements OnDestroy {
  private subs: { [key: string]: Subscription } = {};
  buns: Bun[];

  displayedColumns: string[] = ['name', 'fullprice', 'currentprice', 'nextprice', 'nexttime' ];
  dataSource: MatTableDataSource<Bun>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngAfterViewInit() {
  }

  constructor(
    private bunsService: BunsService) {
    this.subs["getall"] = this.bunsService.getAll().subscribe(
      result => {
        this.buns = result;
        this.setDatasource();
        this.startUpdating();

        // Unsubscribe and remove subscription from dictionary
        this.subs["getall"].unsubscribe();
        delete this.subs["getall"];
      });
  }

  ngOnDestroy(): void {
    for (let key in this.subs) {
      let subscription = this.subs[key];
      subscription.unsubscribe();
      delete this.subs[key];
    };
  }

  private startUpdating() {
    setInterval(() => {
      for (let i = 0; i < this.buns.filter(b => b.waitTime).length; i++) {
        let bun = this.buns[i];
        let waitTime = bun.getWaitTime();
        if (!waitTime) {
          bun.waitTime = null;
          this.getBun(i, bun);
        } else {
          bun.waitTime = waitTime;
        }
      }
    }, 1000);
  }

  private getBun(index: number, bun: Bun) {
    this.subs[bun.id] = this.bunsService.get(bun.id).subscribe(
      result => {
        if (result) {
          this.buns[index] = result;
        }
        this.setDatasource();

        // Unsubscribe and remove subscription from dictionary
        this.subs[bun.id].unsubscribe();
        delete this.subs[bun.id];
      });
  }

  private setDatasource() {
    this.dataSource = new MatTableDataSource<Bun>(this.buns.filter(b => b.waitTime));
    this.dataSource.paginator = this.paginator;
  }
}
