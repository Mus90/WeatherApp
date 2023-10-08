# WeatherApp

Weather Report Generator
This simple C# console application allows you to generate a PDF weather report for a specific city by providing the city name as input. 
The application utilizes a weather API to fetch weather data and then creates a PDF report with the weather information.

# Prerequisites
Before running this application, ensure that you have the following installed on your system:
* .NET Core SDK
* Git

# Usage
When you run the application, it will prompt you to enter the city name for which you want to generate a weather report.
1- Enter the city name and press Enter.
2- The application will download weather information for the specified city.
3- It will then generate a PDF report with the following weather details:
* City Name
* Observation Time
* Temperature
* Weather Code
* Pressure
* Humidity
The PDF report will be saved in the project folder as "Weather Report.pdf."

# Example
Here's a simple example of running the application:

Please enter city name:
New York
Downloading New York weather info ...
Generating Report ...
PDF created successfully at Weather Report.pdf
