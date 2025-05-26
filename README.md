# Cloud-practice


# Crowdsourced Delivery System 🚚

A microservice-based solution for processing delivery orders and automatically assigning available couriers. This project is developed as part of the CloudTech course and includes the following core components: `Orders`, `Couriers`, `Deliveries`, `Transactions`, and `Clients`.

---

## Requirements

- .NET 8.0  
- ASP.NET Core Web API  
- EF Core InMemory  
- Prometheus (`prometheus-net.AspNetCore`)  
- Swashbuckle (Swagger)  
- HealthChecks  

---

## Functional Requirements

| #   | Requirement |
|-----|-------------|
| FR1 | A client can create a new order by specifying pickup/drop-off locations and desired delivery time |
| FR2 | The system saves the order with the status `created` |
| FR3 | The system automatically matches an available courier based on time and zone → order status becomes `matched` |
| FR4 | The assigned courier receives a delivery notification (status `assigned`) |
| FR5 | The courier can confirm pickup → status becomes `picked_up` |
| FR6 | The courier marks the delivery as complete → status becomes `delivered` |
| FR7 | The system updates order status to `in_progress` and `delivered` based on delivery updates |
| FR8 | The client can cancel an order before a courier is assigned → status becomes `cancelled` |
| FR9 | The client can pay for the order, choosing a payment method (card, PayPal, etc.) |
| FR10| The system creates a transaction for the order and updates its status (`pending`, `paid`, `failed`) |
| FR11| The admin can view order, delivery, and transaction history |

---

## Non-Functional Requirements

| #   | Requirement |
|-----|-------------|
| NFR1  | The system must handle up to 1000 orders per minute (scalability) |
| NFR2  | Average API response time must not exceed 300ms |
| NFR3  | Uptime must be at least 99.9% (max downtime: 0.1% monthly) |
| NFR4  | All personal data (PII) must be encrypted both in DB and messages |
| NFR5  | An event/message queue must be used for communication between services |
| NFR6  | Logging should persist into Azure Storage or a dedicated log queue |
| NFR7  | Service metrics should be available at `/metrics`, `/health`, and `/ping` |
| NFR8  | All services must include unit and integration tests |
| NFR9  | Caching (e.g., available couriers) must be used to speed up decisions |
| NFR10 | A CI/CD pipeline (build → test → deploy) must be configured (e.g., Azure Pipelines) |
| NFR11 | The API should be minimally secured (e.g., API Key or OAuth for clients/couriers) |

---

## Diagrams

The ERD diagram and Services Communication Diagram are available in the `Docs` folder.

---

## API Endpoints

### 📦 Orders

#### `GET /orders/{id}`  
Returns order details by ID.

**Example response:**
```json
{
  "orderId": 1,
  "clientId": 2,
  "pickupLocation": "Street A",
  "dropoffLocation": "Street B",
  "scheduledTime": "2024-05-27T12:00:00",
  "status": "created"
}
```

#### `POST /orders`  
Creates a new delivery order.

**Example request:**
```json
{
  "clientId": 2,
  "pickupLocation": "Street A",
  "dropoffLocation": "Street B",
  "scheduledTime": "2024-05-27T12:00:00"
}
```

---

### 🔧 System Endpoints

#### `GET /ping`  
Returns `"pong"` — simple liveness check.

#### `GET /health`  
Application health check.  
**Example response:**
```json
{"status":"Healthy"}
```

#### `GET /metrics`  
Prometheus-compatible metrics endpoint.  
**Example:**
```
# HELP http_requests_total
# TYPE http_requests_total counter
http_requests_total{method="GET",code="200"} 5
```

---
