import { Component, Input, OnInit } from '@angular/core';
import { tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { FileUploadService } from '../file-upload.service';

@Component({
  selector: 'app-upload-photo',
  templateUrl: './upload-photo.component.html',
  styleUrls: ['./upload-photo.component.css']
})
export class UploadPhotoComponent implements OnInit {

  file: File = null;

  @Input('EmployeeID') employeeID: number;
  @Input('TeamMemberPhoto') teamMemberPhoto: string;

  getUrlPhoto

  constructor(private fileUploadService: FileUploadService) { }

  ngOnInit(): void {

  }

  getTeamMemberPhoto() {
    return this.teamMemberPhoto ? `${environment.baseAPIUrl}Resources/Photos/${this.teamMemberPhoto}` : '';
  }
  
  onChange(event) {
    this.file = event.target.files[0];

    this.fileUploadService.upload(this.employeeID, this.file)
      .pipe(
        tap((result) => {
          this.teamMemberPhoto = result.fileSystemNameWithExtenstion;
        }))
      .subscribe();
  }
}
