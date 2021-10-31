# ApiCodingTest

## Startup

### Postgres for local development

1. `docker pull postgres`
2. `mkdir -p $HOME/docker/volumes/postgres`
3. `docker run --rm --name pg-docker -e POSTGRES_PASSWORD=xxx -d -p 5432:5432 -v $HOME/docker/volumes/postgres:/var/lib/postgresql/data postgres`

### Required Env variables - to be populated before starting the API

- "API_BASE_URL"
- "API_ACCESS_TOKEN"
- "CONNECTION_STRING"
