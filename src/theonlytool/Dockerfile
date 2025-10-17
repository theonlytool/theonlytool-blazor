FROM mcr.microsoft.com/dotnet/aspnet:10.0@sha256:5b201bc57156a9f70d58a86112dc7a8217cf3a885740a8fe914b0782ee09647e AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0@sha256:ed46c853a4f100ba7aab2394e9fb9f9b8989e93346b04632dbce11e5da7623d8 AS build
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
