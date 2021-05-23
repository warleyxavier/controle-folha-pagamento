FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app

COPY ControleFolhaPagamento.API/*.csproj ./
COPY ControleFolhaPagamento.Aplicacao/*.csproj ./

RUN dotnet restore

COPY . .

EXPOSE 5000
EXPOSE 5001

CMD [ "dotnet", "run", "-p ControleFolhaPagamento.API" ]