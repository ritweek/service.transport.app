#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["service.transport.api/service.transport.api.csproj", "service.transport.api/"]
COPY ["service.transport.data/service.transport.data.csproj", "service.transport.data/"]
COPY ["service.transport.common/service.transport.common.csproj", "service.transport.common/"]
RUN dotnet restore "service.transport.api/service.transport.api.csproj"
COPY . .
WORKDIR "/src/service.transport.api"
RUN dotnet build "service.transport.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "service.transport.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service.transport.api.dll"]
