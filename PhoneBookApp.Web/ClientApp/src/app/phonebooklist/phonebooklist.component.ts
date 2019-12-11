import { Component, ViewChild, OnInit } from '@angular/core';
import {MatInputModule, MatTableModule,MatPaginatorModule,MatSortModule,MatTableDataSource, MatSnackBar } from '@angular/material';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import { PhonebookformComponent } from '../phonebookform/phonebookform.component';

import { PhoneBookService } from '../services/phonebook.service';
import { IPhoneNumber } from '../model/phonenumber';
import { IPhoneBook } from '../model/phonebook';
import { DBOperation } from '../shared/DBOperation';
import { Global } from '../shared/Global';

@Component({
  selector: 'app-phonebooklist',
  templateUrl: './phonebooklist.component.html',
  styleUrls: ['./phonebooklist.component.css']
})
export class PhoneBooklistComponent implements OnInit {
  phonenumbers: IPhoneNumber[];
  contact: IPhoneNumber;
  phonebook: IPhoneBook;
  loadingState: boolean;
  dbops: DBOperation;
  modalTitle: string;
  modalBtnTitle: string;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  // set columns that will need to show in listing table
  displayedColumns = ['name', 'email', 'number','action'];
  // setting up datasource for material table
  dataSource = new MatTableDataSource<IPhoneNumber>();
  dataSourcePhone = new MatTableDataSource<IPhoneBook>();

  constructor(public snackBar: MatSnackBar, private _contactService: PhoneBookService, private dialog: MatDialog) { }

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    this.loadingState = true;
    this.loadPhoneBooks();
    this.getPhoneBook();
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(PhonebookformComponent, {
      width: '500px',
      data: { dbops: this.dbops, modalTitle: this.modalTitle, modalBtnTitle: this.modalBtnTitle, contact: this.contact }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result === 'success') {
        this.loadingState = true;
        this.loadPhoneBooks();
        switch (this.dbops) {
          case DBOperation.create:
            this.showMessage('Data successfully added.');
            break;
          case DBOperation.update:
            this.showMessage('Data successfully updated.');
            break;
          case DBOperation.delete:
            this.showMessage('Data successfully deleted.');
            break;
        }
      } else if (result === 'error') {
        this.showMessage('There is some issue in saving records, please contact to system administrator!');
      } else {
       // this.showMessage('Please try again, something went wrong');
      }
    });
  }

  loadPhoneBooks(): void {
    this._contactService.getAllPhoneNumbers(Global.BASE_USER_ENDPOINT + 'getAllPhoneNumbers')
      .subscribe(phonenumbers => {
        this.loadingState = false;
        this.dataSource.data = phonenumbers;
      });
  }

  getPhoneBook(): void {
    this._contactService.getPhoneBook(Global.BASE_USER_ENDPOINT + 'getPhoneBook')
      .subscribe(phonebook => {
        this.loadingState = false;
        this.dataSourcePhone.data = phonebook;
      });
  }

  addPhoneNumber() {
    this.dbops = DBOperation.create;
    this.modalTitle = 'Add New Phone Number';
    this.modalBtnTitle = 'Add';
    this.openDialog();
  }
  editPhoneNumber(id: number) {
    this.dbops = DBOperation.update;
    this.modalTitle = 'Edit Phone Number';
    this.modalBtnTitle = 'Update';
    this.contact = this.dataSource.data.filter(x => x.id === id)[0];
    this.openDialog();
  }
  deletePhoneNumber(id: number) {
    this.dbops = DBOperation.delete;
    this.modalTitle = 'Confirm to Delete ?';
    this.modalBtnTitle = 'Delete';
    this.contact = this.dataSource.data.filter(x => x.id === id)[0];
    this.openDialog();
  }
  showMessage(msg: string) {
    this.snackBar.open(msg, '', {
      duration: 3000
    });
  }
}

