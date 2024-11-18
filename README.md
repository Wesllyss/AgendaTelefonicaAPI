Tecnologia e estruturas utilizadas

Descrição do Projeto
A Agenda Telefônica é uma aplicação ASP.NET Core que permite o gerenciamento de contatos, como adicionar, atualizar, listar e remover contatos. O projeto utiliza práticas recomendadas de desenvolvimento, como a separação de preocupações, injeção de dependência, e implementação de repositórios e serviços para melhor manutenção e escalabilidade.

Funcionalidades
CRUD Completo de Contatos:
Listar todos os contatos
Consultar um contato por ID
Adicionar um novo contato
Atualizar um contato existente
Remover um contato
Validações e Regras de Negócio:
Validações de entrada, como garantir que o nome do contato não seja vazio.
Tratamento de exceções para garantir a robustez da aplicação.
Tecnologias Utilizadas
ASP.NET Core 6.0
Entity Framework Core: Para mapeamento objeto-relacional (ORM) e interação com o banco de dados.
AutoMapper: Para simplificar o mapeamento de objetos.
Microsoft SQL Server: Banco de dados utilizado para armazenar os contatos.
Injeção de Dependência: Implementada para melhorar a modularidade e facilitar a manutenção e testes.
Estrutura do Projeto
Models: Define a classe Contato, que representa um contato na agenda.
Interfaces: Contém as interfaces que definem a assinatura dos métodos de repositório.
Repositories: Implementa as interfaces e gerencia a interação com o banco de dados usando o Entity Framework.
Services: Contém a lógica de negócios e validações.
Controllers: Implementa as APIs RESTful que permitem o acesso às funcionalidades da agenda.
Context: Define o ContatoContext para configurar o Entity Framework.
