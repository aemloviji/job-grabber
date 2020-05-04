# Job Grabber system

## Overview

JG system contains of 3 project.

- **Worker** - Communicates with [GitHub Jobs API](https://jobs.github.com/api) to grab positions and store in persistance storage.
- **Backend** - Interracts with Worker's DB to provides job information to frontend project.
- **Frontend** - Interracts with backend to get jobs and show in UI.

## Worker

Developed using [Node.js](https://nodejs.org/). \
Read more about worker project [here](./worker/README.md)

## Backend

Developed using [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-3.1). \
Read more about worker project [here](./backend/README.md)

## Frontend

Developed using [Angular 9 framework](https://angular.io/). \
Read more about client project [here](./client/README.md)

## How to start the whole system

- Start Worker(Job Grabber scheduler)

```bash
 cd ./worker/
 npm run start:dev
```

- Start API(backend)

```bash
 cd ./backend/src
 dotnet run
```

- Start frontend

```bash
 cd ./client/src
 npm start
```
