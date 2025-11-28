# 🎮 Game Data Management System
A C# Console Application designed to manage and analyze video game–related data such as game inventory, characters, and player progression. This project acts as a backend data manager that can support a simple video game or function as a standalone data management system.
## Features
- Manage game inventory (Add, View, Update, Delete)
- Manage characters and link them to games
- Manage player progression (levels, stats, achievements)
- User-friendly console menu navigation
- In-memory data storage with validation
## Project Structure
GameDataManagement/
├── Program.cs
├── Models/
│   ├── Game.cs
│   ├── Character.cs
│   └── Player.cs
├── Services/
│   ├── GameService.cs
│   ├── CharacterService.cs
│   └── PlayerService.cs
└── README.md
## How to Run
Requirements: .NET SDK 6 or above
Steps:
git clone <your-repo-url>
cd GameDataManagement
dotnet run
## Sample Console Menu
===== Game Data Management System =====
1. Manage Games
2. Manage Characters
3. Manage Players
4. Exit
Enter your choice:
## Future Enhancements
- Add JSON/Database persistence
- Add search and sorting features
- Add GUI (WPF/WinForms)
- Add reporting/analytics
- Add unit tests
## Author
Khushi Anand

