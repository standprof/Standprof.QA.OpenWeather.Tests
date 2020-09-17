# Template: API Tests solution
The C# solution can be used as a template for new similar projects, when we need to automate API testing.

## Installation
- Install the latest version of MS Visual Studio (now -  2019)
- Add extension "SpecFlow for Visual Studio"
- Rename the solution file to match the product name  
- Open the solution in Visual Studio
- Rename the project name to match the product name
- Build the solution - the missing nuget packages will be restored
- The build should succeed

## Structure of solution
- Feature: contains test scenarios
- Steps: contains test steps in C#
- Config: contains configuration files for each test environment, e.g. base URLs for API endpoints
- Data: contains files related to structure of API requests/responses
- Helpers: contains helpers methods





