import { OnInit } from '@angular/core';
import { Entity } from '../../entity.model';
import { BaseService } from '../../services/base.service';
import { ParamsList } from '../../paging/params-list';
import { Grid } from '../../paging/grid';

export abstract class ListBaseComponent<T extends Entity> implements OnInit {
  constructor(protected baseService: BaseService) { }
  resources: Grid<T>;
  paramsList: ParamsList;
  page = 1;
  ngOnInit() {
    this.paramsList = {
      paging: {
        skip: this.page,
        top: 3,
        sortDirection: 0,
      }
    };
    this.Init();
    this.loadResources();
  }

  loadResources() {

    this.paramsList = {
      paging: {
        skip: this.page,
        top: 3,
        sortDirection: 0,
      }
    };
    this.baseService.getAll<T>(this.paramsList).subscribe(
      (resources: any) => {
        this.resources = new Grid<T>(resources.items, null, resources.total);
      },
      error => alert('Erro ao carregar a lista')
    );
  }

  paginationChange() {
    console.log('changement pagination', this.page);
    this.loadResources();
  }

  abstract Init(): void;
}
