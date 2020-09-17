Feature: Open Weather

@test_OW-1
Scenario Outline: Get current weather for city
	Given I have a city '<city>'
	When I request the current weather for the city
	Then the response status code should be "200"
	And the Current Weather response should contain the city name
Examples: 
| city   |
| London |
| Paris  |
