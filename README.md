# Projeto Loja Virtual
Loja virtual em ASP.NET, Web API e EF com SQL Server.

![](https://raw.githubusercontent.com/wliradev/loja-virtual/master/docs/view.png)
# Tecnologias Utilizadas
- A loja virtual foi desenvolvida em c# na plataforma .net da microsoft com ASP.NET MVC 5;
- Vers�o do .NET Framewrok: 4.6.1;
- A arquitetura do sistema foi baseada em DDD, com dom�nio desacoplado, utilizando Repository Partner; 
- Para persist�ncia foi utilizado ORM Entity Framework; 
- Nos testes unit�rios foi utilizado o framework Unit Test; 
- Na apresenta��o da camada Web, as telas foram desenvolvidas no ASP.NET MVC 5 Razor + HTML5, CSS3 com bootstrap + Javascript e JQuery; 
- O banco de dados utilizado foi o SQL Server 2016 Express;
- Para o gr�fico foi utilizada a biblioteca ChartJS;

# Instru��es de Instala��o e uso
- Fazer o download do arquivo dist.rar e descompactar;
- Restaurar a base utilizando "LojaDb.bak" ou criar o banco manualmente com o nome: "LojaDb" e executar o scritp contido no arquivo: "script-loja-db.sql" que encontra-se na raiz do projeto;
- Criar uma novo site no servidor web IIS apontando para os arquivos descompactados;
- Alterar a string de conex�o "LojaDb" no arquivo Web.Config apontando para o banco criado;
- Subir a inst�cia do site;