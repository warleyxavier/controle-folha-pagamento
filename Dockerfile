FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app

COPY ControleFolhaPagamento.API/ControleFolhaPagamento.API.csproj ./
COPY ControleFolhaPagamento.Aplicacao/ControleFolhaPagamento.Aplicacao.csproj ./

RUN dotnet restore ControleFolhaPagamento.API\ControleFolhaPagamento.API.csproj
RUN dotnet restore ControleFolhaPagamento.Aplicacao\ControleFolhaPagamento.Aplicacao.csproj

COPY . .

EXPOSE 5000
EXPOSE 5001

CMD [ "dotnet", "run", "-p ControleFolhaPagamento.API" ]