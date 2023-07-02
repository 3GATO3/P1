#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["P1/P1.csproj", "P1/"]
RUN dotnet restore "P1/P1.csproj"
COPY . .
WORKDIR "/src/P1"
RUN dotnet build "P1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "P1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "P1.dll"]