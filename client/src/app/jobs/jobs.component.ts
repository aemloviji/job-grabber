import { Component, OnInit } from '@angular/core';
import { Job } from '../models/job';
import { JobService } from '../services/job.service';

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
  props: ComponentProps = {
    isLoading: false,
    errorMessage: ''
  };

  displayedColumns: string[] = ['#', 'title', 'company'];
  dataSource: Job[] = [];
  errorMessage = '';
  isLoading = true;

  constructor(private jobService: JobService) { }

  ngOnInit(): void {
    this.jobService.list()
      .subscribe(
        s => this.dataSource = s,
        e => this.errorMessage = e,
        () => this.isLoading = false);
  }
}
