#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Adapters/Driving/Api/QuickOrder.Adapters.Driving.Api.csproj", "Adapters/Driving/Api/"]
COPY ["Adapters/Driven/Infra.MercadoPago/QuickOrder.Adapters.Driven.MercadoPago.csproj", "Adapters/Driven/Infra.MercadoPago/"]
COPY ["Adapters/Driven/Infra.MongoDB/QuickOrder.Adapters.Driven.MongoDB.csproj", "Adapters/Driven/Infra.MongoDB/"]
COPY ["Adapters/Driven/Infra.PostgresDB/QuickOrder.Adapters.Driven.PostgresDB.csproj", "Adapters/Driven/Infra.PostgresDB/"]
COPY ["Adapters/Driven/Infra.ServiceBus/QuickOrder.Adapters.Driven.ServiceBus.csproj", "Adapters/Driven/Infra.ServiceBus/"]
COPY ["Core/IoC/QuickOrder.Core.IoC.csproj", "Core/IoC/"]
COPY ["Core/Domain/QuickOrder.Core.Domain.csproj", "Core/Domain/"]
COPY ["Core/Application/QuickOrder.Core.Application.csproj", "Core/Application/"]

RUN dotnet restore "Adapters/Driving/Api/QuickOrder.Adapters.Driving.Api.csproj"
COPY . .
WORKDIR "/src/Adapters/Driving/Api"
RUN dotnet build "QuickOrder.Adapters.Driving.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuickOrder.Adapters.Driving.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuickOrder.Adapters.Driving.Api.dll"]
