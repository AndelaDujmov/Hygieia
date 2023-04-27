FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HygieiaApp.Razor/HygieiaApp.Razor.csproj", "HygieiaApp.Razor/"]
RUN dotnet restore "HygieiaApp.Razor/HygieiaApp.Razor.csproj"
COPY . .
WORKDIR "/src/HygieiaApp.Razor"
RUN dotnet build "HygieiaApp.Razor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HygieiaApp.Razor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HygieiaApp.Razor.dll"]
