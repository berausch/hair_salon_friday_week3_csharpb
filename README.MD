# _Csharp Sql Salon_

#### _C# exercise for Epicodus , July 27th, 2016_

#### By _**Brittany Rausch**_

## Description

_This application allows the user to manage a salon database that matches Stylist to Clients in a one to many relationship. Teh user can add Stylists, and then add Clients and client specific notes to that Stylist. This application, which uses Sql, allows a Stylist to have many clients, but does not allow the clients to be associated by multiple Stylists. One the Clients and Stylists are entered, they can each be edited or deleted individually.  This app is an exercise in csharp and Sql integration._

## Setup/Installation Requirements

* _Clone this repository_
* _Load the Sql Databases hair_salon and hair_salon_test into your sql program_
* _Execute the sql files_
* _Or In sqlcmd, run the following commands-_
* CREATE DATABASE hair_salon;
* GO
* USE hair_salon;
* GO
* CREATE TABLE clients(
* id int IDENTITY(1,1),
* name varchar(255),
* notes varchar(255),
* stylist_id int
* )
* CREATE TABLE stylists(
* id int IDENTITY(1,1),
* name varchar(255),
* )
* GO
* _navigate in powershell to the Cloned folder_
* _run the command "dnu restore"_
* _run the command "dnx kestrel"_
* _open your preferred internet browser to localhost:5004_
* _Start Counting words!_

## Technologies Used

* _C#_
* _SQL_
* _Microsoft SQL Server Management Studio_
* _Xunit_
* _Nancy_
* _Windows Powershell_
* _Mono_
* _Html_
* _Razor_


### License

*{This software is licensed under MIT license}*

Copyright (c) 2016 **_Brittany Rausch_**
