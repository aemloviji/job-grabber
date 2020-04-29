
import redis from 'redis';
import { promisify } from 'util';

const redisClient = redis.createClient();
const setAsync = promisify(redisClient.set).bind(redisClient);

export default async function save(data: any): Promise<unknown> {
    let result = null;
    try {
        result = await setAsync('github', JSON.stringify(data));
    }
    catch (e) {
        console.error('Data not stored in Redis: ', e);
    }

    return result;
}