FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Apollo.Api/Apollo.Api.csproj", "src/Apollo.Api/"]
RUN dotnet restore "src/Apollo.Api/Apollo.Api.csproj"
COPY . .
WORKDIR "/src/src/Apollo.Api"
RUN dotnet build "Apollo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apollo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apollo.Api.dll"]
