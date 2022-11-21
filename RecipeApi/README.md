# Recipe API
ASP.NET Core REST API training / example project to test the [mediator pattern](https://en.wikipedia.org/wiki/Mediator_pattern) using the [MediatR](https://github.com/jbogard/MediatR) NuGet-package.

This project is set up, so that [CQRS](https://udidahan.com/2009/12/09/clarified-cqrs/) (Command-Query Responsibility Segregation) can be implemented, by introducing separate data models and injecting (for example) a "ReadOnlyDataStore", which implements `IDataStore`.

**Swagger UI**: https://localhost:7281/swagger/index.html

## Interesting links:
- [MediatR Repository](https://github.com/jbogard/MediatR)
- [A Mediator using source generators](https://github.com/martinothamar/Mediator)
- [Clarified CQRS](https://udidahan.com/2009/12/09/clarified-cqrs/)