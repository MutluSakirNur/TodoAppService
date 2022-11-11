FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TodoListApi.csproj", "."]
RUN dotnet restore "./TodoListApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TodoListApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoListApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoListApi.dll"]