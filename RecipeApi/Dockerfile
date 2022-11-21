FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RecipeApi/RecipeApi.csproj", "RecipeApi/"]
RUN dotnet restore "RecipeApi/RecipeApi.csproj"
COPY . .
WORKDIR "/src/RecipeApi"
RUN dotnet build "RecipeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipeApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipeApi.dll"]
