# Medic
Team laboratory work


To install:
1. Install MS SQL Server Express
2. Open PharmacyPurchase.Presentation appsettings.json and set server name to DefaultConnection
"DefaultConnection": "server=YOUR_SQL_SERVER;database=dev_Medical;Trusted_Connection=True;"
3. Open "Package Manager Console" tab in Visual Studio
4. Chose Project PharmacyPurchase.Data
5. Run command: Update-Database
