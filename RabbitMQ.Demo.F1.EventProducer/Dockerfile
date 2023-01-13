#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RabbitMQ.Demo.F1.EventProducer/RabbitMQ.Demo.F1.EventProducer.csproj", "RabbitMQ.Demo.F1.EventProducer/"]
RUN dotnet restore "RabbitMQ.Demo.F1.EventProducer/RabbitMQ.Demo.F1.EventProducer.csproj"
COPY . .
WORKDIR "/src/RabbitMQ.Demo.F1.EventProducer"
RUN dotnet build "RabbitMQ.Demo.F1.EventProducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMQ.Demo.F1.EventProducer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMQ.Demo.F1.EventProducer.dll"]