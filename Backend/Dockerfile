# Базовый образ с .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Копируем собранные файлы приложения
COPY ./publish . 

# Запускаем приложение
ENTRYPOINT ["dotnet", "Api.dll"]
 
