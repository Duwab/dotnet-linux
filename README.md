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

Pour faire fonctionner le debugger, ça devrait être "facile" (ex: [ce tuto](https://docs.microsoft.com/en-us/dotnet/core/tutorials/debugging-with-visual-studio-code?pivots=dotnet-6-0)).

> **Windows + WSL:** sous windows, le SDK s'installe préférentiellement avec VS Installer. <br>
> Et si VSCode est lancé depuis la WSL, il peut y avoir besoin d'ajouter un lien symbolique pour que ce dernier puisse trouver le sdk
> Pour l'instant c'est pas grave, si on est sous Windows alors on peut bosser directement avec VS.

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
