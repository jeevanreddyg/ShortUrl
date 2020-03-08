import { Component } from '@angular/core';

@Component({
  selector: 'app-analytics-component',
  templateUrl: './analytics.component.html'
})
export class AnalyticsComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
