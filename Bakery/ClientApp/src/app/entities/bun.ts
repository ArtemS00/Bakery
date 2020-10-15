import { formatDate } from '@angular/common';

export class Bun {
  public id: number;
  public name: string;
  public fullPrice: number;
  public bakedTime: Date;
  public controlTime: Date;
  public deadTime: Date;

  public changeTime: Date;
  public nextPrice: number;
  public currentPrice: number;

  public waitTime: string;

  constructor(bun: Bun = null) {
    if (!bun)
      return;

    this.id = bun.id;
    this.name = bun.name;
    this.fullPrice = bun.fullPrice;
    this.bakedTime = new Date(bun.bakedTime);
    this.controlTime = new Date(bun.controlTime);
    this.deadTime = new Date(bun.deadTime);

    this.changeTime = new Date(bun.changeTime);
    this.nextPrice = bun.nextPrice;
    this.currentPrice = bun.currentPrice;

    this.waitTime = this.getWaitTime();
  }

  getWaitTime(): string {
    let difference = this.changeTime.getTime() - Date.now();
    if (difference < 0) {
      return null;
    }
    let waitTime = new Date(difference);

    let timeInStr = formatDate(waitTime, 'HH:mm:ss', 'en-US', 'UTC+0');
    if (waitTime.getDate() == 2)
      return `${waitTime.getDate() - 1} day and ${timeInStr}`;
    if (waitTime.getDate() > 2)
      return `${waitTime.getDate() - 1} days and ${timeInStr}`;
    return timeInStr;
  }
}
