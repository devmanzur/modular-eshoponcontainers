FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["API/Manzur.eShopOnContainers.API/Manzur.eShopOnContainers.API.csproj", "src/API/Manzur.eShopOnContainers.API/"]
#left side is the local file relative location, right side is the location inside docker image file
#the restore command must be executed where the copy command copied the files otherwise it wont work
RUN dotnet restore "src/API/Manzur.eShopOnContainers.API/Manzur.eShopOnContainers.API.csproj"
COPY . .
WORKDIR "/src/API/Manzur.eShopOnContainers.API"
RUN dotnet build "Manzur.eShopOnContainers.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Manzur.eShopOnContainers.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Manzur.eShopOnContainers.API.dll"]
