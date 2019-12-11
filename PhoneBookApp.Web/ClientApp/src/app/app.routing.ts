import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PhoneBooklistComponent } from './phonebooklist/phonebooklist.component';
import { PhonebookformComponent } from './phonebookform/phonebookform.component';

const appRoutes: Routes = [
  { path: '',  pathMatch: 'full' , component: PhoneBooklistComponent },
  { path: 'phonebookform', component: PhonebookformComponent }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
