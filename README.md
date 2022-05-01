# TFLJourneyPlannerautomationchallenge


please refer to the [TFLJourney Planner automationchallenge repository](https://github.com/phaneendhra2980/TFLJourneyPlannerautomationchallenge).

## Important parts

### Project Setup
Main Important NuGet packages to this Project are:

Selenium.Support - Main package for Selenium
Selenium.WebDriver - Package uses for highly flexible, allowing many options for locating and manipulating elements within a browser
Selenium.WebDriver.ChromeDriver - Package that contains the ChromeDriver so Selenium is able to control the Chrome browser
SpecFlow - To Automate and devlop Behaviour Driven Development Scenarios
SpecFlow.Plus.LivingDocPlugin - A plugin for SpecFlow to generate a shareable HTML Gherkin feature execution report (living documentation).
NUnit - NUnit features a fluent assert syntax, parameterized, generic and theory tests and is user-extensible.

### Default.srprofile

### Drivers
This driver provides you access to Selenium WebDriver. It intializes chromedriver from Binaries folder and used latest Chrome Driver Version 101.0.4951.4100
To get access to the latest Chrome Web Driver (https://chromedriver.chromium.org/downloads) , or Navigate --> Manage Nuget Package Manager.


### Hooks

Hooks (event bindings) can be used to perform additional automation logic at specific times, such as any setup required prior to executing a scenario. In order to use hooks, you need to add the Binding attribute to your class:
Logging Hooks contains Attachment(_specFlowOutputHelper.AddAttachment) Capturing after everystep and also has log statetment (_specFlowOutputHelper.WriteLine)

### Binaries
It Contains Chrome driver file

### Page Objects
It Conatins Page Object Model Pattern we are not adding our UI automation directly in bindings.
Using the Selenium WebDriver we simulate a user interacting with the webpage. The element IDs on the page are used to identify the fields we want to enter data into

### Reports
To Generate LivingDoc.html using LivingDoc.CLI
Command to Generate LivingDoc.html from SpecFlow test assembly
livingdoc test-assembly {ProjectPath}\bin\Debug\netcoreapp3.1\JourneyPlanner.dll -t {ProjectPath}\bin\Debug\netcoreapp3.1\TestExecution.json --title {Title to be displayed in LivingDoc}

for e.g
livingdoc test-assembly C:\Work\MyProject.Specs\bin\Debug\netcoreapp3.1\MyProject.Specs.dll -t C:\Work\MyProject.Specs\bin\debug\netcoreapp3.1\TestExecution.json

Please refer below links for more Info
(https://docs.specflow.org/projects/specflow-livingdoc/en/latest/Viewing/viewing-livingdoc-standalone.html)
(https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Using-the-command-line-tool.html)

### Steps
It Contains different Step Definitions files for various Features

The step definitions provide the connection between your feature files and application interfaces. You have to add the [Binding] attribute to the class where your step definitions are:

> Note: Bindings (step definitions, hooks) are global for the entire SpecFlow project.

### ValidJourney.feature
Here are the scenarios defined.  
To get a scenario executed for a Test case Number, add a tag _{TCNumber}_\_**__{Scenario}__** to the scenario/scenario outline/feature.  

**Example for a scenario for all 3 browsers:**
```

Feature: Valid Journey Planner
         As a traveller
	     I want to travel by searching by simple locations
	     So that I can easily commute to specified locations.

Background:
	Given I have entered locations
		| From Location                        | To Location |
		| Hounslow Central Underground Station | Wembley     |
	When I press Plan my Journey

@TC1_validjourney
Scenario: Valid Journey Planned
	Then I should see valid Journey results and a valid journey can be planned
```
