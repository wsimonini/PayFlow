# 🧾 PayFlowSolution

Sistema de gateway de pagamentos desenvolvido em **.NET 6**, com **arquitetura hexagonal (ports & adapters)**, **Clean Code** e princípios **SOLID**.

O objetivo é permitir integração com múltiplos provedores de pagamento (FastPay e SecurePay), alternando automaticamente conforme as regras de negócio.

---

## 🚀 Tecnologias Utilizadas
- .NET 6 (C#)
- ASP.NET Core Web API
- Swashbuckle / Swagger
- xUnit (testes)
- Docker & Docker Compose

---

## ⚙️ Regras de Negócio

- Se o valor for **menor que R$100**, usar **FastPay**  
- Se o valor for **igual ou maior que R$100**, usar **SecurePay**  
- Caso um provedor esteja indisponível, usar o outro  
- Taxas:
  - **FastPay:** 3,49%  
  - **SecurePay:** 2,99% + R$0,40 fixo  

A resposta da API contém:
{
  "provider": "SecurePay",
  "grossAmount": 120.50,
  "fee": 4.01,
  "netAmount": 116.49,
  "status": "approved"
}

🧩 Estrutura do Projeto
PayFlowSolution/
├── src/
│   ├── PayFlow.Api/            # Controllers e Endpoints
│   ├── PayFlow.Application/    # Casos de uso (UseCases)
│   ├── PayFlow.Domain/         # Entidades e Ports
│   └── PayFlow.Infrastructure/ # Adapters (FastPay e SecurePay)
└── tests/
    └── PayFlow.Tests/          # Testes unitários

------------------------------------------------
▶️ Executando o Projeto (Localmente)
Via Visual Studio

Abra o arquivo PayFlowSolution.sln

Defina PayFlow.Api como projeto de inicialização

Pressione F5 para rodar

Via CLI
cd src/PayFlow.Api
dotnet run

A API estará disponível em:

http://localhost:5000
------------------------------------------------
🧪Testando via Swagger

Abra no navegador:

http://localhost:5000/swagger

Exemplo de requisição:

{
  "amount": 120.50,
  "currency": "BRL"
}
------------------------------------------------

🐳 Executando com Docker Compose

Build e execução
docker-compose up --build

Parar containers
docker-compose down

Acesse:

http://localhost:5000

------------------------------------------------

🧠 Testes Unitários
dotnet test

------------------------------------------------

📝 Autor

Wesley Simonini
Arquitetura Hexagonal | .NET 6 | SOLID | Clean Code

------------------------------------------------
Obs: Adicionei a Collection do Postman dentro de:
PayFlowSolution\src\PayFlow.Infrastructure\Collection
