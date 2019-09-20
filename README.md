# Projeto Loja Virtual
Loja virtual em ASP.NET, Web API e EF com SQL Server.

![](https://raw.githubusercontent.com/wliradev/loja-virtual/master/docs/view.png)
# Tecnologias Utilizadas
- A loja virtual foi desenvolvida em c# na plataforma .net da microsoft com ASP.NET MVC 5. 
- A arquitetura do sistema foi baseada em DDD na forma hexagonal, com dom�nio desacoplado, utilizando Repository Partner; 
- Para persist�ncia foi utilizado ORM Entity Framework; 
- Nos testes unit�rios foi utilizado o framework Unit Test; 
- Na apresenta��o da camada Web, as telas foram desenvolvidas no ASP.NET MVC 5 + HTML5, CSS3 com bootstrap + Javascript e JQuery; 
- O banco de dados utilizado foi o SQL Server 2016 Express;

# Instru��es de Instala��o e uso
- Fazer o download do arquivo dist.zip e descompactar;
- Criar um banco de dados no sql server express com o nome: "LojaDb" e executar o scritp contido no arquivo: "script-loja-db.sql" que se encontra na raiz do projeto;
- Criar uma novo site no servidor web IIS apontando para os arquivos descompactados;
- Alterar a string de conex�o "LojaDb" no arquivo Web.Config apontando para o banco criado;
- Subir a inst�cia do site;