FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 5011

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
COPY UszyjMaseczke.WebApi/appsettings.Production.json UszyjMaseczke.WebApi/appsettings.json
RUN dotnet restore
WORKDIR /src/UszyjMaseczke.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UszyjMaseczke.WebApi.dll"]
