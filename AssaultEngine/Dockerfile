FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AssaultEngine/AssaultEngine.csproj", "AssaultEngine/"]
RUN dotnet restore "AssaultEngine/AssaultEngine.csproj"
COPY . .
WORKDIR "/src/AssaultEngine"
RUN dotnet build "AssaultEngine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AssaultEngine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssaultEngine.dll"]
