#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web_api_tour/Web_api_tour.csproj", "Web_api_tour/"]
RUN dotnet restore "Web_api_tour/Web_api_tour.csproj"
COPY . .
WORKDIR "/src/Web_api_tour"
RUN dotnet build "Web_api_tour.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web_api_tour.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web_api_tour.dll"]
