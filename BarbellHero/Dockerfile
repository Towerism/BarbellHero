FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

FROM microsoft/aspnetcore-build:2.0 AS restore
WORKDIR /src
COPY BarbellHero.csproj .
RUN dotnet restore

FROM restore AS build
COPY . .
RUN dotnet build BarbellHero.csproj -c Release -o /app

FROM build AS publish
RUN npm install -g yarn
RUN dotnet publish BarbellHero.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV PORT 80
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BarbellHero.dll
