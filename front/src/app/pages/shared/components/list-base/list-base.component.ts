import { OnInit } from '@angular/core';
import { Entity } from '../../entity.model';
import { BaseService } from '../../services/base.service';
import { ParamsList } from '../../paging/params-list';
import { Grid } from '../../paging/grid';

export abstract class ListBaseComponent<T extends Entity> implements OnInit {
  constructor(protected baseService: BaseService) { }
  resources: Grid<T>;
  paramsList: ParamsList;
  ngOnInit() {
    this.Init();
    this.baseService.getAll<T>(this.paramsList).subscribe(
      (resources: any) => {
        console.log('resouces received', resources);
        this.resources = new Grid<T>(resources.items, null, resources.total);
      },
      error => alert('Erro ao carregar a lista')
    );
  }

  abstract Init(): void;
}
