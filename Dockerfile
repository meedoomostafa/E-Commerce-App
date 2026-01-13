FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY *.sln .

COPY ["E-CommerceApp/E-CommerceApp.csproj", "E-CommerceApp/"]
COPY ["App.Repositories/App.Repositories.csproj", "App.Repositories/"]
COPY ["App.Models/App.Models.csproj", "App.Models/"]
COPY ["App.Utiltity/App.Utiltity.csproj", "App.Utiltity/"]
COPY ["App.Validation/App.Validation.csproj", "App.Validation/"]

RUN dotnet restore "E-CommerceApp/E-CommerceApp.csproj"

COPY . .

WORKDIR "/src/E-CommerceApp"
RUN dotnet publish "E-CommerceApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8443

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "E-CommerceApp.dll"]