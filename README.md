# Motivation

This is a cheerful web application that shows the user a motivational message of the day.

## Tools and Technologies Used
- .Net Core 3.1
- .Net Core CLI
- Entity Framework Core
- MS SQL Server

- HTML
- CSS
- JavaScript
- Handlebars

- NUnit
- Moq
- Postman
- Git
- Bash
- Make


## How to Run the App
1. Open a command line and run
    ```
        git clone https://github.com/Evie-Skinner18/Motivation.git
    ```
2. Open your localhost instance of Microsoft SQL Server and create a database called 'Motivation'. Use default for the owner. You can also do this by running the 'CreateMotivationDb.sql' file in the setup directory.
3. Create a .env file in the root directory of the Motivation project:
    ```
        touch .env
    ```
4. Open the .env file and add the following to it:
    ```
        DEV_CONNECTION_STRING="Server=localhost;Database=Motivation;Trusted_Connection=True;"
    ```
5. Still from the root directory, run the following command to update your new database with all the available migrations:
    ```
        make db
    ```
6. Seed the database by running the 'SeedMessagesTable.sql' file in the setup directory.
7. Back in the command line, run
	```
	dotnet test
	```
8. Run the command
   ```
	make api
   ```
   to run the API.
9. Open the frontend project in Visual Studio Code, and run index.html via LiveServer, which will open up index.html at http://localhost:5500.

## Known Issues
- I have not managed to make the front end consume the C# API properly. Currently it can make a request, but it receives an undefined response.



## In a Future Iteration, I would...
- Write more unit tests for the service logic
- Fix the front end so that it can consume the API
- Implement the front end using Vue components
- Automate the setup process for a new user with a Powershell/Bash script

