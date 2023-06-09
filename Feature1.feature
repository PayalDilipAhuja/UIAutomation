Feature: UI Automation of Save The Children international Site

A short summary of the feature

@tag1
Scenario: [On Save The Children International Site search for How to Donate]
	Given User is at Home Page
	When I Click on Go To UK Site Button
	Then User should be on Search Page
	When I click on Search Button
	Then Searchtexbox should be enabled and User is able to write search text and Submit

	@tag2
Scenario: [Click first link of search results and verify itt redirect to donation page]
	Given User gets Search results
	When click on the first link of search results 
	Then User lands on Payment page and verfies it
