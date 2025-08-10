FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Kurochou.API/Kurochou.API.csproj", "Kurochou.API/"]
COPY ["Kurochou.DI/Kurochou.DI.csproj", "Kurochou.DI/"]
COPY ["Kurochou.Domain/Kurochou.Domain.csproj", "Kurochou.Domain/"]
COPY ["Kurochou.Infra/Kurochou.Infra.csproj", "Kurochou.Infra/"]

RUN dotnet restore "Kurochou.API/Kurochou.API.csproj"

COPY . .

WORKDIR "/src/Kurochou.API"
RUN dotnet build "Kurochou.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Kurochou.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kurochou.API.dll"]
