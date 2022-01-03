#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TesteCQRS/TesteCQRS.csproj", "TesteCQRS/"]
COPY ["TesteCQRS.Application/TesteCQRS.Application.csproj", "TesteCQRS.Application/"]
COPY ["TesteCQRS.Shared/TesteCQRS.Shared.csproj", "TesteCQRS.Shared/"]
RUN dotnet restore "TesteCQRS/TesteCQRS.csproj"
COPY . .
WORKDIR "/src/TesteCQRS"
RUN dotnet build "TesteCQRS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteCQRS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteCQRS.dll"]