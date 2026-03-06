# DotNet-Productmanagement-API

# Technical Notes

Develop a RESTful Product Management API that allows clients to perform Create,Update Delete, List.

The API is designed using clean architecture principles, ensuring separation of concerns, maintainability, and scalability.

All endpoints are implemented asynchronously to improve performance and support high-concurrency environments.

Endpoints

1. Adds a new product<POST>- /api/products
2. Get All Products<GET> /api/products- Returns all products
3. Get Product<GET> /api/products/{id}	Returns product by id
4. Update Product<PUT> /api/products/{id}	Updates existing product
5. Delete Product<DELETE> /api/products/{id}	Deletes product

Use asynchronous programming (async/await) for all endpoints
Implement input validation before processing requests
Follow Repository Pattern for database access abstraction
Implement Service Layer for business logic
Use Dapper ORM for high-performance data access