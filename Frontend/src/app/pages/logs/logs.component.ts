import { Component, OnDestroy, OnInit } from '@angular/core';
import { getEventLogsService } from '../../services/eventLog.service';
import { WarningAlert } from '../../utils/WarningAlert';
import { DangerAlert } from '../../utils/DangerAlert';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { dateParse2 } from '../../utils/dateParse';

@Component({
  selector: 'app-logs',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './logs.component.html',
  styleUrl: './logs.component.scss'
})
export class LogsComponent implements OnInit, OnDestroy {

  eventLogs: any[] = [];
  typeFilter: string = '';
  fromDatefilter: string = '';
  toDateFilter: string = '';
  dateParse2 = dateParse2;

  ngOnInit(): void {
    this.loadLogs();
  }

  ngOnDestroy(): void {

  }

  async loadLogs() {
    try {
      const response = await getEventLogsService({
        eventTypeId: this.typeFilter,
        dateFrom: this.fromDatefilter,
        dateTo: this.toDateFilter
      });

      if (!response.ok) {
        const errorData = await response.json();
        WarningAlert.setMessageAlertSubject(errorData.message || 'Error al cargar logs');
        WarningAlert.setStateAlertSubject(true);
        return;
      }

      const { data } = await response.json();
      this.eventLogs = data;

    } catch (e: any) {
      DangerAlert.setMessageAlertSubject(e.message);
      DangerAlert.setStateAlertSubject(true);
    }
  }
}
