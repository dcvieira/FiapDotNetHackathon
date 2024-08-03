![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/dcvieira0044/automation-testing-strategies-aspnet/29) ![Azure DevOps tests](https://img.shields.io/azure-devops/tests/dcvieira0044/automation-testing-strategies-aspnet/29)


# Hackathon - Turma .NET
A Health&Med, é uma Operadora de Saúde que tem como objetivo digitalizar seus processos e operação. O principal gargalo da empresa é o Agendamento de
Consultas Médicas, que atualmente ocorre exclusivamente através de ligações para a central de atendimento da empresa.
Recentemente, a empresa recebeu um aporte e decidiu investir no
desenvolvimento de um sistema proprietário, visando proporcionar um processo
de Agendamentos de Consultas Médicas 100% digital e mais ágil.
Para viabilizar o desenvolvimento de um sistema que esteja em conformidade
com as melhores práticas de desenvolvimento, a Health&Med contratou os alunos
do curso de Pós Graduação .NET da FIAP para fazer a análise do projeto e
desenvolver o MVP da solução.
O objetivo do Hackathon é a entrega de um produto de MVP desenvolvido e que
cumpra os requisitos funcionais e não funcionais descritos abaixo.

## Requisitos Funcionais 

1. Cadastro do Usuário (Médico)
O médico deverá poder se cadastrar, preenchendo os campos
obrigatórios: Nome, CPF, Número CRM, E-mail e Senha.
2. Autenticação do Usuário (Médico)
Hackathon - Turma .NET 2
O sistema deve permitir que o médico faça login usando o E-mail e uma
Senha.
3. Cadastro/Edição de Horários Disponíveis (Médico)
O sistema deve permitir que o médico faça o Cadastro e Edição de seus
horários disponíveis para agendamento de consultas.
4. Cadastro do Usuário (Paciente)
O paciente poderá se cadastrar preenchendo os campos: Nome, CPF, Email
e Senha.
5. Autenticação do Usuário (Paciente)
O sistema deve permitir que o paciente faça login usando um E-mail e
Senha.
6. Busca por Médicos (Paciente)
O sistema deve permitir que o paciente visualize a listagem dos médicos
disponíveis.
7. Agendamento de Consultas (Paciente)
Após selecionar o médico, o paciente deve poder visualizar a agenda do
médico com os horários disponíveis e efetuar o agendamento.
8. Notificação de consulta marcada (Médico)
Após o agendamento, feito pelo usuário Paciente, o médico deverá
receber um e-mail contendo:
Título do e-mail:
”Health&Med - Nova consulta agendada”
Corpo do e-mail:
”Olá, Dr. {nome_do_médico}!
Você tem uma nova consulta marcada!
Paciente: {nome_do_paciente}.
Data e horário: {data} às {horário_agendado}.”

## Requisitos Não Funcionais
1. Concorrência de Agendamentos
O sistema deve ser capaz de suportar múltiplos acessos simultâneos e
garantir que apenas uma marcação de consulta seja permitida para um
determinado horário.
2. Validação de Conflito de Horários
O sistema deve validar a disponibilidade do horário selecionado em tempo
real, assegurando que não haja sobreposição de horários para consultas
agendadas.

## Iniciando

Para acessar a aplicação hospedada no Azure acesse o  endereço https://fiap-hackathon-f7cyata0hnd5djat.eastus-01.azurewebsites.net/swagger/index.html

Para rodar local você deverá incluir sua connection string do banco de dados postgres. A aplicação execute o migration no startup

A aplicação envia e-mails. Você pode configurar um e-mail local utilizando a imagem do docker rnwood/smpt4dev

```bash
docker pull rnwood/smpt4dev
docker run --rm -d --name fakemail -p 3000:80 -p 2525:25 rnwood/smtp4dev

```


## Diagrama de banco de Dados

![architectural diagram](images/diagram_bd.JPG)

## API endpoints

- **/Login e Register**
  - `/login` realiza login. somente e-mail e senha
  - `/register` cria uma conta de usuário. Somente e-mail e senha

- **/Doctors**
  - `GET` Lista todos os doutores disponíveis no sistema
  - `POST` Usuário logado cria seu cadastro como Doutor

- **/Patients**
  - `GET` Lista todos os pacientes  disponíveis no sistema
  - `POST` Usuário logado cria seu cadastro como Paciente

- **/AvailableSchedules**
  - `GET` Lista todos os horários disponíveis de todos os doutores para agendamento. 
  - `POST` Usuário logado com cadastro de Doutor cria um horário na agenda
  - `PUT` Usuário logado com cadastro de Doutor edita seu horário na agenda

- **/Appointments**
  - `GET` Lista todos os agendamentos do usuário logado e cadastrado como paciente
  - `POST` Agenda um horário disponível com um doutor

"Catch" with a refactoring change:

- change the "admin" role to be "administrator" and see what breaks
(maybe make it a different claim type than role and change to a "policy"??)

For the learner:

- Add edit and (soft) delete to the API and WebApp, then write tests
- More complex "cart edit" functionality
- Be able to apply a "promotion" on the Cart page

## VS Code Setup

RUnning in VS Code is a totally legitimate use-case for this solution and
repo.

The same instructions above (Getting Started) apply here, but the following
extension should probably be installed (it includes some other extensions):

- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

Then run the API project and the UI project.

## Data and EF Core Migrations

The `dotnet ef` tool is used to manage EF Core migrations.  The following command is used to create migrations (from the `CarvedRock.Data` folder).

```bash
dotnet ef migrations add Initial -s ../CarvedRock.Api
```

The initial setup for the application uses SQLite.
The data will be stored in a file called `carvedrock-sample.sqlite` as
defined in the API project's `appsettings.json` file.

The location of the file is in the "local AppData" folder (`Environment.SpecialFolder.LocalApplicationData`):

- Windows: `C:\Users\<username>\AppData\Local\`
- Mac: `/Users/USERNAME/.local/share`

To browse / query the data, you can use some handy extensions:

- In Visual Studio, use the [SQLite and SQL Server Compact Toolbox](https://marketplace.visualstudio.com/items?itemName=ErikEJ.SQLServerCompactSQLiteToolbox) extension
- In VS Code, use the [SQLite Viewer](https://marketplace.visualstudio.com/items?itemName=qwtel.sqlite-viewer) extension

## Verifiying Emails

The very simple email functionality is done using a template
from [this GitHub repo](https://github.com/leemunroe/responsive-html-email-template)
and the [smtp4dev](https://github.com/rnwood/smtp4dev)
service that can easily run in a Docker container.

There is a UI that you can naviagte to in your browser for
seeing the emails that works great.  If you use the `docker run` command
that I have listed above, the UI is at
[http://localhost:3000](http://localhost:3000).

There is also an API that is part of that service and a couple of quick
API calls call give you the content of the email body that you
want to verify:

```bash
GET http://localhost:3000/api/messages

### find the ID of the message you care about

GET http://localhost:3000/api/messages/<message-guid>/html
```
