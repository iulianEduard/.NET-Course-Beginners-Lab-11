import {Input, Directive, EventEmitter, Component, Output} from "@angular/core";

@Component({
  selector: 'input-search',
  templateUrl: 'search-input.component.html',
  styleUrls: ['search-input.component.css']
})

export class SearchInputComponent {
  @Output() inputSearchMethod = new EventEmitter<any>();
  @Input() inputname: string;
  @Input() inputPlaceholder: string;
  @Input() inputColumnSearchName: string;
  searchModel:string = '';

  constructor() {
  }

  ngOnInit() {
  }

  setSearchValue(column): void {
    this.inputSearchMethod.emit({column: column, value: this.searchModel});
  }

  resetSearchProperty(): void {
    this.searchModel = '';
    this.inputSearchMethod.emit({column:this.inputColumnSearchName, value: this.searchModel});
  }
}
