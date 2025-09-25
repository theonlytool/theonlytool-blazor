FROM mcr.microsoft.com/dotnet/aspnet:10.0@sha256:97fd62765599e830f70d05ebf086aa341b59bc5f6be00d0ad0ba1e04f8614b35 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0@sha256:331344301c39a342ca0c42cb8a9cf1448a3c5a4aa609b8d524f8e3c6725886b3 AS build
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
