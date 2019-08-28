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
* A user must register before logging in.
* A user must log in before viewing polls.
* The admin can view and modify any poll so that the site can be managed.
* A registered user can create a new poll so other users can take it.
* A registered user fills out a new poll form to create a poll.
* A registered user can view all the polls they have created so they can manage their quizzes.
* Any user can view the results of a poll so they can know how the poll turned out.
* A registered user can only vote once per poll so that the poll results are fair.
* Poll results are shown graphically to make results more interesting.
* Poll results cannot be altered by any user.


## Things to Think about/do
* a page to see All polls
    * right now it's just the current user's polls
* Poll details page
    * needs better styling
    * add response info
* Poll creation page
    * require all the fields, not sure if that is implemented right now
* Response Index
    * not currently implemented (tuesday)
    * could be a user's history of their poll answers
    * only see their responses
    * admin see all users responses
* Response Creation
    * in the list view of quizzes
* Hosting ;)
* About us page
    * link in navbar
* Login
  * error messages -- need to register before logging in, failed password, username taken
  * Add user name to navbar
    * have logout option visible -- navbar? hover action?
    * maybe "manage account page" 
