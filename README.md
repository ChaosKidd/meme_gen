# Meme_gen

Meme_gen is an ASP.NET Core MVC web application that allows users to create, edit, and bookmark memes in their accounts for easy access. Users can choose from predefined meme templates or upload custom images to edit with text. The app leverages ASP.NET Core Identity for authentication, Fabric.js for in-browser image editing, and a responsive design inspired by Pinterest.


## Getting Started

### Prerequisites

- [.NET 9](https://dotnet.microsoft.com/download)
- A code editor such as [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)
- A modern web browser (Chrome, Firefox, Edge, etc.)

### Installation

1. **Clone the repository:**

   ```bash
    https://github.com/CootsAndLoons/meme_gen.git
    ```
2. **Restore NuGet packages:**
    ```bash
    dotnet restore
    ```
3. **Add a migration:**
    ```bash
    dotnet ef migrations add InitialMigration
    ```
4. **Update the database:**
    ```bash
    dotnet ef database update
    ```
5. **Build and run:**
    ```bash
    dotnet run
    ```

## Program Flow
```bash
+------------------+
| Start App        |
+--------+---------+
         |
         v
+------------------+
| Load Templates   |
| from wwwroot/    |
+--------+---------+
         |
         v
+------------------+
| User Visits Site |
+--------+---------+
         |
         v
     +---+---+
     |Logged |
     |  In?  |
     +---+---+
    No  |   |  Yes
        |   |
        v   v
    +---+   +---+
    |         |
    v         v
+-------+ +---------+
|View   | |Full     |
|Only   | |Access   |
+---+---+ +----+----+
    |          |
    v          v
+-------+ +---------+
|Browse | |Browse    |
|Memes  | |Memes    |
+---+---+ +----+----+
    |          |
    v          v
+-------+ +---------+
|Template| |Template|
|Action  | |Action  |
+---+---+ +----+----+
    |          |
    |          v 
    v        +-----+
+-------+    |     |
|Edit   |    |     |
|Memes  |    |     |
+-------+    v     v
    |    +-----+ +-----+
    |    |Edit | |Book |
    v    |Meme | |mark |
+-----+  +--+--+ +--+--+
|Down |    |       |
|load |    v       v
+-----+ +-----+ +-----+
        |Down | |Save |
        |load | |to DB|
        +-----+ +-----+
```

## Contributors
 - [WzëBe](https://github.com/CootsAndLoons) - Project Lead, Developer
 - [ChaosKidd](https://github.com/ChaosKidd) - Front-End developer
 - [Stochko](https://github.com/Stochko) - Front-End developer
 - [Kristiyan Stoykov](https://github.com/kriskata06) - Full-Stack developer
