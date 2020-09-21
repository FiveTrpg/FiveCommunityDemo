#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM node:8.15-alpine AS node-modules
WORKDIR /spa
COPY src/Services/Gaming/Gaming.API/ClientApp/package.json .
COPY src/Services/Gaming/Gaming.API/ClientApp/package-lock.json .
RUN npm install --production --verbose
RUN npm cache clean --force --verbose

FROM node-modules AS node-build
WORKDIR /spa
COPY src/Services/Gaming/Gaming.API/ClientApp/ .
RUN npm run build --production --verbose

FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/Gaming/Gaming.API/Gaming.API.csproj", "src/Services/Gaming/Gaming.API/"]
RUN dotnet restore "src/Services/Gaming/Gaming.API/Gaming.API.csproj"
COPY . .
COPY --from=node-build /spa/build /app/build/ClientApp/build
WORKDIR "src/Services/Gaming/Gaming.API"
RUN dotnet build "Gaming.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN ls /app/build/ClientApp
COPY --from=build /app/build/ClientApp /app/publish/ClientApp
RUN dotnet publish "Gaming.API.csproj" -c Release -o /app/publis

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gaming.API.dll"]
