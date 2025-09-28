FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env

WORKDIR /app

COPY ./src .

WORKDIR /app/Api

RUN dotnet restore

RUN dotnet publish -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

RUN apt-get update

RUN apt install libreadline8 libsqlite3-0 readline-common sqlite3

COPY --from=build-env /app/out .
COPY --from=build-env /app/Api/app.db .

ENTRYPOINT ["dotnet", "Api.dll"]