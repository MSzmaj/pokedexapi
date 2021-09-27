FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Api/PokedexApi.Api.csproj", "Api/"]
RUN dotnet restore "Api/PokedexApi.Api.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "src/Api/PokedexApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Api/PokedexApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokedexApi.Api.dll"]