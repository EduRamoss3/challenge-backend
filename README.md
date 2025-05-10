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
* Acesse com a rota base http://localhost:5000/api/v1/    (ou, se realizou alguma mudança no docker, com a porta descrita nas variaveis do  docker compose.)
* Autenticação http POST /api/v1/Account/login   </br>
json
{   </br>
  "email": "john.doerogers@example.com",   </br>
  "password": "password12345"   </br>
}  </br>
### Tecnologias 
* Backend: .NET 7, Entity Framework Core </br>
* Autenticação: JWT, Claims Identity </br>
* Segurança: Criptografia AES, Validação por Token </br>
* Padrões: Repository Pattern, Unit of Work </br>
* Validação: FluentValidation </br>

## Endpoints
### Account
* POST /api/v1/Account/create: Cria nova conta </br>
</br>
Utilize o json 
{   </br> 
  "name": "Nome",   </br>
  "email": "email@valido.com",   </br>
  "password": "senhaForte123"   </br>
}   </br>

### Wallets
* GET /api/v1/Wallet/get-all: Lista carteiras </br>

* GET /api/v1/Wallet/get-balance?idWallet={guid}: Consulta saldo </br>

* POST /api/v1/Wallet/create </br>
Utilize o json </br>
{"amount": 100}   </br>

PATCH /api/v1/Wallet/deposit?idWallet={guid}: Deposita  -json
{"amount": 50}  </br>

### Transferências
GET /api/v1/Transfer/get-transfers?dateBy=yyyy-MM-dd: Lista transferências </br>

POST /api/v1/Transfer/transfer: Transfere </br>
Utilize o json
{  </br>
  "idWalletCreator": "guid",   </br>
  "idWalletReceptor": "guid",   </br>
  "amount": 100   </br>
}  
### Segurança 
* Todos endpoints (exceto login/criação) requerem token JWT

* Dados sensíveis criptografados no banco

* Validação rigorosa de inputs

* Acesso restrito aos próprios recursos
