# Worker

Communicates with [GitHub Jobs API](https://jobs.github.com/api) to grab jobs and store in persistance storage. \
[Prerequisites](#prerequisites) \
[Used libraries](#used-libraries) \
[Used packages](#used-packages) \
[Scripts defined in package.json file](#scripts-defined-in-package.json-file) \
[ESLint for TypeScript](#eslint-for-typescript) \
[Format using Prettier](#Format-using-Prettier)

## Prerequisites

- [Node.js](https://nodejs.org/) - Node.js® is a JavaScript runtime built on Chrome's V8 JavaScript engine.

## Used libraries

- [Cron](https://www.npmjs.com/package/cron) - Cron is a tool that allows you to execute something on a schedule.
- [node-fetch](https://www.npmjs.com/package/node-fetch) - A light-weight module that brings `window.fetch` to Node.js

## Used packages

**Note: https://khalilstemmler.com/blogs/typescript/node-starter-project/ was used as a reference**

- First add package.json file into the root folder

```
    npm init -y
```

- [typescript](https://khalilstemmler.com/blogs/typescript/node-starter-project/) - After installing TypeScript as a dev dependency, we get access to the command line TypeScript compiler through the tsc command.

```
    npm install typescript --save-dev
```

- [@types/node](https://khalilstemmler.com/blogs/typescript/node-starter-project/) - Install ambient Node.js types for TypeScript

```
    npm install @types/node --save-dev
```

- **Create a tsconfig.json** - Where we define the TypeScript compiler options.

```
    npx tsc --init --rootDir src --outDir build \
    --esModuleInterop --resolveJsonModule --lib es6 \
    --module commonjs --allowJs true --noImplicitAny true
```

- [ts-node](https://www.npmjs.com/package/ts-node) - Is a package for running TypeScript code directly without having to wait for it be compiled.

```
    npm install --save-dev ts-node
```

- [nodemon](https://www.npmjs.com/package/nodemon) - Is a tool that helps develop node.js based applications by automatically restarting the node application when file changes in the directory are detected. See `scripts > start:dev` section in [package.json](package.json) file where nodeman was used.

```
    npm install --save-dev nodemon
```

- **Create a nodemon.json** - Pay attention to `exec` property. It indicates that nodeman runs TS file using `ts-node` package added in previous step.

```json
{
  "watch": ["src"],
  "ext": ".ts,.js",
  "ignore": [],
  "exec": "ts-node ./src/index.ts"
}
```

- [rimraf](https://www.npmjs.com/package/rimraf) - A cross-platform tool that acts like the `rm -rf` command Management. Used for NPM build script. See also `scripts > build` section in [package.json](package.json) file.

## Scripts defined in package.json file

- Starts the application in development using `nodemon` and `ts-node` to do cold reloading.

```
    npm run start:dev
```

- Builds the app by cleaning the folder first.

```
    npm run build
```

- Starts the app in production by first building the project with `npm run build` mentioned previously, and then executes the compiled JavaScript at `dist/index.js`. `dist` folder was defined as output folder in [tsconfig.json file](./tsconfig.json)

```
    npm run start
```

- Starts linting using rules defined in [.eslintrc](./.eslintrc) file. See how to configure [ESLint for TypeScript](#ESLint-for-TypeScript).

```
    npm run lint
```

## ESLint for TypeScript

- Run the following commands to setup ESLint in your TypeScript project.

```
    npm install --save-dev eslint @typescript-eslint/parser @typescript-eslint/eslint-plugin

```

- Create an `.eslintrc` file in the root of the project with below config

```json
{
  "root": true,
  "parser": "@typescript-eslint/parser",
  "plugins": ["@typescript-eslint"],
  "extends": [
    "eslint:recommended",
    "plugin:@typescript-eslint/eslint-recommended",
    "plugin:@typescript-eslint/recommended"
  ]
}
```

- Create an `.eslintignore` in order to prevent ESLint from linting stuff we don't want it to with content attached below. _Note: dist is a folder where compiles code will be stored. That is why we are ignoring it from linting_

```
    node_modules
    dist
```

### Format using Prettier.

- Install [Prettier](https://prettier.io/) as a dev dependency.

```
    npm install --save-dev prettier
```

- Create `.prettierrc` file with below content.

```json
{
  "semi": true,
  "trailingComma": "none",
  "singleQuote": true,
  "printWidth": 80
}
```

- See section [script defined in package.json file](#scripts-defined-in-package.json-file) in order to know how to run prettier manually.

### Format using ESLint and Prettier.

- Install `eslint-config-prettier` and `eslint-plugin-prettier` as a dev dependency.

```
    npm install --save-dev eslint-config-prettier eslint-plugin-prettier
```

- Update `.eslintrx` file with below values.

```json
{
  "root": true,
  "parser": "@typescript-eslint/parser",
  "plugins": ["@typescript-eslint", "prettier"],
  "extends": [
    "eslint:recommended",
    "plugin:@typescript-eslint/eslint-recommended",
    "plugin:@typescript-eslint/recommended",
    "prettier"
  ]
}
```

- Run ```npm run lint``` in order to see the result.
