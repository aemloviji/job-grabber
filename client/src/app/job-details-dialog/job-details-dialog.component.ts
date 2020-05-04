import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Job } from '../models/job';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details-dialog.component.html',
  styleUrls: ['./job-details-dialog.component.scss']
})
export class JobDetailsDialogComponent {

  constructor(public dialogRef: MatDialogRef<JobDetailsDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Job) { }

}
