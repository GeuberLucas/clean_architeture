# clean_architeture Project
 ## projeto desenvolvido no curso de arquitetura limpa do macoratti
    Este projeto foi feito durante o curso do [Macoratti Macoratti](https://www.macoratti.net/) visando aprender sobre arquitetura limpa e com as boas práticas que aplicadas permitem criar aplicações em qualquer Linguagem,com alta performance e facilita a manutenção de código. 
    O Instrututor Escolheu Utilizar ASP .NET Core para fazer o curso. Ele também escolheu a Abordagem Code-first, eu optei por Database-first, o que será explicado mais a frente 

    Abaixo segue o codigo da criação do banco de dados, foi utilizado o banco MySQL para se utilizar 
    ```
    create table Categories (
    id int not null,
    created_at DATETIME not null,
    updated_at DATETIME not null,
    name varchar(100) not null,
     PRIMARY KEY (id)
    );

    create table Products (
    id int not null ,
    created_at DATETIME not null,
    updated_at DATETIME not null,
    name varchar(100) not null,
    description varchar(100) not null,
    price decimal(10,2) not null,
    idCategory int not null ,
    PRIMARY KEY (id),
    FOREIGN Key (idCategory) references Categories(id)
    );
    ```
    O Macoratti utiliza o entity Framework como orm para realizar as consultas através do LINQ, o entityframework ele cria a consultas para vc, e também faz o mapeamento do banco e criação deste, ou seja, realizando assim a bodagem Code-first, o código é escrito primeiro e depois realizada a criação do banco.Eu utilizei o Dapper que me da muito mais liberdade de criar as consultas e me obriga a conhecer de como meu banco de dados esta estruturado e funcionando, deixando assim para mim a obrigação de performance e integridade do que está acontecendo 