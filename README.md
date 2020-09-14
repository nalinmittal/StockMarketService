# StockMarketService
The StockMarketService is a stock market simulator charting application. It is a full stack application written in .Net(C#) using the microservices architecture. It uses SQL for the database and AngularJS for the frontend.

There are three microservices. User, Admin and Account.

- User can view company details, latest IPO listings and Stock Price chartings
- Admin can manage(CRUD) Companies, Stock Exchanges, IPOs and upload Stock Pricing charts.
- Account handles authentication between users and admins.
- An Ocelot gateway is used to communicate between the Angular JS UI(StockMarketApp) and the microservices.

A preview of the SQL relational database structure is shown below.
![SQL Database](/SQL_Database.png)
