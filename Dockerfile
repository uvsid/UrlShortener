#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#Use this Dockerfile run the published app (in /publish) 



FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

WORKDIR /publish
COPY /publish .
ENTRYPOINT ["dotnet", "UrlShortner.Service.dll"]
