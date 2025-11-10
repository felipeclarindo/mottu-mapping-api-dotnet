🌍 [Read in English](README.md)

# Mottu Mapping API

API RESTful desenvolvida com ASP.NET Core e OracleDB + EF Core para gerenciar motos, pátios e setores.

## Rotas

(Motos)

- `GET api/motos` - Obter todas as motos.
- `GET api/motos/{id}` - Obter moto por ID.
- `GET api/motos/sectors/{sector_id}` - Obter motos por ID de setor.
- `POST api/motos` - Criar uma nova moto.
- `PUT api/motos/{id}` - Atualizar moto por ID.
- `DELETE api/motos/{id}` - Deletar moto por ID.

(Setores)

- `GET api/sectors` - Obter todos os setores.
- `GET api/sectors/{id}` - Obter setor por ID.
- `POST api/sectors` - Criar um novo setor.
- `PUT api/sectors/{id}` - Atualizar setor por ID.
- `DELETE api/sectors/{id}` - Deletar setor por ID.

(Pátios)

- `GET api/patios/{id}` - Obter pátio por ID.
- `GET api/patios` - Obter todos os pátios.
- `POST api/patios` - Criar um novo pátio.
- `PUT api/patios/{id}` - Atualizar pátio por ID.
- `DELETE api/patios/{id}` - Deletar pátio por ID.

## Passos para rodar

1. Clone o repositório:

```bash
git clone https://github.com/felipeclarindo/mottu-mapping-api-dotnet.git
```

2. Entre no repositório:

```bash
cd mottu-mapping-api-dotnet
```

3. Crie e configure o arquivo .env usando o modelo em [.env.example](./.env.example)

4. Enter no diretorio da API:

```bash
cd ./Src/WebApi
```

5. Execute as migrações:

```bash
dotnet ef database update
```

6. Rode a API:

```bash
dotnet run
```

7. A API está disponível em:

- <http://localhost:5272/api>

8. Para executar os testes, utilize o comando abaixo:

```bash
dotnet test
```

## Contribuição

Contribuições são bem-vindas! Se você tiver sugestões de melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
