FROM mcr.microsoft.com/dotnet/aspnet:3.1

WORKDIR /app

COPY . .

RUN dotnet restore ControleFolhaPagamento.API/ControleFolhaPagamento.API.csproj

EXPOSE 5000
EXPOSE 5001

CMD [ "dotnet run -p ControleFolhaPagamento.API" ]