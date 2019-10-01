import { OnInit, AfterContentChecked, Injector } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import toastr from 'toastr';
import { Entity } from '../../entity.model';
import { BaseFormService } from '../../services/base-form.service';
import { BaseService } from '../../services/base.service';


export abstract class FormBaseComponent<T extends Entity> implements OnInit, AfterContentChecked {

  currentAction: string;
  resourceForm: FormGroup;
  pageTitle: string;
  serverErrorMessages: string[] = null;
  submittingForm = false;

  protected route: ActivatedRoute;
  protected router: Router;
  protected formBuilder: FormBuilder;

  constructor(
    protected injector: Injector,
    public resource: T,
    protected resourceService: BaseService,
    protected jsonDataToResourceFn: (jsonData) => T
  ) {
    this.route = this.injector.get(ActivatedRoute);
    this.router = this.injector.get(Router);
    this.formBuilder = this.injector.get(FormBuilder);
   }

  ngOnInit() {
    this.setCurrentAction();
    this.buildResourceForm();
    this.loadResource();
  }

  ngAfterContentChecked(): void {
    this.setPageTitle();
  }

  submitForm() {
    this.submittingForm = true;
    if (this.currentAction === 'new') {
      this.createResource();
    } else {
      this.updateResource();
    }
  }

  protected setCurrentAction() {
    if (this.route.snapshot.url[0].path === 'new') {
      this.currentAction = 'new';
    } else {
      this.currentAction = 'edit';
    }
  }

  protected loadResource() {
    if (this.currentAction === 'edit') {
      this.route.paramMap.pipe(
        switchMap(params => this.resourceService.getById<T>(params.get('id')))
      )
      .subscribe(
        (resource) => {
          console.log('resource', resource);
          this.resource = resource;
          this.resourceForm.patchValue(resource);
        },
        (error) => alert('Ocorreu um erro no servidor, tente mais tarde')
      );
    }
  }

  protected setPageTitle() {
    if (this.currentAction === 'new') {
      this.pageTitle = this.creationPageTitle();
    } else {
      this.pageTitle = this.editionPageTitle();
    }
  }

  protected creationPageTitle(): string {
    return 'New';
  }

  protected editionPageTitle(): string {
    return 'Edit';
  }

  public createResource() {

    const resource: T = this.jsonDataToResourceFn(this.resourceForm.value);
    console.log('create customer', resource);
    this.resourceService.create(resource)
    .subscribe(
      res => this.actionsForSuccess(res),
      error => this.actionsForError(error)
    );
  }

  protected updateResource() {
    const resource: T = this.jsonDataToResourceFn(this.resourceForm.value);

    this.resourceService.update(resource)
    .subscribe(
      cat => this.actionsForSuccess(cat),
      error => this.actionsForError(error)
    );
  }

  protected actionsForSuccess(resource: T) {
    toastr.success('Solicitação processada com sucesso!');
    const baseComponentPath = this.route.snapshot.parent.url[0].path;
    this.router.navigateByUrl(baseComponentPath, {skipLocationChange: true}).then(
      () => this.router.navigate([baseComponentPath, resource.id, 'edit'])
    );
  }

  protected actionsForError(error) {
    toastr.error('Ocorreu um erro ao processar sua solicitação!');
    this.submittingForm = false;

    if (error.status === 422) {
    this.serverErrorMessages = JSON.parse(error._body).errors;
    } else {
    this.serverErrorMessages = ['Falha na comunicação com o servidor. Por favor, tente mais tarde.']
    }
  }

  protected abstract buildResourceForm();
}
