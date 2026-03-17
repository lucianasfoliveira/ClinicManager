# ClinicManager - Gestão de Pacientes

O ClinicManager é um projeto desenvolvido em ASP.NET Core com o objetivo de gerenciar o cadastro de pacientes em clínicas de saúde.

Este projeto foi criado como parte do meu processo de transição para a área de desenvolvimento de software, unindo mais de 15 anos de experiência na área da saúde com práticas modernas de desenvolvimento em .NET.

## Funcionalidades

Atualmente o sistema possui o módulo de gestão de pacientes com as seguintes funcionalidades:

- Listagem de pacientes
- Cadastro de novos pacientes
- Alteração de dados de pacientes
- Exclusão de registros
- Cálculo automático de idade
- Validação de CPF duplicado
- Validação de data de nascimento

A interface utiliza modais com AJAX para uma experiência mais dinâmica ao usuário.

##  Regras de Negócio Implementadas

Algumas validações importantes foram implementadas na camada de domínio:

- Não permite cadastro de pacientes com CPF duplicado
- Data de nascimento não pode ser no futuro
- Data de nascimento mínima permitida: ano 1900
- CPF e Nome ficam bloqueados para edição após o cadastro

## Arquitetura

O projeto segue uma arquitetura em camadas para separar responsabilidades e facilitar manutenção.

```
Web
│
├── Controllers
├── Views
│
Application
│
├── AppServices
├── ViewModels
│
Domain
│
├── Entities
├── Core (RequestResult)
│
Infra
│
├── Repositories
```
### Camadas

**Web**

Interface MVC com Razor, Bootstrap e jQuery.

**Application**

Responsável por orquestrar os serviços e realizar o mapeamento entre ViewModels e entidades utilizando AutoMapper.

**Domain**

Contém as entidades e regras de negócio.

**Infra**

Responsável pelo acesso ao banco de dados utilizando Dapper.

## Tecnologias Utilizadas

- ASP.NET Core MVC
- Dapper
- SQL Server
- AutoMapper
- Bootstrap
- jQuery
- AJAX

## Entidade Principal

### Paciente

Campos do cadastro:

- Id
- Nome
- CPF
- Data de Nascimento
- Telefone
- Email
- Data de Cadastro

A idade do paciente é calculada automaticamente no sistema.

## Interface

### Lista de Pacientes

Tela principal com listagem e ações de cadastro, edição e exclusão.

## Roadmap

- [x] CRUD completo de pacientes
- [ ] Busca de pacientes por nome ou CPF
- [ ] Paginação da listagem
- [ ] Módulo de agendamento de consultas
- [ ] Prontuário eletrônico

## Como executar o projeto

1. Clonar o repositório


git clone https://github.com/seuusuario/ClinicManager.git


2. Configurar a connection string no arquivo `appsettings.json`

3. Criar a tabela PACIENTE no SQL Server
   
```sql
CREATE TABLE PACIENTE (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    NOME VARCHAR(150) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    DTNASCIMENTO DATE NOT NULL,
    TELEFONE VARCHAR(20) NOT NULL,
    EMAIL VARCHAR(150) NULL,
    DTCADASTRO DATETIME NOT NULL
);
```

4. Executar o projeto

## Sobre a Autora

Sou fisioterapeuta com mais de 15 anos de experiência na área da saúde e atualmente estou em transição de carreira para desenvolvimento de software, com foco em .NET e desenvolvimento backend.

Este projeto representa a união entre conhecimento de domínio na área da saúde e boas práticas de desenvolvimento.
