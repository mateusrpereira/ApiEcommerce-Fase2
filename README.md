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

## Banco de dados:
