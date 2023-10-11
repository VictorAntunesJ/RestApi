```sh

# Biblioteca usada para se conectar a APi.
https://learn.microsoft.com/pt-br/dotnet/framework/data/adonet/
https://learn.microsoft.com/pt-br/sql/connect/ado-net/sql/?view=sql-server-ver16
```


```sh

## Criando Alguns comandos 

dotnet new webapi --name "MaisEventosVsCode"
add file readme.md.
add file  .gitignore.
add file  Models.
add dentro da pasta Models uma classe Usuario.
```

class Usuario {
    +number id [pk]
    +string name    
    +string email        
}

```sh
add file context.

```

dotnet-ef database updade
dotnet-ef migrations add MaisEventosApi


```sh
## Criando o Projeto e instalando os pacotes.

dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

 - Vá ate o site. https://www.nuget.org/packages
 - Pesquise por. Microsoft.Data.SqlClient

dotnet add package System.Data.SqlClient --version 4.8.5
```
```


```sh
## Criando string de conexão banco de dados SLQServer
 
 readonly string connectionString = "Data Source=localhost\\SqlExpress;Integrated Security=true;Initial Catalog=MaisEventos";

```

```sh
Criar o comando  Post.

```