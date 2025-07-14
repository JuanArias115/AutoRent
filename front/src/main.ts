import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { AngularFireModule } from '@angular/fire/compat';
import { environment } from './app/enviroment';
import { initializeApp as initFirebase } from 'firebase/app';

initFirebase(environment.firebaseConfig);

bootstrapApplication(App, appConfig).catch((err) => console.error(err));
