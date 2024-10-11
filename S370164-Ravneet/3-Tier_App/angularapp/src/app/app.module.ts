import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    // your components here
  ],
  imports: [
    HttpClientModule,  // Add this line
    // other modules
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
