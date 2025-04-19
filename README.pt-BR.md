🌍 [Read in English](README.md)

# Mottu Mapping API

API RESTful desenvolvida com ASP.NET Core e banco Oracle para gerenciar matos e realizar o mapeamento.

## Rotas

- `GET /motos/{id_setor}`
- `GET /motos`
- `GET /motos/search?nome=João`
- `POST /motos`
- `PUT /motos/{id}`
- `DELETE /motos/{id}`

- `GET /setor/{id}`
- `GET /setor`
- `GET /setor/search?nome=amarelo`
- `POST /setor`
- `PUT /setor/{id}`
- `DELETE /setor/{id}`

## Passos para executar

1. Clone o repositório:

```bash
git clone https://github.com/felipeclarindo/mottu-mapping-api-dotnet.git
```

2. Entre no diretorio:

```bash
cd mottu-mapping-api-dotnet
```

3. Execute as migrações:

```bash
dotnet ef database update
```

4. Inicie a API:

```bash
dotnet run
```

## Contribuição

Contribuições são bem-vindas! Se você tiver sugestões de melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Autor

**Felipe Clarindo**

- [LinkedIn](https://www.linkedin.com/in/felipeclarindo)
- [Instagram](https://www.instagram.com/lipethecoder)
- [GitHub](https://github.com/felipeclarindo)

## Licença

Este projeto está licenciado sob a [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
