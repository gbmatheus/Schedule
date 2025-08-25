# Schedule API
[![Ask DeepWiki](https://devin.ai/assets/askdeepwiki.png)](https://deepwiki.com/gbmatheus/Schedule)

This repository contains a simple API for managing room schedules and bookings. The system allows users to create rooms and then schedule bookings for specific time slots within those rooms. The project is built with .NET 8 and follows a Clean Architecture approach.

Esse repositório contém uma API simples para gerenciar horários e reservas de salas. O sistema permite que os usuários criem salas e, em seguida, agendem reservas para intervalos de tempo específicos dentro dessas salas. O projeto foi desenvolvido com .NET 8.


## Funcionalidades

* **Gerenciamento de Salas:**

  * Criar novas salas.
  * Recuperar uma lista de todas as salas disponíveis.
  * Obter detalhes de uma sala específica, incluindo sua agenda.

* **Gerenciamento de Agendas:**

  * Criar novas agendas (reservas) para uma sala.
  * Validar disponibilidade para evitar reservas sobrepostas.
  * Recuperar todas as agendas existentes.
  * Obter detalhes de uma agenda específica.
  * Cancelar uma agenda existente.

## Arquitetura

A solução é estruturada utilizando alguns princípios para promover separação de responsabilidades.

* **`Domain`**: Contém a lógica de negócio, entidades (`Room`, `Schedule`), objetos de valor (`DateTimeRange`), interfaces de repositório e exceções de domínio personalizadas. Não possui dependências de outras camadas.
* **`Application`**: Orquestra a lógica de negócio. Contém os casos de uso (serviços de aplicação), DTOs (Data Transfer Objects), lógica de validação (usando FluentValidation) e mapeamento entre objetos (usando AutoMapper). Depende apenas da camada Domain.
* **`Infrastructure`**: Implementa os detalhes de preocupações externas, principalmente o acesso a dados. Contém o `DbContext` do Entity Framework Core, implementações de repositório usando SQLite e o padrão Unit of Work. Depende das camadas Application e Domain.
* **`Api`**: A camada de apresentação. É uma Web API em ASP.NET Core que expõe endpoints. Lida com requisições HTTP, respostas e as encaminha para os casos de uso na camada Application. Inclui um filtro de exceção customizado para fornecer respostas de erro.
* **`Exception`**: Uma biblioteca compartilhada para tipos de exceções personalizadas utilizadas em toda a aplicação.
* **`Domain.Tests`**: Testes unitários da camada Domain, verificar as regras de negócio sejam corretamente implementadas.


## Tecnologias Utilizadas

*   **.NET 8** / **ASP.NET Core 8**
*   **Entity Framework Core 8**
*   **SQLite**
*   **AutoMapper**
*   **FluentValidation**
*   **xUnit** e **FluentAssertions** para testes
*   **Swagger/OpenAPI** para documentação da API


## Primeiros Passos

### Pré-requisitos

*   .NET 8 SDK

### Instalação e Execução

1. Clone o repositório:

   ```sh
   git clone https://github.com/gbmatheus/Schedule.git
   cd Schedule
   ```

2. Navegue até o diretório do projeto da API:

   ```sh
   cd src/Api
   ```

3. Execute a aplicação:

   ```sh
   dotnet run   ```

4.  A API estará em execução em `http://localhost:5122`. Você pode acessar o Swagger UI para documentação interativa da API em `http://localhost:5122/swagger`.

## API Endpoints

### Gerenciamento de Salas

* **Criar uma nova Sala**

  * `POST /api/Room`
  * **Body:**

    ```json
    {
      "name": "Conference Room A"
    }
    ```

* **Listar todas as Salas**

  * `GET /api/Room`

* **Obter Sala por ID**

  * `GET /api/Room/{id}`

---

### Gerenciamento de Agendas

* **Criar uma nova Agenda**

  * `POST /api/Schedule`
  * **Descrição:** Cria uma reserva para uma sala específica. As datas de início e fim devem estar no mesmo dia. O sistema rejeitará reservas que se sobreponham a agendas já existentes para a mesma sala.
  * **Body:**

    ```json
    {
      "roomId": 1,
      "startDateTime": "2025-09-27T14:00:00Z",
      "endDateTime": "2025-09-27T15:00:00Z"
    }
    ```

* **Listar todas as Agendas**

  * `GET /api/Schedule`

* **Obter Agenda por ID**

  * `GET /api/Schedule/{id}`

* **Cancelar uma Agenda**

  * `PUT /api/Schedule/{id}`
  * **Descrição:** Altera o status da agenda para **"Cancelled"**. Não exclui o registro.
