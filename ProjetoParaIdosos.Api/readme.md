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