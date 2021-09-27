### Notes
- Database used was a Postgres Docker container with default settings. Connection string in settings is not real, though it probably shouldn't be committed either.
- Implemented the pokemon endpoint with the example style above (`/pokemon?hp[gte]=100&defense[lte]=200`). Though, perhaps this endpoint would have been a good candidate for a json body.
- Items that I did not have a chance to implement / finish:
* Authenticate/Authorization middleware
* Unit tests. I finished the repository tests and the service tests. But didn't go in depth testing the other components (e.g. controller, dependency injection).
* Clean up database collation and/or the ToLower() code for Name and Type1/2.

In order to get this running:
* Install Docker (https://www.docker.com)
* `cd` into the root directory and run `docker-compose up`. This will build and publish the app and bring up the database.
* In order to migrate the pokemon: inside the container `cd` into `src/DataAccess` and run the following:
```
RUN dotnet tool install -g dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
dotnet ef database update -s ../Api/PokedexApi.Api.csproj
```
