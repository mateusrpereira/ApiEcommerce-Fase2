# ApiEcommerce - Fase 2 - Parte 2 - POSTECH
TECH-CHALLENGE ApiEcommerce desenvolvida na Fase 2 da POSTECH Arquitetura de Sistemas .NET com Azure

# Projeto Ecommerce
É uma API que permite o registro e controle de Produtos. A solução foi desenvolvida utilizando a linguagem C# na versão 7.0 do .NET Framework e Banco de Dados do Azure Cosmos DB para trabalhar com documentos.

## Requisitos:
Disponibilizar endpoints para inclusão, alteração, busca geral/busca por id e exclusão de Produtos.

Disponibilizar endpoints para listar os Produtos por ID e por Categoria.

## Critérios de aceite:
Para uso da aplicação, o usuário poderá cadastrar produtos em:

POST /api/Products

Poderá ser informado os campos, conforme exemplo abaixo:
```
{
    "product": {
        "Reference": "ex123",
        "Desc": "Produto 1",
        "Price": 100,
        "Category": "Sapato"
    }
}
```

Para alteração:

PUT /api/Products

Deverá ser informado obrigatoriamente o campo Id e opcionalmente os demais campos, conforme exemplo abaixo:
```
{
    "product": {
        "id": "fd14f322-6f53-4f03-8773-222b1237c96c",
        "Reference": "ex321",
        "Desc": "Produto 2",
        "Price": 110,
        "Category": "Sapato"
    }
}
```

Para busca por categoria:

GET /api/GetProductsByCategory

Deverá ser informado obrigatoriamente o campo partitionKey, conforme exemplo abaixo:
```
{
    "partitionKey": "Sapato",
}
```

Para busca por ID:

GET /api/GetProductById

Deverá ser informado obrigatoriamente o campo Id e partitionKey, conforme exemplo abaixo:
```
{
    "id": "fd14f322-6f53-4f03-8773-222b1237c96c",
    "partitionKey": "Sapato",
}
```

Para deleção:

DELETE /api/Products

Deverá ser informado obrigatoriamente o campo Id e Category, conforme exemplo abaixo:
```
{
    "product": {
        "id": "fd14f322-6f53-4f03-8773-222b1237c96c",
        "Category": "Sapato",
    }
}
```

## Execução:

Para provisionamento da infraestrutura (Infra-As-Code) na Azure, deverá ser preenchido os campos no arquivo build.resources.sh (backend/build_resources.sh) com seus devidos valores e executá-lo utilizando o Git Bash, para isso, deverá estar logado na conta pelo terminal (comando: az login) de acordo com sua conta na Azure, conforme abaixo:

```
TENANT="id_do_diretorio"
SUBSCRIPTION="id_da_assinatura"
LOCATION="brazilsouth"
```

```
RESOURCEGROUP="rg-name"
```

Após a execução desta etapa, poderá verificar que o Grupo de recursos foi criado com os itens:
- Azure Cosmos DB account
- Conta de armazenamento
- Plano do Serviço do Aplicativo
- Aplicativo de Funções

Após o provisionamento da infraestrutura, deverá executar o arquivo deploy_checkout.sh (backend/deploy_checkout.sh) para que seja provisionado o código da API na Azure Functions e poderá observar que a Function foi criada e já estará disponível para acesso pela URL da função gerada na Azure.

Para criação do CI/CD Pipelines com GitHub Actions é necessário a geração de uma service principal, para conectar o GitHub Actions com a Azure Functions, para isso, poderá ser gerado pelo comando abaixo no prompt:

```
az ad sp create-for-rbac --name "name_app-sp" --sdk-auth --role contributor --scopes /subscriptions/id_subscription/resourcegroups/name_resource_group/providers/Microsoft.Web/sites/name_app
```

Esse comando irá gerar uma service principal que deverá ser utilizada para autenticação no GitHub Actions e deverá ter o nome abaixo: 

```
Settings/Secrets and variables/Actions/New repository secret

AZURE_CREDS_FUNCTION_APP
```

Após adicionado esta secret, toda vez que houver alguma alteração no código e for publicado na branch main, será realizado o build e irá ser publicada as alterações na Azure Functions.

OBS.: Caso o build não seja executado de forma automática, verifique a branch em que realizou o commit com as alterações ou use o comando abaixo manualmente no Git Bash se preferir dentro da pasta onde está as funções, neste casso a /src:

```

func azure functionapp publish name_function_app
```

## Banco de dados:
