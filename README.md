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
- Vue

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
2. Open your localhost instance of Microsoft SQL Server and create a database called 'Motivation'. Use default for the owner.
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
