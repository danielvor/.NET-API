# .NET-API
API REST com .NET
## Como Rodar Localmente

1.  **Pré-requisitos:**
    * .NET SDK 8.0
    * Docker Desktop
    * Acesso ao seu cluster MongoDB (a Connection String está em `api/appsettings.json`)

2.  **Via Docker:**
    * Navegue até a pasta `TodoApp` no terminal.
    * Construa a imagem Docker:
        ```bash
        docker build -t todoapp-api -f Dockerfile .
        ```
    * Execute o contêiner:
        ```bash
        docker run -p 8080:80 todoapp-api
        ```
    * A API estará disponível em `http://localhost:8080`.

3.  **Via .NET CLI (sem Docker):**
    * Navegue até a pasta `TodoApp/api` no terminal.
    * Restaure as dependências:
        ```bash
        dotnet restore
        ```
    * Execute a aplicação:
        ```bash
        dotnet run
        ```
    * A API estará disponível em `http://localhost:5000` (ou outra porta indicada pelo .NET CLI).

## Endpoints da API

A API expõe os seguintes endpoints via `/api/Tasks`:

* **GET /api/Tasks**: Retorna todas as tarefas.
* **GET /api/Tasks/{id}**: Retorna uma tarefa por ID.
* **POST /api/Tasks**: Cria uma nova tarefa.
* **PUT /api/Tasks/{id}**: Atualiza uma tarefa existente.
* **DELETE /api/Tasks/{id}**: Exclui uma tarefa.

## Testando a API

Você pode testar a API usando:

* **Swagger UI:** Acesse `http://localhost:8080/swagger` (ou a porta correspondente) no navegador.
* **Postman/Insomnia:** Importe os endpoints para sua ferramenta favorita.
* **`curl`:** Exemplos de comandos `curl` podem ser encontrados na documentação do projeto.

## Deploy no Render

Para fazer o deploy no Render:

1.  Envie todo este projeto (a pasta `TodoApp` completa) para um repositório Git (GitHub, GitLab, Bitbucket).
2.  No Render, crie um novo "Web Service".
3.  Conecte seu repositório Git.
4.  Configure as seguintes opções:
    * **Root Directory:** `api` (esta é a pasta onde o `api.csproj` e o `Dockerfile` interno ao contexto do projeto estão)
    * **Runtime:** `Docker` (O Render detectará seu `Dockerfile`)
    * **Port:** `80` (A porta que a aplicação expõe dentro do contêiner)
    * (Opcional) Adicione variáveis de ambiente para a Connection String se preferir não mantê-la no `appsettings.json` do repositório público.
5.  Implante o serviço.

---

Com todos esses arquivos, você terá um projeto .NET completo e pronto para ser desenvolvido, testado e implantado!

Se precisar de ajuda para criar as pastas ou tiver qualquer outra dúvida, é só perguntar!