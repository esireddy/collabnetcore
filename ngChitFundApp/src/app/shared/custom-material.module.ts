import { NgModule } from '@angular/core';
import { SharedModule } from './shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule, MatInputModule, MatButtonModule, MatTableModule, MatSortModule, MatPaginatorModule } from '@angular/material';

@NgModule({
  imports: [
    SharedModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule
  ],
  exports: [
    SharedModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule
  ],
  declarations: []
})
export class CustomMaterialModule { }
