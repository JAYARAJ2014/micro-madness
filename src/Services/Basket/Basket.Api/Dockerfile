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
COPY ["Basket.Api.csproj", "Services/Basket/Basket.Api/"]
RUN dotnet restore "Services/Basket/Basket.Api/Basket.Api.csproj"
COPY . Services/Basket/Basket.Api
WORKDIR "/src/Services/Basket/Basket.Api"
RUN dotnet build "Basket.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR  /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Basket.Api.dll"]

