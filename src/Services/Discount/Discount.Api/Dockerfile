# Base image of the runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base 
# Where container will copy the files of the project
WORKDIR /app
# What port to expose
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build 
WORKDIR /src


COPY ["Services/Discount/Discount.Api/Discount.Api.csproj", "Services/Discount/Discount.Api/"]
RUN ls -l
RUN dotnet restore "Services/Discount/Discount.Api/Discount.Api.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Discount.Api"

RUN dotnet build "Discount.Api.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Discount.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR  /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Discount.Api.dll"]

