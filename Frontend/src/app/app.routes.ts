import { Routes } from '@angular/router';
import { SignInComponent } from './pages/sign-in/sign-in.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LogsComponent } from './pages/logs/logs.component';
import { DashboardHomeComponent } from './pages/dashboard-home/dashboard-home.component';
import { LogRegisterComponent } from './pages/log-register/log-register.component';

export const routes: Routes = [
    { path: "sign-in", component: SignInComponent },
    {
        path: "dashboard", component: DashboardComponent,
        children: [
            { path: "home", component: DashboardHomeComponent },
            { path: "log-register", component: LogRegisterComponent },
            { path: "logs", component: LogsComponent },
            { path: "**", redirectTo: 'home', pathMatch: 'full' }
        ]
    },
    { path: "**", redirectTo: 'sign-in', pathMatch: 'full' }
];
