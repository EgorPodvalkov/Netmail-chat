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

## Authors
* **Egor Podvalkov** - *Initial work* - [My GitHub](https://github.com/EgorPodvalkov)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
