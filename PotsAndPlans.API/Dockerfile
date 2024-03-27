#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PotsAndPlans.API/PotsAndPlans.API.csproj", "PotsAndPlans.API/"]
RUN dotnet restore "PotsAndPlans.API/PotsAndPlans.API.csproj"
COPY . .
WORKDIR "/src/PotsAndPlans.API"
RUN dotnet build "PotsAndPlans.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PotsAndPlans.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PotsAndPlans.API.dll"]


sudo docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=llamallamaredpajamas' -p 1433:1433 --name potsandplans -d mcr.microsoft.com/azure-sql-edge
