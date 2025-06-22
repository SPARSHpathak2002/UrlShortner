FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /source

COPY . .

RUN dotnet restore

RUN dotnet publish --no-restore -c Release -o app

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

COPY --from=build ../source/app /app

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

CMD ["/usr/bin/dotnet","UrlShortner.dll"]