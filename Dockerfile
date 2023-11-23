FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5169

ENV ASPNETCORE_URLS=http://+:5169

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["creative_final_crud.csproj", "./"]
RUN dotnet restore "creative_final_crud.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "creative_final_crud.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "creative_final_crud.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "creative_final_crud.dll"]
