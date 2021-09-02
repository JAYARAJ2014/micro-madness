# micro-madness

Sample Micro Services architecture implementation using AspNet Core and various data sources (Mongo, Redis, PostgreSQL). 

> Credits and Thanks to @mehmetozkaya for his course that walks through this development process.  See his git hub here: https://github.com/mehmetozkaya/AspnetMicroservices

### Technologies

- .NET 5 (Web API, Entity Framework, Dapper, AutoMapper)
- Docker  
- MongoDB
- Redis
- PostgreSQL
- gRPC

## To Run the show

Once the code is cloned , navigate to the `src` directory under the project.
Type the following command to standup the entire application suite locally

`docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d`

Type the following command to stop

`docker-compose -f docker-compose.yml -f docker-compose.override.yml down`

* To view portainer page goto `http://localhost:9000/#`
* To view the catalog api documentation goto `http://localhost:8000/swagger/index.html`
* To view the basket api documentation goto `http://localhost:8001/swagger/index.html`
* To view the discount api documentation goto `http://localhost:8002/swagger/index.html`
* To view pgadmin: `http://localhost:5050/`


#### Please note that the docker volume for Portainer in this example is set to Linux. `- /var/run/docker.sock:/var/run/docker.sock` . Look at portainer documentation for how to set this up for Windows / Mac etc.
