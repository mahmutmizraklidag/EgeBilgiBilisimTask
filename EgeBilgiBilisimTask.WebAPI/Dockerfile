#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EgeBilgiBilisimTask.WebAPI/EgeBilgiBilisimTask.WebAPI.csproj", "EgeBilgiBilisimTask.WebAPI/"]
COPY ["EgeBilgiBilisimTask.Service/EgeBilgiBilisimTask.Service.csproj", "EgeBilgiBilisimTask.Service/"]
COPY ["EgeBilgiBilisimTask.Data/EgeBilgiBilisimTask.Data.csproj", "EgeBilgiBilisimTask.Data/"]
COPY ["EgeBilgiBilisimTask.Entities/EgeBilgiBilisimTask.Entities.csproj", "EgeBilgiBilisimTask.Entities/"]
RUN dotnet restore "EgeBilgiBilisimTask.WebAPI/EgeBilgiBilisimTask.WebAPI.csproj"
COPY . .
WORKDIR "/src/EgeBilgiBilisimTask.WebAPI"
RUN dotnet build "EgeBilgiBilisimTask.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EgeBilgiBilisimTask.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EgeBilgiBilisimTask.WebAPI.dll"]