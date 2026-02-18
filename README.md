# DogWalking
Dog Walking events challenge project

# Overview
This is a CRUD application for Walk Dog Events
While it only creates and deletes Events information, it can create and update Clients and Dog Information
- To update a Client, it takes the phone number as identifier, if the phone number exists in the database, the client will be updated, otherwise it will be created
- To update a Dog, it takes the dog name, brtand and age as identifiers

# Architecture (Strcuture)
Clean Architecture was applied so the application can be maintened, reused and extended.
Its architecture consist in:
- "Data" layer for configuration and access to the database
- "EntityDefinitions" Models definitions
- "LogProcessor" Log process class and its methods
- "Repository" direct interactions with the Database
- "UIProcessor" UI logic
- User Interface on main folder (since it is only one widows form)

# Requirements
- Windows 10 OS or later version
- Windows Desktop Runtime 8.0.24, you can download from https://aka.ms/dotnet-core-applaunch?missing_runtime=true&arch=x64&rid=win-x64&os=win10&apphost_version=8.0.24&gui=true
- Recommended screen resolution of 1280 x 960

# How to run the application
- Copy "Portable Application" in your PC
- Execute (doble click) to "DogWalksEvents.exe" file

# How the application works
- The main screen contain three areas
	- Filter Area, where the user can filter the events information
	- Visualization Area, with a grid where the user will see events information
	- Data Form Area, where the user can add/delete the events
- By default, the application will display all the data contained in the database
- Data From area is clear and ready to save new information when all inputs are introduced and "Save" button is clicked
- To filter the information, the user has the following fields:
	- Client's First Name, to filter all records where First Name start with
	- Client's Last Name, to filter all records where Last Name start with
	- Dog's Name, to filter all records with that Name
	- Dog's Brand, to filter all records with that Brand
	- Dog's Age, to filter all records with that Age
	- Event Date, to filter all records with that Date, this field must be checked to be included in the filter
- When selecting a record from the grid, all data will be populated in Data Form Area
	- Two buttons will be displayed "Clear" and "Delete"
	- "Clear" button clears the data form and record selection and hide the two buttons and display "Save" button
	- "Delete" button, will display a confirmation message end after that it will execute Delete process and refresh records in the grid
- To Exit the application, "Exit" button at the top rigth is available

# Assumptions
- The design was based on user friendly approach, so the user can have all the options in one single screen
- Each area is well identified to prevent misunderstandings
- Buttons are combined between graphic and text
- Since the requirement include in memory database, SQLite was used for this challenge
- No third party control were used to avoid additional requirements to run the application
- Three main structures were used for this challenge:
	- Clients
	- Dogs
	- Events, with foreign relationships on previous two structures
- EF Core as ORM
- Database creation will be created on first run
- For Logs file, a new "Logs" folder will be created (on first run) that will include "EventsLog.txt" file
	- In this file Success, Error and Validation logs will be saved

# AI usage
Use of AI was applied to create similar structures and logic or to create tests
- Github Copilot
- Both, client and dog queries handler where created based on DogWalkEventQueryHandler
- Aditional and complementary XML documentation was suggested by AI
- Test cases where created and then edited to make them more readable and keep applied standars

# Limitations and suggested Next Steps
- Impelement Login process, structure was taken into account, however, due a time limitation it was not implemented
- For initial setup, Migrations and seeders is recommended
- Improve the way the Data Forms clear the validations errors (the current approach is static and can make the maintain process harder)
- Implement an entire logic to create and delete event records without the data form, but work directly in the grid
- Implement Client and Dog CRUDs
