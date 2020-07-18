
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// @ts-ignore
import {PaginationModule} from 'ngx-bootstrap';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';



@NgModule({
  declarations: [
    PagerComponent,
    PagingHeaderComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),


  ],
  exports : [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent
  ]

})
export class SharedModule { }
