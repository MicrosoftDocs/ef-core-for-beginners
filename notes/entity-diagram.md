# ContosoPizza Entity Diagram

```mermaid
erDiagram
    Customer ||--o{ Order : places
    Order ||--|{ OrderDetail : contains
    Product }|--|{ OrderDetail : "ordered in"
    Customer {
        string FirstName
        string LastName
        string Address
        string Phone
        string Email
    }
    Order {
        timestamp OrderPlaced
        timestamp OrderFulfilled
    }
    OrderDetail {
        int Quantity
    }
    Product {
        string Name
        decimal Price
    }
```