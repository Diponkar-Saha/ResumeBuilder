
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CVBuilder.web/*.csproj", "CVBuilder.web/"]
COPY ["CVBuilder.Persistance/*.csproj", "CVBuilder.Persistance/"]
COPY ["CVBuilder.Application/*.csproj", "CVBuilder.Application/"]
COPY ["CVBuilder.Domain/*.csproj", "CVBuilder.Domain/"]
COPY ["CVBuilder.Infrastructure/*.csproj", "CVBuilder.Infrastructure/"]
RUN dotnet restore "CVBuilder.web/CVBuilder.Web.csproj"
COPY . .
WORKDIR "/src/CVBuilder.web"
RUN dotnet build "CVBuilder.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CVBuilder.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CVBuilder.Web.dll"]