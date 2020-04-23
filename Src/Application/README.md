Important! The application layer is implemented by using the CQRS + Mediator pattern. If you are not familiar with these patterns 
individually or combined, please do read https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs (Command and Query Responsibility Segregation) 
and https://refactoring.guru/design-patterns/mediator (Mediator pattern).

CQ -> commands and queries (app)

Common -> custom handlers, interfaces, mapping profiles, etc

GameCQ -> commands and queries (game)

GameContent/Utilities -> game logic and it's validators
