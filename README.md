# Pollinator
### By: Rochelle Roberts, Lisa Jensen, and Maryana Antonyuk
----

## Description
* Pollinator is a Web App allowing users to create and take polls. [Pollinator](http://ec2-18-216-22-80.us-east-2.compute.amazonaws.com:5000/)

## Technologies Used
* C#
* .NET
* ASP .NET Core MVC
* Entity Framework
* MySQL
* HTML
* CSS
* Bootstrap
* Amazon Web Services for Hosting

## Installation
* Hosted on AWS [Here](http://ec2-18-216-22-80.us-east-2.compute.amazonaws.com:5000/)
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
* A user must register before logging in.
* A user must log in before viewing polls.
* A registered user can create a new poll so other users can take it.
* A registered user fills out a new poll form to create a poll.
* Any user can view the results of a poll so they can know how the poll turned out.
* Poll results are shown graphically to make results more interesting.
* Poll results cannot be altered by any user.

## Data Relations
* One-to-Many
    * One quiz has many responses
    * MySQL