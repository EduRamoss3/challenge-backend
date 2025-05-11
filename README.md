 ### Tecnologias utilizadas: </br>
* .NET 8
* PostgreSQL
* JWT
* Swagger
* ASP.NET Core Web API
  
 ### Instalação:
* Clone o repositório: </br>
* Ajuste a connection string em appsettings.json se necessário </br>
* Execute: docker compose up --build   </br>
* Acesse com a rota base http://localhost:5000/api/v1/  via POSTMAN ou http://localhost:5000/swagger via Swagger   (ou, se realizou alguma mudança no docker, com a porta descrita nas variaveis do  docker compose.)

### Segurança 
* Todos endpoints (exceto login/criação) requerem token JWT

* Dados sensíveis criptografados no banco

* Validação rigorosa de inputs

* Acesso restrito aos próprios recursos
