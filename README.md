# micro-madness

Sample Micro Service

\***\* Setting up MongoDB using Docker \*\***
//get mongo
docker pull mongo
//running the docker container with mongo
docker run -d -p 27017:27017 --name shopping-mongo mongo

//for troubleshooting

docker logs shopping-mongo

docker logs -f shopping-mongo

//logon interactively to docker container
docker exec -it shopping-mongo /bin/bash

//from .NET Cli use the following command to see packages installed.
dotnet list package

to dealwith mongobd we will need MongoDB.Driver package.

//Use Dockerfile to define the pull, build and publish for the core api.

docker build .

//Docker Compose to run and stop the entire suite of apps

docker-compose -f docker-compose.yml -f docker-compose.override.yml down
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

//Redis
docker run -d -p 6379:6379 --name aspnet-redis redis

1
-- Now we can open interactive terminal for redis

docker exec -it aspnetrun-redis /bin/bash

2
-- After that, we are able to run redis commands.
Let me try with

redis-cli
ping - PONG

set key value
get key
set name mehmet
get name

set <key> <value> [EX seconds|PX milliseconds|EXAT timestamp|PXAT milliseconds-time
