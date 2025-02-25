ASP.NET API med Swagger
=======================

Detta projekt visar hur man skapar ett ASP.NET Web API och använder Swagger för automatisk dokumentation och testning. API:et hanterar låtar och kategorier, lagras i en SQLite-databas, och kan enkelt testas med Swagger UI eller Thunder Client.

Funktioner
----------

-   **Skapa API:** Grundläggande ASP.NET API med två resurser: `Song` och `SongCategory`.
-   **Swagger UI:** Använder Swagger för att automatiskt generera dokumentation och en användarvänlig gränssnitt för att testa API:et.
-   **Entity Framework Core:** Använder EF Core med SQLite för att hantera data.

Installation
------------

1.  Klona repositoryt:

    `git clone https://github.com/ditt-användarnamn/ditt-repository.git`

2.  Navigera till projektmappen:

    `cd komoment04`

3.  Installera nödvändiga NuGet-paket:

    `dotnet restore`

4.  Starta projektet:

    `dotnet run`

5.  Öppna Swagger UI i webbläsaren:

    -   Gå till: `https://localhost:5001/swagger` (eller den port som används i din miljö).

API Endpoints
-------------

-   **GET** `/api/song`: Hämta alla låtar.

-   **GET** `/api/song/{id}`: Hämta en specifik låt baserat på ID.

-   **POST** `/api/song`: Lägg till en ny låt.

-   **PUT** `/api/song/{id}`: Uppdatera en befintlig låt.

-   **DELETE** `/api/song/{id}`: Ta bort en låt.

-   **GET** `/api/category`: Hämta alla kategorier.

-   **GET** `/api/category/{id}`: Hämta en specifik kategori baserat på ID.

-   **POST** `/api/category`: Lägg till en ny kategori.

-   **PUT** `/api/category/{id}`: Uppdatera en befintlig kategori.

-   **DELETE** `/api/category/{id}`: Ta bort en kategori.

Teknologier
-----------

-   ASP.NET Core
-   Swagger för API-dokumentation
-   Entity Framework Core
-   SQLite