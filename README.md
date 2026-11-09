# AdsApi

A RESTful ASP.NET Core Web API for managing classified ads, built with
Entity Framework Core (Code First) and SQL Server.

## Tech stack
- ASP.NET Core Web API (controller-based)
- Entity Framework Core – Code First with migrations
- SQL Server
- Swagger UI (OpenAPI)
- JSON Patch for partial updates

## Requirements
- .NET SDK 10.0
- A local SQL Server (default instance, `Server=.`)

## Getting started
1. Clone the repository
2. Open the solution in Visual Studio
3. Run the project (F5)

On startup the database `AdsApiDb` is created automatically via migrations
and seeded with 5 sample ads. Swagger UI opens in the browser at `http://localhost:5269/`
(or `https://localhost:7129/` when using the https profile).

## Endpoints

| Method | Route        | Description              | Success          |
|--------|--------------|--------------------------|------------------|
| GET    | `/Ads`       | List all ads             | `200 OK`         |
| GET    | `/Ads/{id}`  | Get one ad               | `200 OK`         |
| POST   | `/Ads`       | Create an ad             | `201 Created`    |
| PUT    | `/Ads/{id}`  | Full update of an ad     | `200 OK`         |
| PATCH  | `/Ads/{id}`  | Partial update           | `200 OK`         |
| DELETE | `/Ads/{id}`  | Delete an ad             | `204 No Content` |

Error responses: `404 Not Found` if the ad does not exist,
`400 Bad Request` if the data is invalid.

## Testing
`AdsApi.http` contains test requests for all endpoints, covering both
success and error cases. Open it in Visual Studio and send the requests
while the app is running.

## Design decisions
- `Id` and `CreateDate` are always set by the server and cannot be changed by the client.
- PUT uses the id from the route; any id in the request body is ignored.
- PATCH validates the ad *after* the patch is applied, so invalid values are rejected before saving.