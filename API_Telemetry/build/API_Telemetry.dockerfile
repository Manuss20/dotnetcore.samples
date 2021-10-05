FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /src/API_Telemetry.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY /src/ ./
RUN dotnet publish -c Release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app
COPY --from=build-env /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "API_Telemetry.dll"]