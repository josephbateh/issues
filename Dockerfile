FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /app

# Copy csproj file
COPY Issues/*.csproj ./Issues/
COPY Issues/. ./Issues/
WORKDIR /app/Issues
RUN rm -rf bin obj
RUN dotnet restore

# Build application
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime
WORKDIR /app
COPY --from=build /app/Issues/out ./
ENTRYPOINT ["dotnet", "Issues.dll"]
