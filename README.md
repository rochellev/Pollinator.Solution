# Pollinator
### By: Rochelle Roberts, Lisa Jensen, and Maryana Antonyuk
----

## Description
* Pollinator is a Web App allowing users to create and take polls.

## Technologies Used
* C#
* .NET
* ASP.NET Core MVC
* Entity Framework
* MySQL
* HTML
* CSS
* Bootstrap

## Installation
* Follow steps below
* Go to http://localhost:5000

```sh
$ git clone https://github.com/rochellev/Pollinator.Solution.git
$ cd  .\Pollinator.Solution\Pollinator
$ dotnet restore
$ dotnet ef database update
$ dotnet run
```

## User Stories
* There is only one site admin.
* The admin can view and modify any poll so that the site can be managed.
* A registered user can create a new poll so other users can take it.
* A registered user fills out a new poll form to create a poll.
* A registered user can view all the polls they have created so they can manage their quizzes.
* Any user can view the results of a poll so they can know how the poll turned out.
* A registered user can only vote once per poll so that the poll results are fair.
* Poll results are shown graphically to make results more interesting.
* Poll results cannot be altered by any user.
