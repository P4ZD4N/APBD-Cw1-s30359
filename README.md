# APBD - C# Project 1

Console application created with C# for university devices rental service. Allows to add new devices (Cameras, Laptops and Projectors) and register new users (Employees and Students). Key features offered by system are rentals (with rental ends and possible fines), device availability tracking and displaying simple reports about devices. 

## Cohesion

Good example of high cohesion is **RentalValidatorService** which is responsible for protecting rental rules. All methods in this service are related to the same business context - rental validation.

## Coupling

