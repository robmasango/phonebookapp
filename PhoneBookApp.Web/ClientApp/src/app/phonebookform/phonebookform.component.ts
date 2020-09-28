import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { FormBuilder, Validators } from '@angular/forms';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, AUTOCOMPLETE_PANEL_HEIGHT } from '@angular/material';

import { PhoneBooklistComponent } from '../phonebooklist/phonebooklist.component';

import { PhoneNumber } from '../model/phonenumber';
import { PhoneBookService } from '../services/phonebook.service';
import { DBOperation } from '../shared/DBOperation';
import { Global } from '../shared/Global';

@Component({
  selector: 'app-phonebookform',
  templateUrl: './phonebookform.component.html',
  styleUrls: ['./phonebookform.component.css']
})

export class PhonebookformComponent implements OnInit {
  msg: string;
  indLoading = false;
  phonenumberFrm: FormGroup;
  listFilter: string;
  selectedOption: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private _contactService: PhoneBookService,
    public dialogRef: MatDialogRef<PhoneBooklistComponent>) { }

  ngOnInit() {
    // built contact form
    
    this.phonenumberFrm = this.fb.group({
      id: [''],
      phoneBookId: [''],
      name: ['', [Validators.required, Validators.maxLength(50)]],
        email: ['', [Validators.required, Validators.email]],
        number: ['', [Validators.required, Validators.pattern("^((\\+27-?))?[0-9]{9}$")]]
      //number: ['', [Validators.required, Validators.pattern('^(\+27|0)[6-8][0-9]{8}$')]]
    });

    // subscribe on value changed event of form to show validation message
    this.phonenumberFrm.valueChanges.subscribe(data => this.onValueChanged(data));
    this.onValueChanged();

    if (this.data.dbops === DBOperation.create) {
      this.phonenumberFrm.reset();
    } else {
      this.phonenumberFrm.setValue(this.data.contact);
    }
    this.SetControlsState(this.data.dbops === DBOperation.delete ? false : true);
  }
  // form value change event
  onValueChanged(data?: any) {
    if (!this.phonenumberFrm) { return; }
    const form = this.phonenumberFrm;
    // tslint:disable-next-line:forin
    for (const field in this.formErrors) {
      // clear previous error message (if any)
      this.formErrors[field] = '';
      const control = form.get(field);
      // setup custom validation message to form
      if (control && control.dirty && !control.valid) {
        const messages = this.validationMessages[field];
        // tslint:disable-next-line:forin
        for (const key in control.errors) {
          this.formErrors[field] += messages[key] + ' ';
        }
      }
    }
  }
  // form errors model
  // tslint:disable-next-line:member-ordering
  formErrors = {
    'name': '',
    'email': '',
    'number': ''
  };
  // custom valdiation messages
  // tslint:disable-next-line:member-ordering
  validationMessages = {
    'name': {
      'maxlength': 'Name cannot be more than 50 characters long.',
      'required': 'Name is required.'
    },
    'email': {
      'email': 'Invalid email format.',
      'required': 'Email is required.'
    },
    'number': {
      'required': 'Number is required.'
    }

  };
  onSubmit(formData: any) {
    const contactData = this.mapDateData(formData.value);
    switch (this.data.dbops) {
      case DBOperation.create:
        this._contactService.addPhoneNumber(Global.BASE_USER_ENDPOINT + 'addPhoneNumber', contactData).subscribe(
          data => {
            // Success
            if (data.message) {
              this.dialogRef.close('success');
            } else {
              this.dialogRef.close('error');
            }
          },
          error => {
            this.dialogRef.close('error');
          }
        );
        break;
      case DBOperation.update:
        this._contactService.updatePhoneNumber(Global.BASE_USER_ENDPOINT + 'updatePhoneNumber', contactData.id, contactData).subscribe(
          data => {
            // Success
            if (data.message) {
              this.dialogRef.close('success');
            } else {
              this.dialogRef.close('error');
            }
          },
          error => {
            this.dialogRef.close('error');
          }
        );
        break;
      case DBOperation.delete:
        this._contactService.deletePhoneNumber(Global.BASE_USER_ENDPOINT + 'deletePhoneNumber', contactData.id).subscribe(
          data => {
            // Success
            if (data.message) {
              this.dialogRef.close('success');
            } else {
              this.dialogRef.close('error');
            }
          },
          error => {
            this.dialogRef.close('error');
          }
        );
        break;
    }
  }
  SetControlsState(isEnable: boolean) {
    isEnable ? this.phonenumberFrm.enable() : this.phonenumberFrm.disable();
  }

    mapDateData(contact: PhoneNumber): PhoneNumber {
        contact.id = contact.id === null ? 0 : contact.id;
      contact.phoneBookId = contact.phoneBookId === null ? 0 : contact.phoneBookId;
        contact.number = contact.number.toString();

    return contact;
  }
}
