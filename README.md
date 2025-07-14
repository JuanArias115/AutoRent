
# AutoRent

AutoRent is a client-server application for a car rental service. It helps administrators manage customers, cars, and rentals

<img width="1919" height="911" alt="image" src="https://github.com/user-attachments/assets/c9607755-9067-4f95-ad6c-a49ed342aee8" />
<img width="1919" height="905" alt="image" src="https://github.com/user-attachments/assets/d8b2968b-937f-49c0-bda0-21248f58cf29" />
<img width="1919" height="902" alt="image" src="https://github.com/user-attachments/assets/7fdb07f4-3993-45e7-bea2-121d14445e33" />


## Tech Stack

**Client:** Angular 20 

**Server:** Asp.NET Core 8

**Data Base:** SQL Server



## Installation

**Requisites**
- Node.js
- Angular CLI   
- SQL Server

**Clone Repository**

```bash
git clone https://github.com/JuanArias115/AutoRent.git
cd AutoRent
```
    
**Initialize Data Base**
```bash
cd Backend
dotnet ef add initialSeed
```

**Update**
```bash
dotnet ef database update
```

**Optional (load predefined vehicle catalog)**
```bash
dotnet run --seed
```

**Frontend**
```bash
cd front
```
```bash
npm install
```
```bash
ng serve -o
```


## License
Created by Juan Arias

