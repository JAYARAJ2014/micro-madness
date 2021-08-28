# Base image of the runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base 
# Where container will copy the files of the project
WORKDIR /app
# What port to expose
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build 
WORKDIR /src
COPY ["Services/Cagalog/Catalog.Api/Catalog.Api.csproj", "Services/Cagalog/Catalog.Api/"]
RUN dotnet restore "Services/Cagalog/Catalog.Api/Catalog.Api.csproj"
COPY . .
WORKDIR "/src/Services/Cagalog/Catalog.Api"
RUN dotnet build "Catalog.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR  /app
COPY --from=publi /app/publish .
ENTRYPOINT ["dotnet","Catalog.Api.dll"]

