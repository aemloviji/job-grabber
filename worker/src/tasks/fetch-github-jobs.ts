import fetch from 'node-fetch';
import save from '../storage'

const baseUrl = 'https://jobs.github.com/positions.json';

export default async function fetchGithubJobs(): Promise<void> {
    console.log('fetching github jobs started');

    const allJobs = [];
    let hasJob = false, pageNum = 0;

    do {
        const gitHubResponse = await fetch(`${baseUrl}?page=${pageNum}`);
        const jobs = await gitHubResponse.json();
        allJobs.push(...jobs);
        console.log('jobs found', jobs.length);

        hasJob = jobs.length > 0;
        pageNum++;
    } while (hasJob)

    console.log('got', allJobs.length, 'jobs in total');

    const redisResult = await save(allJobs);
    console.log('storing in redis:', redisResult);
}