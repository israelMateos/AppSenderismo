# AppSenderismo

Made by Israel Mateos Aparicio Ruiz Santa Quiteria for Human Computer Interaction I course.

The main objective of this project is developing a prototype for an application which can be used to manage hiking routes and other related information. The data will be stored in a MySQL local database. The purpose of this application is not to develop a fully-functional app, but designing an accessible and coherent interface by using WPF and C#. Because of this project not being ready for commercial use, the application is not compiled by default.

## How to use

**Prerequisites**: `Visual Studio 2019` (not newer), `MySQL`.

Before installing the application, a new MySQL connection must be created with the following parameters:

* Server = "localhost".
* Port = 3306.
* User = "root".
* Password = "root".
* SSL Mode = None.

Once it is created, a schema called "routes_management" must be added to it, and the generation and filling of its tables must be done by executing the script `./BBDD/routes_management.sql`.

Then, in order to compile the application the solution `./AppSenderismo.sln` has to be opened in Visual Studio. By using the option "Build" in a "Release" configuration, a new folder will be created in `./AppSenderismo/` for it. Inside of this new folder, you will find an `.exe` application, which corresponds to the main app. It is important that the MySQL connection previously created is running before executing the application in order to run properly.

## Project structure

This repository contains the following files and directories:

- `AppSenderismo` has the code and project files.
- `BBDD` has both the script for generating the MySQL database schema and the MySQL .NET Connector library (in _dll_ format).
- `.gitattributes` sets the behaviour for different files for Git.
- `AppSenderismo.sln` is the main project solution for Visual Studio.
