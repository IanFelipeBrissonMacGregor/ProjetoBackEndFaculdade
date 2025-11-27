# Projeto Back-End API (C# .NET)


##  Tecnologias
- **Linguagem**: C#  
- **Framework**: .NET (Web API)  
- **Banco de Dados**: PostgreSQL  
- **ORM**: Entity Framework Core  
- **Documentação**: Swagger  

---

## 📂 Estrutura da Arquitetura

projeto-back-end/
└─ ProjetoBackEnd.Api/
├─ Controllers/ # Controllers da aplicação (endpoints HTTP)
├─ Services/ # Regras de negócio
│ └─ Interfaces/ # Interfaces dos services
├─ Repositories/ # Integração com banco
│ └─ Interfaces/ # Interfaces dos repositórios
├─ Models/ # Entidades e DTOs
│ └─ DTOs/
├─ Data/ # DbContext e configuração de acesso ao banco
├─ Config/ # Configurações (ex: Swagger)
├─ Exceptions/ # Tratamento de exceções
├─ appsettings.json # Configurações da aplicação
└─ Program.cs # Ponto de entrada da aplicação


# COLABORADORES:
Ian Felipe Brisson Mac Gregor
Gabriel Brisson Mac Gregor
Lucas Cardoso da Silva
João Machado Ribeiro
Matheus Nascimento Marins

🧩 Principais Funcionalidades
🔐 Autenticação JWT

Cadastro e login de usuários

Geração de token JWT

Controle de acesso às rotas protegidas

Swagger configurado com suporte a Bearer Token

👤 Parceiros (Partners)

Representam cuidadores cadastrados no sistema

Cada parceiro pode ter vários dependentes

Endpoints CRUD completos

🧓 Dependentes (Dependents)

São os idosos assistidos

Possuem informações como idade, saúde, condição e resumo

Relacionados a um parceiro específico

Endpoints CRUD completos

📅 Visitas (Visits)

Representam cada atendimento realizado ao idoso

Contêm:

Nome da visita

Condições do dependente e ambiente

Horário de início e fim

Nota de satisfação

Referência ao dependente

Cada dependente possui sua lista de visitas

💳 Planos (Plans)

Planos mensais de acompanhamento (Bronze, Prata, Gold)

Incluem nome, faixa de preço e benefícios

Associados posteriormente aos parceiros