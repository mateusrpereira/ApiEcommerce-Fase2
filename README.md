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


## Banco de dados:
