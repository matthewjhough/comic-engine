FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# copy everything and build the project
COPY . ./
# RUN dotnet restore ComicEngine.Common/*.csproj
# RUN dotnet publish ComicEngine.Common/*.csproj -c Release -o out
RUN dotnet restore ComicEngine.Api/*.csproj
RUN dotnet publish ComicEngine.Api/*.csproj -c Release -o out

# build runtime image
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "ComicEngine.Api.dll"]