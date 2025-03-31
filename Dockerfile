# Используем официальный образ для .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Используем образ для SDK, чтобы собирать проект
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем переменные окружения
ENV DOTNET_DISABLE_SOURCE_LINK=1
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Копируем все файлы .csproj
COPY ["Presentation/Presentation.csproj", "Presentation/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# Восстанавливаем пакеты
RUN dotnet restore "Presentation/Presentation.csproj"

# Копируем все остальные файлы
COPY . .

WORKDIR "/src/Presentation"

# Явно устанавливаем необходимый пакет
RUN dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.0

# Собираем проект
RUN dotnet build "Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build \
    -p:EnableSourceLink=false \
    -p:EnableSourceControlManagerQueries=false

FROM build AS publish
RUN dotnet publish "Presentation.csproj" -c Release -o /app/publish \
    -p:EnableSourceLink=false \
    -p:EnableSourceControlManagerQueries=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.dll"]