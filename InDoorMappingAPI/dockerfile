# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia todos os ficheiros para o container
COPY . ./

# Publica a aplicação numa pasta 'out'
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia o output do build
COPY --from=build /app/out .

# Corre a aplicação
ENTRYPOINT ["dotnet", "MinhaApi.dll"]
