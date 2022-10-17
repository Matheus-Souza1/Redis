# Cache Distribuido
Projeto implementado em cima de um cenario para cadastro e busca de pessoas, com intuito de demonstar a boa performance da utilização de cache distribuido.

## Tecnologias utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- Entity Framework Core In Memory
- Swagger
- Docker
- Redis

## Funcionalidades
- Cadastro,  Detalhes.

## Instalando o Redis Atraves do Docker

Para  iniciar uma instância do Redis localmente com o Docker, basta utilizar o comando abaixo.

```docker run -d -p 6379:6379 --name redis redis```

## Evidências
Na primeira consulta realizada levou cerca de  1.74 Segundos, pois como não a dados disponiveis no cache é necessario realizar a busca dentro do banco de dados.

![SemCache](https://user-images.githubusercontent.com/54037557/196296650-bed96c18-1b0f-4a9c-8b7d-adb082be9cec.jpg)

Ja na segunda consulta realizada levou cerca de  5.67 milissegundos, pois desta vez os dados foram buscados diretamente do cache ao inves de ir no banco de dados.
Com isso podemos notar uma melhoria significativa em relação ao desempenho das duas consultas realizadas.

![ComCache](https://user-images.githubusercontent.com/54037557/196296871-5458f9c4-c2b8-4edc-b4df-00e81cf461eb.jpg)


 ---
 
 Feito por Matheus Souza 
 👋 Entre em contato! 

[![Linkedin Badge](https://img.shields.io/badge/Matheus%20Souza%20-blue?Style=flat&logo=linkedin&labelColor=blue=https://www.linkedin.com/in/matheus-souza-silva/)](https://www.linkedin.com/in/matheus-souza-silva/)
