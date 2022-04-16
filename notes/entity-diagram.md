# ContosoPizza Entity Diagram

```mermaid
erDiagram
    Customer ||--o{ Order : places
    Order ||--|{ OrderDetail : contains
    Product }|--|{ OrderDetail : "ordered in"
    Customer {
        int Id
        string FirstName
        string LastName
        string Address
        string Phone
        string Email
    }
    Order {
        int Id
        timestamp OrderPlaced
        timestamp OrderFulfilled
        int CustomerId
    }
    OrderDetail {
        int Id
        int Quantity
        int OrderId
        int ProductId
    }
    Product {
        int Id
        string Name
        decimal Price
    }
```