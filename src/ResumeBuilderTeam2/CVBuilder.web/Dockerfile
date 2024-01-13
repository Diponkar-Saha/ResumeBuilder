#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CVBuilder.web/CVBuilder.Web.csproj", "CVBuilder.web/"]
COPY ["CVBuilder.Persistance/CVBuilder.Persistence.csproj", "CVBuilder.Persistance/"]
COPY ["CVBuilder.Application/CVBuilder.Application.csproj", "CVBuilder.Application/"]
COPY ["CVBuilder.Domain/CVBuilder.Domain.csproj", "CVBuilder.Domain/"]
COPY ["CVBuilder.Infrastructure/CVBuilder.Infrastructure.csproj", "CVBuilder.Infrastructure/"]
RUN dotnet restore "CVBuilder.web/CVBuilder.Web.csproj"
COPY . .
WORKDIR "/src/CVBuilder.web"
RUN dotnet build "CVBuilder.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CVBuilder.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CVBuilder.Web.dll"]