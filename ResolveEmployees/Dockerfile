#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5008

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ResolveEmployees/ResolveEmployees.csproj", "ResolveEmployees/"]
RUN dotnet restore "ResolveEmployees/ResolveEmployees.csproj"
COPY . .
WORKDIR "/src/ResolveEmployees"
RUN dotnet build "ResolveEmployees.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResolveEmployees.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResolveEmployees.dll"]
