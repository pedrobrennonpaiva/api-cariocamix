#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CariocaMix.API/CariocaMix.API.csproj", "CariocaMix.API/"]
COPY ["CariocaMix.Services/CariocaMix.Service.csproj", "CariocaMix.Services/"]
COPY ["CariocaMix.Domain/CariocaMix.Domain.csproj", "CariocaMix.Domain/"]
COPY ["CariocaMix.Utils/CariocaMix.Utils.csproj", "CariocaMix.Utils/"]
COPY ["CariocaMix.CrossCutting/CariocaMix.CrossCutting.csproj", "CariocaMix.CrossCutting/"]
COPY ["CariocaMix.Repository/CariocaMix.Repository.csproj", "CariocaMix.Repository/"]
RUN dotnet restore "CariocaMix.API/CariocaMix.API.csproj"
COPY . .
WORKDIR "/src/CariocaMix.API"
RUN dotnet build "CariocaMix.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CariocaMix.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "CariocaMix.API.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet "CariocaMix.API.dll"