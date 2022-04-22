# Bonus Supplemental Part Script

> Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

> Hi, friends! I'm Cam Soper, a content developer working with .NET at Microsoft. I wanted to take a few minutes to show you my recommendations on how to get the most from this video series.

Before you get started, you should obtain the code, sample data, and notes for this series. They're located on GitHub at the location shown here.

In the videos, I primarily use Visual Studio. This is a great option if you're a Windows user. If you're using Visual Studio, make sure you have the ASP.NET and web development workload installed.

If you're developing on Windows, you'll also need to install a pre-existing database to your SQL Server Express LocalDB instance. A DACPAC file is located in the .devcontainer folder in the data subfolder. Use a tool like Azure Data Studio or SQL Server Management Studio to restore the database and name it ContosoPizza.

For each part, open the Project file for the part you're in directly in Visual Studio.

If you're on a non-Windows environment or you just prefer a different IDE, you can use the .NET CLI and your IDE of choice. I recommend Visual Studio Code. 

I used the CodeTours extension in VS Code to make tours that walk you through the code interactively. If you have the CodeTour extension installed, you can launch the CodeTour for each video part by `<step by step>`.

My favorite way to experience these videos is with a dev container. If you have a container environment configured, you can load the repository folder using Visual Studio Code's Remote Developement - Containers extension. Visual Studio Code will build a container environment pre-configured with specific versions of the .NET SDK and SQL Server, as well the pre-existing databases. You don't even need to install any extensions. There's nothing for you to do except launch the Code Tour.

Finally, if your organization has access to GitHub Codespaces, you can launch the dev container in the cloud without any local tools. Just navigate to the code repository, click the `<tbd>` button, and create a new Codespace using the `main` branch.

Thank you for watching these videos. I hope you find them informative, and I hope you have as much fun learning from them as I did making them.
