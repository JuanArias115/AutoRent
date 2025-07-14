
# AutoRent

AutoRent is a client-server application for a car rental service. It helps administrators manage customers, cars, and rentals

<img width="1919" height="909" alt="image" src="https://github.com/user-attachments/assets/737c98a4-6b49-49db-977f-5c326ad5f7cf" />
<img width="1919" height="912" alt="image" src="https://github.com/user-attachments/assets/535d9f1f-eb99-41b9-82cb-9aa36cc1da67" />
<img width="1919" height="913" alt="image" src="https://github.com/user-attachments/assets/9a507e27-41f1-4873-83fd-d38e3d93ba62" />

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

