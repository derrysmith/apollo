FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Apollo.Identity.Api/Apollo.Identity.Api.csproj", "src/Apollo.Identity.Api/"]
RUN dotnet restore "src/Apollo.Identity.Api/Apollo.Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/Apollo.Identity.Api"
RUN dotnet build "Apollo.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apollo.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apollo.Identity.Api.dll"]
