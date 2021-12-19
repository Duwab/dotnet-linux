# Working with dotnet on Linux

## Initialiser le projet

```
# initiate project
dotnet new sln
dotnet new console
dotnet run

# add dependencies
dotnet add package WorkflowCore
```

Dans le container, on peut faire toutes les manips avec la version de dotnet 3.x

> **Note:** Pour le container, aller chercher le container [`dotnet/sdk`](https://hub.docker.com/_/microsoft-dotnet-sdk/) qui match la version pour l'os et Dotnet cible

Pour que l'éditeur fonctionne:
* installer la version de dotnet SDK cible
* ajouter le plugin c# le mieux maintenu de l'éditeur

Pour faire fonctionner le debugger
*Tuto debugger dotnet vscode*

## Sample

Ici, on fait un exemple avec le package WorkflowCore.

```
docker compose up -d
docker compose exec dottest bash

# root@dottest:/app#
cd /app/console
dotnet run
```

> **Note:** il ne semble pas falloir réaliser de "`npm install`" avec la [commande `dotnet`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet). Le run s'en charge ?
