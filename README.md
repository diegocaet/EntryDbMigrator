# EntryDbMigrator

Aplição criada para criação de base de dados para o projeto [EntryApi](https://github.com/diegocaet/EntryAPI).

## Instalação


Instalar o docker desktop clicando [aqui](https://www.docker.com/products/docker-desktop/).
Fazer download do container SQL Server.

```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
```
Criar uma instancia de banco de dados no container


```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

Conectar ao banco usando o Sql Server Management Studio e executar o comando

```bash
CREATE DATABASE CONTA;
```

Fazer download do código e rodar usando Visual Studio.

## Usage

Ao executar o projeto, as tabelas do projeto serão criadas.