FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RIdeCompanion/RIdeCompanion.csproj", "RIdeCompanion/"]
RUN dotnet restore "RIdeCompanion/RIdeCompanion.csproj"
COPY . .
WORKDIR "/src/RIdeCompanion"
RUN dotnet build "RIdeCompanion.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RIdeCompanion.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RIdeCompanion.dll"]