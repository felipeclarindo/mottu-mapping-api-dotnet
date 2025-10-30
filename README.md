🌍 [Leia em Português](README.pt-BR.md)

# Mottu Mapping API

API RESTfulf developed as ASP.NET Core and OracleDB + EF Core to manage the motos, patios and sectors.

## Routes

(Motos)

- `GET api/v1/motos` - Get All Motos.
- `GET api/v1/motos/{id}` - Get Moto by Id.
- `GET api/v1/motos/sectors/{sector_id}` - Get Motos by Sector Id.
- `POST api/v1/motos` - Create a New Moto.
- `PUT api/v1/motos/{id}` - Update Moto by Id.
- `DELETE api/v1/motos/{id}` - Delete Moto by Id.

(Sectors)

- `GET api/v1/sectors` - Get All Sectors.
- `GET api/v1/sectors/{id}`- Get Sector by Id.
- `POST api/v1/sectors` - Create a New Sector.
- `PUT api/v1/sectors/{id}` - Update Sector by Id.
- `DELETE api/v1/sectors/{id}` - Delete Sector by Id.

(Patios)

- `GET api/v1/patios/{id}` - Get Patio by id
- `GET api/v1/patios` - Get All Patios.
- `POST api/v1/patios` - Create a New patio
- `PUT api/v1/patios/{id}` - Update Patio by Id.
- `DELETE api/v1/patios/{id}` - Delete Patio by Id.

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

4. Enter in Api Directory:

```bash
cd ./Src/WebApi
```

5. Run migrations:

```bash
dotnet ef database update
```

6. Run the api:

```bash
dotnet run
```

7. The api is avaible on:

- <http://localhost:5272/api/v1>

## Contribution

Contributions are welcome! If you have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
