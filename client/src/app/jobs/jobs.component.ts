import { Component, OnInit } from '@angular/core';
import { Job } from '../models/job';

const JOBS: Job[] = [
  { id: '', title: 'PO', company: 'Microsoft' },
  { id: '', title: 'Scrum Master', company: 'Google' },
  { id: '', title: 'Delivery Manager', company: 'Apple' },
  { id: '', title: 'SQA', company: 'Facebook' },
  { id: '', title: 'Software Engineer', company: 'Github' }
];

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
  dataSource = JOBS;

  constructor() { }

  ngOnInit(): void {

  }
}
