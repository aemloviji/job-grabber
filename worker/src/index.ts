import { CronJob } from 'cron';
import fetchGithubJobs from './tasks/fetch-github-jobs';

const job = new CronJob('* * * * *', function () {
    fetchGithubJobs();
}, null, true, 'America/Los_Angeles');
job.start();