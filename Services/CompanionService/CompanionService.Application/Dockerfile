FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/CompanionService/CompanionService.Application/CompanionService.Application.csproj", "Services/CompanionService/CompanionService.Application/"]
RUN dotnet restore "Services/CompanionService/CompanionService.Application/CompanionService.Application.csproj"
COPY . .
WORKDIR "/src/Services/CompanionService/CompanionService.Application"
RUN dotnet build "CompanionService.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CompanionService.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanionService.Application.dll"]
