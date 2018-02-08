// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  backend: 'http://localhost:5800',
  //stage
  // backend: 'http://ec2-52-57-252-204.eu-central-1.compute.amazonaws.com/SynkwiseAPI'
};