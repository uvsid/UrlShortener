#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#Use this Dockerfile run the published app (in /publish) 



FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /publish
# COPY ["Server/UrlShortner.Service.csproj", "Server/"]
# COPY ["Client/UrlShortner.TestClient.csproj", "Client/"]
# COPY ["Shared/UrlShortner.Common.csproj", "Shared/"]
# RUN dotnet restore "Server/UrlShortner.Service.csproj"
#COPY . .
# WORKDIR "/src/Server"
# RUN dotnet build "UrlShortner.Service.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "UrlShortner.Service.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
COPY /publish .
ENTRYPOINT ["dotnet", "UrlShortner.Service.dll"]
