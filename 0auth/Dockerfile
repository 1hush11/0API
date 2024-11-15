FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["0auth.csproj", "./"]
RUN dotnet restore "0auth.csproj"
COPY . .
RUN dotnet build "0auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "0auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "0auth.dll"]
