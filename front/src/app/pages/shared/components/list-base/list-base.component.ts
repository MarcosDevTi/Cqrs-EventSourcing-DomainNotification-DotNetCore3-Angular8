import { OnInit } from '@angular/core';
import { Entity } from '../../entity.model';
import { BaseService } from '../../services/base.service';
import { ParamsList } from '../../paging/params-list';

export abstract class ListBaseComponent<T extends Entity> implements OnInit {
  constructor(protected baseService: BaseService) { }
  resources: T[];
  paramsList: ParamsList;
  ngOnInit() {
    this.Init();
    this.baseService.getAll<T>(this.paramsList).subscribe(
      resources => {
        console.log('resouces received', resources);
        this.resources = resources.items;
      },
      error => alert('Erro ao carregar a lista')
    );
  }

  abstract Init(): void;
}
