FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

ENV ConnectionStrings:DefaultConnection="Server=tcp:mycookbook-server.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=ENVID;Password=ENVPW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENV AppSettings:Secret="MyCookbook-authentication"
ENV DB_UserId="admin@mycookbook.com@mycookbook-server"

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["RecipeMicroserviceAPI/RecipeMicroserviceAPI.csproj", "RecipeMicroserviceAPI/"]
RUN dotnet restore "RecipeMicroserviceAPI/RecipeMicroserviceAPI.csproj"
COPY . .
WORKDIR "/src/RecipeMicroserviceAPI"
RUN dotnet build "RecipeMicroserviceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipeMicroserviceAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipeMicroserviceAPI.dll"]