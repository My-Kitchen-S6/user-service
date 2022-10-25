﻿FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["user-service.csproj", "./"]
RUN dotnet restore "user-service.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "user-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user-service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user-service.dll"]
