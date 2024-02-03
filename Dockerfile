#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
# EXPOSE 443

ENV ENV=Development
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["N5_API.csproj", "."]
COPY ["N5_API.Project.Base/N5_API.Project.Base.csproj", "N5_API.Project.Base/"]
COPY ["N5_API.Project.MiddlewareSupport/N5_API.Project.MiddlewareSupport.csproj", "N5_API.Project.MiddlewareSupport/"]
COPY ["N5_API.Project.RedisMiddleware/N5_API.Project.RedisMiddleware.csproj", "N5_API.Project.RedisMiddleware/"]
COPY ["N5_API.Project.Services/N5_API.Project.Services.csproj", "N5_API.Project.Services/"]
COPY ["N5_API.Project.Entities/N5_API.Project.Entities.csproj", "N5_API.Project.Entities/"]
COPY ["N5_API.Project.Models/N5_API.Project.Models.csproj", "N5_API.Project.Models/"]
COPY ["N5_API.Project.UnitOfWork/N5_API.Project.UnitOfWork.csproj", "N5_API.Project.UnitOfWork/"]
COPY ["N5_API.Project.Repositories/N5_API.Project.Repositories.csproj", "N5_API.Project.Repositories/"]
RUN dotnet restore "./././N5_API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./N5_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./N5_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5_API.dll"]