FROM microsoft/aspnetcore-build:3.0 AS build-env
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:3.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["ComicEngine.Client", "ComicEngine.Client.dll"]