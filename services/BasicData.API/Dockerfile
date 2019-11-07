FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["services/BasicData.API/BasicData.API.csproj", "services/BasicData.API/"]
RUN dotnet restore "services/BasicData.API/BasicData.API.csproj"
COPY . .
WORKDIR "/src/services/BasicData.API"
RUN dotnet build "BasicData.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicData.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicData.API.dll"]