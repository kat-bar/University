import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Group } from './group';
import { Teacher } from './teacher';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [DataService]
})
export class HomeComponent {
  group: Group = new Group();
  groups: Group[];
  tableMode: boolean = true;          // табличный режим

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadGroup();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  loadGroup() {
    //this.dataService.getGroups()
    //  .subscribe(data => {
    //    this.groups = Array.of(data);
    //  })
    this.dataService.getGroups()
      .subscribe((data: Group[]) => this.groups = data);
  }
  // сохранение данных
  save() {
    if (this.group.GroupId == null) {
      this.dataService.createGroup(this.group)
        .subscribe((data: Group) => this.groups.push(data));
    } else {
      this.dataService.updateGroup(this.group)
        .subscribe(data => this.loadGroup());
    }
    this.cancel();
  }
  editGroup(p: Group) {
    this.group = p;
  }
  cancel() {
    this.group = new Group();
    this.tableMode = true;
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}
