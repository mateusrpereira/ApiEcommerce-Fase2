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

Caso utilize o VSCode para rodar o projeto, será necessário a utilização das extensões abaixo:

- Azure Tools (https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack)
- REST Client (https://marketplace.visualstudio.com/items?itemName=humao.rest-client) para testes diretamente pelo arquivo products.http, bastando preencher os campos do product e clicar em Send Request depois de ter inicializado a aplicação com o atalho Ctrl + Shift + P > Debug: Start Debugging

Outra alternativa para realizar testes com a API:

- POSTMAN (https://www.postman.com/)

## Banco de dados:

O Banco de dados utilizado a API é o Azure Cosmos DB - Núcleo (SQL) para trabalhar com documentos. 

Para utilização correta, após sua criação, deverá substituir as informaçõs das variáveis no arquivo: 

```
src/local.settings.json
```

Substituir as informações conforme abaixo:

```
"DatabaseName": "name_db",
"ContainerName": "name_container",
"CosmosDBConnectionString": "conection_string_db;"
```

## Links úteis - Documentação Microsoft

- https://azure.microsoft.com/en-us/free/

- https://azure.microsoft.com/en-us/products/functions/?ef_id=Cj0KCQiAyMKbBhD1ARIsANs7rEFF3-SZBw7XQbwmuaJ_Hu4DTun16IOnWeAZ9xhdRwr0vMTzCdjgRuMaAlEJEALw_wcB%3AG%3As&OCID=AIDcmmsmruuku2_SEM_Cj0KCQiAyMKbBhD1ARIsANs7rEFF3-SZBw7XQbwmuaJ_Hu4DTun16IOnWeAZ9xhdRwr0vMTzCdjgRuMaAlEJEALw_wcB%3AG%3As&gclid=Cj0KCQiAyMKbBhD1ARIsANs7rEFF3-SZBw7XQbwmuaJ_Hu4DTun16IOnWeAZ9xhdRwr0vMTzCdjgRuMaAlEJEALw_wcB

- https://learn.microsoft.com/en-us/azure/azure-functions/functions-scale

- https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-cosmosdb-v2-input?tabs=python-v2%2Cin-process%2Cnodejs-v4%2Cfunctionsv2&pivots=programming-language-csharp#http-trigger-get-multiple-docs-using-documentclient-c

- https://learn.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library?tabs=v4%2Ccmd

- https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-in-process-differences

- https://learn.microsoft.com/en-us/azure/templates/microsoft.documentdb/databaseaccounts?pivots=deployment-language-arm-template