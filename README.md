# Umbraco.Template
This project is an easily customizable and adaptable website template built on Umbraco CMS. Designed to meet various needs, it includes a range of features that simplify the process of kickstarting your web project.

The template's front-end is provided in Arabic, making it an excellent choice for any entity (government, private sector, non-profit organizations) that needs to create a public-facing website in Arabic.

### Developed By:
This template is developed by <a id='ssFeatures' href='https://interactive.sa'>Interactive Saudi Arabia</a>, Your Software Development Partner In Saudi Arabia.
![Interactive](https://partner.kentico.com/getmedia/aa454e01-1437-4661-abd8-2680024479c7/interactive-logo.png)

## Features
* Mobile-friendly design
* Easy content management with Umbraco CMS
* Customizable templates and styles
* SEO optimized structure
* Includes pre-build sections like News, E-Services catalog, Contact-Us, etc....
* Arabic front-end interface
* Complies with Saudi Digital Government Authority (DGA) standards

## Prerequisites
* .NET Version: .NET 6.0 or later
* MS SQL Server 2016 or later
* IDE: Visual Studio 2022 or Visual Studio Code
* Web Server: IIS for Windows Server hosting

## Installation
1.	Clone the repository:
2.	Open the solution in Visual Studio.
3.	Restore the NuGet packages.
4.	Restore the database included in the db folder into your MS SQL Server
5.	Set Up Database Connection
Open the appsettings.json file and configure your database connection string. For SQL Server, it looks like this: 
"ConnectionStrings": {
  "DefaultConnection":"Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
}
6.	Build the solution and run the project.

## Deployment
To deploy the project to a live server, follow these steps:
1.	Restore the database included in the db folder into your MS SQL Server
2.	Configure your database connection in the appsettings.json file.
3.	Publish the project using Visual Studio.
4.	Transfer the published files to your web server.
5.	Set up the initial admin user and start managing the website.

## Contributing
Contributions are welcome! Please fork this repository and submit pull requests for any improvements or feature additions.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
## Acknowledgements
* Umbraco CMS


