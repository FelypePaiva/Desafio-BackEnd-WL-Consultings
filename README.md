# API - Desafio BackEnd WL Consultings

Esta API foi desenvolvida em ASP.NET Core (.NET 9) e tem como objetivo gerenciar usuários e operações bancárias básicas, como cadastro, consulta de saldo e adição de saldo e a transferência de valores entre contas.  
Foi aplicada o suporte ao Swagger, portanto poderá escolher a forma de autenticação e\ou requisições por meio de clientes http como o postman, ou utilizar a propria interface grafica gerada se preferir, a qual facilita a persistencia do `Token` gerado  pela autenticação entre as requisições e no preenchimento dos dados a serem enviados em requisições posteriores.   
A autenticação é feita via JWT retornando o token a ser utilizado nas demais rotas.  
  



---

## Funcionalidades Principais

- Login e Autenticação JWT
- Cadastro de Usuário
- Consulta de Usuários
- Consulta de Saldo
- Adição de Saldo
- Transferencia de Saldo entre contas por meio do Numero da Conta
- (Outras operações podem estar disponíveis, como transferências, consulte o controller correspondente)

---

## Autenticação

A maioria dos endpoints exige autenticação JWT.  
Para acessar endpoints protegidos, obtenha um token via `/login` e utilize-o no header `Authorization`:

Adicionar token nas requisições posteriores no `cabeçalho` das requisições ou se preferir adicionar clicando na opção `Authorize` da interface do swagger 


---

## Endpoints

### 1. Criar Usuário
Rota para a criação de novos Usuarios

- **Rota:** `POST /Usuario`
- **Autenticação:** Não requer
- **Body (JSON):**
    ```javascript
    {
        "name": "string",
        "numeroConta": "string",
        "senha": "string",
        "saldo": 0
    }
    ```
- **Resposta:**
  - **201 Created**: Usuário criado com sucesso (redireciona para o endpoint de listagem)
  - **400 Bad Request**: Usuário já existe ou dados inválidos
  - **500 Internal Server Error**: Erro interno

---

### 2. Listar Usuários

- **Rota:** `GET /Usuario`
- **Autenticação:** JWT obrigatória
- **Resposta:**
  - **200 OK**: Lista de usuários cadastrados



---

### 3. Consultar Saldo

- **Rota:** `GET /Usuario/ConsultarSaldo`
- **Autenticação:** JWT obrigatória
- **Resposta:**
  - **200 OK**: Dados do usuário autenticado (inclui saldo)

  - **400 Bad Request**: Usuário não encontrado
  - **500 Internal Server Error**: Erro interno

---

### 4. Adicionar Saldo

- **Rota:** `POST /Usuario/AdicionarSaldo`
- **Autenticação:** JWT obrigatória
- **Body (JSON):**


  (envie apenas o valor numérico no corpo da requisição)
- **Resposta:**
  - **200 OK**: Saldo adicionado com sucesso
  - **400 Bad Request**: Valor inválido ou usuário não encontrado
  - **500 Internal Server Error**: Erro interno

---
##  Endpoints - Transferência

Abaixo estão as rotas disponíveis na controller de Transferências, seus parâmetros e exemplos de uso.

---

### 1. Realizar Transferência

- **Rota:** `POST /TransferirSaldo`
- **Autenticação:** JWT obrigatória
- **Body (JSON):**
  - **Parâmetros:**
  - `numeroContaDestino` (string): Número da conta do destinatário.
  - `valorTransferencia` (decimal): Valor a ser transferido.

- **Resposta:**
  - **200 OK**: Transferência realizada com sucesso.
  - **400 Bad Request**: Dados inválidos, saldo insuficiente ou conta não encontrada.
  - **500 Internal Server Error**: Erro interno.

---

### 2. Listar Transferências Realizadas

- **Rota:** `GET /ListarTransferencias`
- **Autenticação:** JWT obrigatória
- **Body (JSON):**
    ```javascript
    {
        "dataInicial": (YYYY-MM-dd)"string",
        "dataFinal": (YYYY-MM-dd)"string"
    }
    ```
- **Resposta:**
  - **200 OK**: Lista de transferências realizadas pelo usuário autenticado.
  

---


## Observações

- As senhas são armazenadas com hash MD5.
- Para transferências e outras operações, consulte o controller correspondente.
- O usuário autenticado é identificado pelo token JWT.
- O saldo é validado antes de realizar a transferência.
- Todas as datas seguem o padrão ISO 8601.
- Para realizar transferências, o usuário deve estar autenticado e possuir saldo suficiente.

---

## Exemplo de Fluxo

1. **Criar usuário:**  
   `POST /Usuario` com os dados do usuário.

2. **Login:**  
   `POST /login` com número da conta e senha.  
   Receba o token JWT.

3. **Consultar saldo:**  
   `GET /Usuario/ConsultarSaldo` com o token JWT no header.

4. **Adicionar saldo:**  
   `POST /Usuario/AdicionarSaldo` com o valor no body e token JWT no header.
5. **Transferir saldo para outro usuario pelo numero da conta:**  
   `POST /TransferirSaldo` com o valor no body e token JWT no header.
---

## Como Executar

1. Configure a string de conexão com o banco PostgreSQL no `appsettings.json`(Criar previamente o banco de dados para a geração das tabelas pelas migrations).
2. Execute as migrações do Entity Framework para criação das tabelas e inserção de dados de testes com o `Update-Database` no projeto `Modelo.Infra.Data`.
3. Rode a aplicação com `dotnet run` ou pelo Visual Studio.
4. Acesse o Swagger em `/swagger` para testar os endpoints.

---

