FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build 
WORKDIR /app
# Copy the solution and project files
COPY carauction.sln ./
COPY src/GatewayService/GatewayService.csproj ./src/GatewayService/

# Restore dependencies
RUN dotnet restore ./src/GatewayService/GatewayService.csproj

# Copy the rest of the application code
COPY . .

# Publish the application
RUN dotnet publish ./src/GatewayService/GatewayService.csproj -c Release -o /app/publish

# Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GatewayService.dll"]