# Sistema de Gestão de Colaboradores e Unidades em C# com PostgreSQL

Este é um projeto de backend que implementa um Sistema de Gestão de Colaboradores e Unidades, utilizando o PostgreSQL como banco de dados.

## **Funcionalidades**
* Cadastro de Usuário: Os usuários devem ser cadastrados com um código único, login, senha e status (ativo ou inativo).
* Atualização de Informações de Usuários: É possível atualizar as informações de usuário, somente senha e status (ativo ou inativo).
* Listagem de Usuários: O sistema oferece a funcionalidade de listar todos os usuário cadastrados, exibindo seus login e status. Deve também permitir uma consulta apenas por status.
* Cadastro de Colaboradores: Os colaboradores devem ser cadastrados com um código único, nome e relacionados a uma unidade específica. Todo colaborador deve ter um usuário relacionado.
* Atualização de Informações de Colaboradores: É possível atualizar as informações de colaboradores, incluindo o nome e a unidade à qual estão associados.
* Remoção de Colaboradores: Os colaboradores podem ser removidos do sistema.
* Listagem de Colaboradores: O sistema oferece a funcionalidade de listar todos os colaboradores cadastrados, exibindo seus códigos, nomes e unidades associadas.
* Cadastro de Unidades: O sistema permite o cadastro de unidades, associando um ID único, um código de unidade único e um nome à unidade.
* Atualização de Informações de Unidades: As unidades podem ser inativadas, e quando inativadas não podem permitir a inclusão de novos colaboradores.
* Listagem de Unidades: O sistema deve permitir listar todas as unidades cadastradas e todos os colaboradores relacionadados.

## **Diferenciais**
* Utilização do Docker para criação do banco de dados.
* Criar autenticação via Bearer token. 

## **Requisitos**
* Desenvolver arquitetura do projeto em MVC.
* Aplicar o pattern de herança.
* Deve ser possível realizar os testes das funcionalidades via Postman ou similares.

## Passos para envio da avaliação
* Solicite acesso ao repositório.
* Crie um fork da master para seu repositório com o seguinte nome: usuário do git e data, ex.: devrte-20231201.
* Envie link do projeto criado para o email: desenvolvedor.rte@gmail.com com o título: [RTE] - Avaliação técnica / Seu Nome
* **Após a solicitação de acesso, haverá o prazo de uma semana para entrega do projeto**


Sistema e testes

@startuml

class UnitModel {
    +int Id
    +int UnitCode
    +String Name
    +bool Status
    +ICollection<EmployeeModel> Employees
}

class UserModel {
    +int Id
    +String Login
    +String Password
    +StatusUser Status
}

class EmployeeModel {
    +int Id
    +String Name
    +int UserId
    +int UnitId
    -UnitModel Unit
}

UnitModel "1" -- "*" EmployeeModel : contains
UserModel "1" -- "*" EmployeeModel : associated

enum StatusUser {
    Active
    Inactive
}

@enduml


- Cadastro de Usuário: Os usuários devem ser cadastrados com um código único, login, senha e status (ativo ou inativo).
- Atualização de Informações de Usuários: É possível atualizar as informações de usuário, somente senha e status (ativo ou inativo).
- Listagem de Usuários: O sistema oferece a funcionalidade de listar todos os usuário cadastrados, exibindo seus login e status. Deve também permitir uma consulta apenas por status.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/5102198f-5b18-4b41-bf22-9b63d822c2b3/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/821d69e0-5742-430b-9e65-a35a854fd2c1/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/b373241e-2625-47b3-9e73-6ce3dc5dbcf6/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/62fc26bf-ed25-476c-a68a-a9329e4625ad/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/f538d326-a1a4-47d2-b165-4b279fb3509c/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/f60e602d-3263-4e69-8b3d-4b7afc63c3aa/Untitled.png)

- Cadastro de Colaboradores: Os colaboradores devem ser cadastrados com um código único, nome e relacionados a uma unidade específica. Todo colaborador dever ter um usuário relacionado.
- Atualização de Informações de Colaboradores: É possível atualizar as informações de colaboradores, incluindo o nome e a unidade à qual estão associados.
- Remoção de Colaboradores: Os colaboradores podem ser removidos do sistema.
- Listagem de Colaboradores: O sistema oferece a funcionalidade de listar todos os colaboradores cadastrados, exibindo seus códigos, nomes e unidades associadas.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/2b308ded-bb96-4de5-96fe-ac281b8002d4/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/21c071c4-12c6-4912-ae05-7a7c5d6c6254/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/a1492076-1393-4b8b-a1bf-d1ed6d7926bd/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/06fc3bc1-4a9d-4be7-9149-f23845ab2480/Untitled.png)

- Cadastro de Unidades: O sistema permite o cadastro de unidades, associando um ID único, um código de unidade único e um nome à unidade.
- Atualização de Informações de Unidades: As unidades podem ser inativadas, e quando inativadas não podem permitir a inclusão de novos colaboradores.
- Listagem de Unidades: O sistema deve permitir listar todas as unidades cadastradas e todos os colaboradores relacionados.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/6468bf82-2d96-4fe0-9a26-b4e5a79bc56e/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/ddd795eb-bd6e-4187-a44e-73f8d00f5756/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/bc39f8a2-d41d-45a7-bfba-5d27c474ee38/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/d0593015-742a-423a-86ac-313f7a2ec7cb/9cd10c85-d7c7-4284-a5a0-831dc41e3aae/Untitled.png)