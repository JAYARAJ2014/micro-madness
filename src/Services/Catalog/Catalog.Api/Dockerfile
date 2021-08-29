# Base image of the runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base 
# Where container will copy the files of the project
WORKDIR /app
# What port to expose
EXPOSE 80
RUN ls -l 
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build 
WORKDIR /src
RUN ls -l
COPY ["Catalog.Api.csproj", "Services/Catalog/Catalog.Api/"]
#RUN dotnet restore "Services/Catalog/Catalog.Api/Catalog.Api.csproj"
COPY . Services/Catalog/Catalog.Api
WORKDIR "/src/Services/Catalog/Catalog.Api"
RUN pwd
RUN ls -l
RUN dotnet build "Catalog.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR  /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Catalog.Api.dll"]

