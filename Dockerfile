FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY MessagingPlatformBackend.csproj .
RUN dotnet restore MessagingPlatformBackend.csproj

COPY . .
RUN dotnet publish MessagingPlatformBackend.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "MessagingPlatformBackend.dll"]