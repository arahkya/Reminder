FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Arahk.Reminder.WebApi.csproj .
RUN dotnet restore
COPY . .
# RUN dotnet build Arahk.Reminder.WebApi.csproj -c Release -o /app/build --no-restore
# RUN dotnet publish Arahk.Reminder.WebApi.csproj -c Release -o /app/publish --no-build
RUN dotnet publish Arahk.Reminder.WebApi.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Arahk.Reminder.WebApi.dll"]
