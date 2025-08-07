# SnipeIT Automation Task

## Tech Stack
- .NET 8
- Playwright for .NET
- xUnit
- Page Object Model (POM)

## How to Run

1. Clone the repo:
```bash
git clone https://github.com/your-username/snipeit-automation.git
cd snipeit-automation
```

2. Install dependencies:
```bash
dotnet restore
dotnet playwright install
```

3. Run the test:
```bash
dotnet test
```

## Notes
- Uses Snipe-IT Demo credentials: `admin@admin.com` / `password`
- Runs in non-headless mode by default
