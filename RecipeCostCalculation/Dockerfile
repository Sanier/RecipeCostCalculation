#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RecipeCostCalculation.csproj", "."]
COPY ["../RecipeCostCalculation.Domain/RecipeCostCalculation.Domain.csproj", "../RecipeCostCalculation.Domain/"]
COPY ["../RecipeCostCalculation.Service/RecipeCostCalculation.Service.csproj", "../RecipeCostCalculation.Service/"]
COPY ["../RecipeCostCalculation.DAL/RecipeCostCalculation.DAL.csproj", "../RecipeCostCalculation.DAL/"]
RUN dotnet restore "./././RecipeCostCalculation.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./RecipeCostCalculation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RecipeCostCalculation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipeCostCalculation.dll"]