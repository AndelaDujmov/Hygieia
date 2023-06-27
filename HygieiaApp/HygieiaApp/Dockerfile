FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HygieiaApp/HygieiaApp.csproj", "HygieiaApp/"]
RUN dotnet restore "HygieiaApp/HygieiaApp.csproj"
COPY . .
WORKDIR "/src/HygieiaApp"
RUN dotnet build "HygieiaApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HygieiaApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HygieiaApp.dll"]
