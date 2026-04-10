FROM mcr.microsoft.com/dotnet/aspnet:10.0@sha256:c433886fdfe33c6427966a412328867b2be9a64f540a105d08943c2dc6fba39b AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0@sha256:127d7d4d601ae26b8e04c54efb37e9ce8766931bded0ee59fcd799afd21d6850 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/theonlytool/theonlytool.csproj", "src/theonlytool/"]
RUN dotnet restore "src/theonlytool/theonlytool.csproj"
COPY . .
WORKDIR "/src/src/theonlytool"
RUN dotnet build "./theonlytool.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./theonlytool.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "theonlytool.dll"]
