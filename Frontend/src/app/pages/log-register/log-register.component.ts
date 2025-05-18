import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SpinnerComponent } from '../../components/spinner/spinner.component';
import { Router } from '@angular/router';
import { WarningAlert } from '../../utils/WarningAlert';
import { SuccessAlert } from '../../utils/SuccessAlert';
import { getEventLogTypesService, postEventLogService } from '../../services/eventLog.service';
import { DangerAlert } from '../../utils/DangerAlert';

@Component({
  selector: 'app-log-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, SpinnerComponent],
  templateUrl: './log-register.component.html',
  styleUrl: './log-register.component.scss'
})
export class LogRegisterComponent implements OnInit {

  logForm: FormGroup;
  spinner: boolean;
  eventLogTypes:any;

  constructor(private fb: FormBuilder, private router: Router) {
    this.logForm = this.fb.group({
      date: ['', [Validators.required]],
      description: ['', [Validators.required]],
      type: [0],
    });
    this.spinner = false;
  }

  ngOnInit(): void {
    // this.getEventLogTypes();
  }

  async getEventLogTypes() {

    try {
      
      const response: any = await getEventLogTypesService();

      if (!response.ok) {

        const data = await response.json();

        if (response.status) {
          console.error(data.error);
          WarningAlert.setMessageAlertSubject(data.error);
          WarningAlert.setStateAlertSubject(true);
        }

        return;
      }

      const resp = await response.json();
      console.log(resp);
      this.eventLogTypes = resp.data;

    } catch (e: any) {
      console.error(e);
      DangerAlert.setMessageAlertSubject(e.message);
      DangerAlert.setStateAlertSubject(true);
    }

  }

  async submit() {

    this.logForm.markAllAsTouched();

    if (!this.logForm.valid) {
      // alert("Formulario inválido");
      WarningAlert.setMessageAlertSubject("Datos inválidos.");
      WarningAlert.setStateAlertSubject(true);
    } else {

      // this.spinner = true;
      // setTimeout(() => {
      //   this.spinner = false;
      //   console.log('Form values:', this.logForm.value);
      //   this.logForm.reset();
      //   SuccessAlert.setMessageAlertSubject("Log registrado existosamente.");
      //   SuccessAlert.setStateAlertSubject(true);
      // }, 2000);

        this.spinner = true;

        try {

          const req: any = {
            event_date: this.logForm.value.date,
            event_description: this.logForm.value.description,
            event_type_id: 1,
          };

          const response: any = await postEventLogService(req);

          if (!response.ok) {

            const data = await response.json();

            if (response.status) {
              console.error(data.error);
              WarningAlert.setMessageAlertSubject(data.error);
              WarningAlert.setStateAlertSubject(true);
            }

            return;
          }

          const res = await response.json();
          SuccessAlert.setMessageAlertSubject("Log creado correctamente.");
          SuccessAlert.setStateAlertSubject(true);
          this.logForm.reset();

        } catch (e: any) {
          console.error(e);
          DangerAlert.setMessageAlertSubject(e.message);
          DangerAlert.setStateAlertSubject(true);
        } finally {
          this.spinner = false;
        }

      
    }
  }

}
