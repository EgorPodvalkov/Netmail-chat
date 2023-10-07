# Netmail-chat 
###### Pet project for NewGen C# .NET course. 

Netmail-chat is the web server, which you can use for chatting or posting news using RESTful API or base web UI on MVC.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing. 

### Prerequisites
Before you can run the app, you should install mysql database client and get your db connection string. Next you should to go to PL folder, create appsettings.json file and paste this code to it.
``` json
{
  "ConnectionString": //your connection string,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Running
You should build the solution and run the server.

## App Guide
The list of actual Endpoints you can see and try in my postman public folder. ☺️

[![Run in Postman](https://run.pstmn.io/button.svg)](https://god.gw.postman.com/run-collection/16304928-905792eb-a1b6-43d5-9733-8d9df51ff869?action=collection%2Ffork&source=rip_markdown&collection-url=entityId%3D16304928-905792eb-a1b6-43d5-9733-8d9df51ff869%26entityType%3Dcollection%26workspaceId%3D0a384d53-9c4a-45f8-80b3-6f3a34c2bc0f)

For posting articles with */AddArticle* endpoint you should first hardcode the editor in Editors table in DB. Example SQL command:
``` sql
USE -- your db name --
GO

INSERT INTO [dbo].[Editors]
    ([ID], [Name], [Pass])
VALUES
    (NEWID(), 'Lester Holt', 'f'),
    (NEWID(), 'Fredricka Whitfield', 's'),
    (NEWID(), 'Bob Woodward', 't');
GO
```

## Authors
* **Egor Podvalkov** - *Initial work* - [My GitHub](https://github.com/EgorPodvalkov)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
