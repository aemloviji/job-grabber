import fetch from 'node-fetch';

const baseUrl = 'https://jobs.github.com/positions.json';

export default async function fetchGithubJobs(): Promise<void> {
    console.log('fetching github jobs started');

    const jobsPool = [];
    let hasJob = false, pageNum = 0;

    do {
        const gitHubResponse = await fetch(`${baseUrl}?page=${pageNum}`);
        const jobs = await gitHubResponse.json();
        jobsPool.push(...jobs);
        console.log('jobs found', jobs.length);

        hasJob = jobs.length > 0;
        pageNum++;
    } while (hasJob)

    console.log('got', jobsPool.length, 'jobs in total');
}
