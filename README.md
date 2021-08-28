# micro-madness
Sample Micro Service


**** Setting up MongoDB using  Docker  ****
//get mongo 
docker pull mongo 
//running the docker container with mongo 
docker run -d -p 27017:27017 --name shopping-mongo mongo

//for troubleshooting 

docker logs  shopping-mongo

docker logs  -f shopping-mongo

//logon interactively to docker container 
docker exec -it shopping-mongo /bin/bash 

//from .NET Cli use the following command to see packages installed. 
dotnet list package

to dealwith mongobd we will need MongoDB.Driver package. 


