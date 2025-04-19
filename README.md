🌍 [Leia em Português](README.pt-BR.md)

# Mottu Mapping API

API RESTful developed as ASP.NET Core and Oracle bench to guide majors and perform mapping.

## Routes

(Motos)

- `GET api/motos` - Get All Motos.
- `GET api/motos/{id_setor} ` - Get Motos by Sector Id.
- `GET api/motos/search?nome=João` - Get with PathParams
- `POST api/motos` - Create a New Moto.
- `PUT api/motos/{id}` - Update Moto by Id.
- `DELETE api/motos/{id}` - Delete Moto by Id.

(Setor)

- `GET api/setor/{id}` - Get All Sectors
- `GET api/setor`
- `GET api/setor/search?nome=amarelo`
- `POST api/setor`
- `PUT api/setor/{id}`
- `DELETE api/setor/{id}`

(Patio)

- `GET api/patio/{id}`
- `GET api/patio`
- `GET api/patio/search?nome=amarelo`
- `POST api/patio`
- `PUT api/patio/{id}`
- `DELETE api/patio/{id}`

## Steps to run

1. Clone the repository:

```bash
git clone https://github.com/felipeclarindo/mottu-mapping-api-dotnet.git
```

2. Enter repository:

```bash
cd mottu-mapping-api-dotnet
```

3. Create and configure the `.env` file using the model in [.env.example](./.env.example)

4. Run migrations:

```bash
dotnet ef database update
```

5. Build the api:

```bash
dotnet build
```

6. Run the api:

```bash
dotnet run
```

7. The api is avaible on:

- http://localhost:5184

## Contribution

Contributions are welcome! If you have suggestions for improvements, feel free to open an issue or submit a pull request.

## Author

**Felipe Clarindo**

- [LinkedIn](https://www.linkedin.com/in/felipeclarindo)
- [Instagram](https://www.instagram.com/lipethecoder)
- [GitHub](https://github.com/felipeclarindo)

## License

This project is licensed under the [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
