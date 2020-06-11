# Project Variables
PROJECT_NAME ?= Motivation



# Names that we will attach to sequences of commands. We will be able to run them by using these names, e.g 'make migrations'
.PHONY = migrations db api thankyou



# Commands required to run a migration and then apply it to the DB
migrations:
	cd ./backend/Motivation.Data && dotnet ef --startup-project ../Motivation.Api/ migrations add ${migrationName} && cd ..

db:
	cd ./backend/Motivation.Data && dotnet ef --startup-project ../Motivation.Api/ database update && cd ..

# Commands required to run the API project from the root directory
api:
	cd ./backend && dotnet build && dotnet run --project ./Motivation.Api/Motivation.Api.csproj

thankyou:
	echo 'Thank you for this opportunity!'