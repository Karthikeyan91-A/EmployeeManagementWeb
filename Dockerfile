
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
WORKDIR /src

COPY ["Employee_Management_Web.csproj", "."]
RUN dotnet restore "./Employee_Management_Web.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./Employee_Management_Web.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Employee_Management_Web.csproj" -c Release -o /app/publish 

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS final
WORKDIR /app

COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Employee_Management_Web.dll"]