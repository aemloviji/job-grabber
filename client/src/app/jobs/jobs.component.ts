import { Component, OnInit } from '@angular/core';
import { Job } from '../models/job';
import { JobService } from '../services/job.service';
import { MatDialog } from '@angular/material/dialog';
import { JobDetailsDialogComponent } from '../job-details-dialog/job-details-dialog.component';

interface ComponentProps {
  isLoading: boolean;
  errorMessage: string;
}

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobsComponent implements OnInit {
  props: ComponentProps = { isLoading: false, errorMessage: '' };
  jobs: Job[] = [];

  constructor(private jobService: JobService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.jobService.list()
      .subscribe(
        v => this.jobs = v,
        e => this.props.errorMessage = e,
        () => this.props.isLoading = false);
  }

  readMore(id: string): void {
    const dialogRef = this.dialog.open(JobDetailsDialogComponent, {
      data: this.jobs.find(j => j.id === id)
    });
  }
}
