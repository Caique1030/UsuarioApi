# API CRUD com MySQL e Identity

Este é um projeto de API CRUD desenvolvido em C# utilizando o ASP.NET Core, com o banco de dados MySQL e autenticação via Identity. O objetivo desta API é fornecer endpoints para realizar operações CRUD (Create, Read, Update, Delete) em recursos relacionados a [especificar os recursos aqui, por exemplo: usuários, produtos, etc.].

## Recursos

- { "UserName": "nome do usuario,
- "DataNascimento": "data do usuario,
  "Password":"Caracteris de acordo com a documentação do Identity",
  "PasswordConfirmation": "de acordo com a senha acima"
}

## Pré-requisitos

Para executar este projeto em seu ambiente local, você precisará ter instalado:
- Visual Studio (versão X.X ou superior)
- MySQL Server
- .NET Core SDK (versão 7.0 ou superior)

## Configuração do Banco de Dados

Antes de executar a aplicação, é necessário configurar o banco de dados MySQL. Siga os passos abaixo:

1. Crie um banco de dados MySQL.
2. Edite o arquivo `appsettings.json` e atualize a string de conexão com os detalhes do seu banco de dados MySQL.

Exemplo de `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=NomeDoSeuBanco;user=seuUsuario;password=suaSenha;"
  }
}
