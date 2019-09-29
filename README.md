# API .NET Core

> Este projeto é uma API desenvolvida com a metodologia DDD, utilizando .NET Core + Entity Framework Core + Swagger + AutoMapper + JWT.

![Capturar](https://user-images.githubusercontent.com/6399309/65838580-8bebb280-e2d2-11e9-82b7-dc77f5e73d83.PNG)

### Iniciar a aplicacão :checkered_flag:

Depois de efetuar o download da aplicação, acesse a pasta raiz e execute o comando abaixo para efetuar o download das dependências e efetuar o build da aplicação:

```console
dotnet build ./src/
```

A aplicação foi desenvolvida com o banco de dados PostgreSQL. Para alterar a string de conexão acesse o arquivo `./src/Api.Data/Context/ContextFactory.cs` e modifique o retorno da função `ConnectionString`.

Para rodar a aplicação esteja na pasta raiz da aplicação e execute o comando:

```console
dotnet run --project ./src/Api.Application/
```

Para visualizar a aplicação acesse o endereço [http://localhost:5001](http://localhost:5001) no navegador.
