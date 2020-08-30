FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

ENV ConnectionStrings:DefaultConnection="Server=tcp:mycookbook-server.database.windows.net,1433;Initial Catalog=MealDB;Persist Security Info=False;User ID=ENVID;Password=ENVPW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENV AppSettings:Secret="MyCookbook-authentication"
ENV DB_UserId="admin@mycookbook.com@mycookbook-server"

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MealMicroserviceAPI/MealMicroserviceAPI.csproj", "MealMicroserviceAPI/"]
RUN dotnet restore "MealMicroserviceAPI/MealMicroserviceAPI.csproj"
COPY . .
WORKDIR "/src/MealMicroserviceAPI"
RUN dotnet build "MealMicroserviceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MealMicroserviceAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MealMicroserviceAPI.dll"]