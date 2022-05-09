Documentação Técnica do Sistema

Projeto:
Desenvolvimento e disponibilização do acesso de software para
Verificar através de um número digitado quais são seus divisores e desses divisores quais são números primos.

Equipe Técnica:
Herbert Carvalho

SUMÁRIO
1. SOBRE O SISTEMA
2. INSTALAÇÃO DO SISTEMA
3. Arquitetura do Sistema
4. Frameworks
5. Utilização




1.	Sobre o Sistema

Este  sistema  consiste  em  disponibilizar  um  software  para determinar quais são os divisores e os números primos desses divisores através de um número digitado via console application ou uma requisição na api. 





2.	Instalação do Sistema

O Sistema foi desenvolvido na linguagem C# e é necessário para seu funcionamento : 

•	Versão do .NetCore 3.1

Caso queira executar em um container Docker Linux certifique-se de possuir o tal instalado

Para a instalação do .NetFramework é possível através do link : 
Download .NET Core 3.1 (Linux, macOS, and Windows) (microsoft.com)



3.	Arquitetura do Sistema


O sistema foi desenvolvido em duas aplicações a Console que é de simples execução, categorizando-a como tal, e o sistema também possui uma API que será abordada abaixo.

Nessa arquitetura foi utilizado os conceitos do Clean Architeture abaixo uma imagem sobre o padrão
 

Este padrão não se completa por completo na aplicação por não ter em sua configuração um acoplamento com banco de Dados, mas o Core da aplicação está desacoplado das responsabilidades que outras camadas da aplicação serão responsáveis e onde não é possível mover um item externo para interno. Os níveis internos da aplicação não podem mencionar funções, classes que existem nas camadas externas.

Essa arquitetura foi escolhida para manter um nível de escalamento ao longo tempo que facilitará a manutenção por longos períodos, é uma arquitetura que trabalha com os conceitos de DDD onde o acoplamento preza que o núcleo não dependa de nada e que facilita a padronização do código.


4.	Frameworks 


Será abordado quais os Frameworks utilizados na aplicação.

•	MediatR


Este Design Patter irá gerenciar as interações de diferentes objetos através de uma classe mediadora, centraliza todas as interações entre os objetos, visando diminuir o acoplamento e a dependência entre eles. Desta forma, neste padrão, os objetos não conversam diretamente entre eles, toda comunicação precisa passar pela classe mediadora.

O Command Query Responsibility Segregation, ou CQRS, é um padrão de projeto que separa as operações de leitura e escrita da base de dados em dois modelos: queries e commands. Os commands são responsáveis pelas ações que realizam alguma alteração na base de dados. Geralmente operações assíncronas que não retornam nenhum dado.


•	FluentValidator

Fluent Validation é uma biblioteca que veio para criar validações de dados de forma simples e rápida para os desenvolvedores.
Com ela, podemos usar expressões Lambda para “construir regras de validações” com retorno de mensagem de erro para cada propriedade das entidades.
•	AutoMapper
Com a utilização do AutoMapper as classes vindas do MediatR serão repassadas em um novo Objeto utilizando esse conversor de dados


5.	Utilização

Console – 

Após iniciar o sistema, o mesmo retornará uma mensagem solicitando que digite um número
 

Após digitar o número será retornado para o usuário os divisores do número e desses divisores quais são os números primos.
 

API – 
Com a aplicação disponibilizada foi criada uma rota para o acesso via HttpRequest 

EndPoint : [HttpGet] -  .../api/operacoesnumericas/primosedivisores{numero}

{numero} no head da chamada Http é necessário enviar o número como exemplo no Postman : 
 
Após enviar a solicitação a aplicação processara e validará o resultado que será devolvido em formato Json no exemplo abaixo :


{
    "data": {
        "numero": 255,
        "numerosPrimos": [
            3,
            5,
            17
        ],
        "divisores": [
            1,
            3,
            5,
            15,
            17,
            51,
            85,
            255
        ]
    },
    "succeeded": true,
    "error": null
}

Para atender os requisitos de Robustez e Resiliência, esta aplicação possui tratamento de erro personalizada e sempre na requisição além do resultado dos valores será também informados o resultado da requisição e se ocorreu algum erro que pode ser adicionado números de identificação do erro ao seu critério.
