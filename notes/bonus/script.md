# Bonus Supplemental Part Script

> Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

Hi, friends! I'm Cam Soper, a content developer working with .NET at Microsoft. I wanted to take a few minutes to show you my recommendations on how to get the most from this video series.

Before you get started, you should obtain the code, sample data, and notes for this series. They're located on GitHub at the location shown here.

In the videos, I primarily use Visual Studio. This is a great option if you're a Windows user. If you're using Visual Studio, make sure you have the <workload> workloads installed.

You'll also need to restore the pre-existing databases to your SQL Server Express LocalDB instance. You can use Visual Studio for this. Don't worry that there isn't a database marked "Part 1", you're going to create that yourself!

If you're on a non-Windows environment or you just prefer a different IDE, you can use the .NET CLI and your IDE of choice. I recommend Visual Studio Code. Use a tool like SQL Server Management Studio or Azure Database Explorer to restore the existing databases before you start.

I've created CodeTours to walk you through the code interactively in Visual Studio Code. When you open the repository, you will be prompted to install the recommended extensions. Once the extensions are installed, you can launch the CodeTour for each video part by `<step by step>`.

My favorite way to experience these videos is with a dev container. If you have a container environment configured, you can load the repository folder using Visual Studio Code's Remote Developement - Containers extension. Visual Studio Code will build a container environment pre-configured with specific versions of the .NET SDK and SQL Server, as well the pre-existing databases. There's nothing for you to do except launch the Code Tour.

Finally, if your organization has access to GitHub Codespaces, you can launch the dev container in the cloud without any local tools. Just navigate to the code repository, click the `<tbd>` button, and create a new Codespace using the `main` branch.

Thank you for watching these videos. I hope you find them informative, and I hope you have as much fun learning from them as I did making them.
