Feature: Careerss page feature

A short summary of the feature

Scenario: Search and select Careers
	Given user navigates to the the URL
	And user clicks on the Careers link
	When user searches for position "Test Automation Engineer"
	And user finds the searched position and retreives its details
	And user clicks on the serached position from the list of results
	Then Confirm that position's details from the list of results matches the details on its page 
	And Confirm that the first sentence in the second intro paragraph is "We are seeking a Test Automation Engineer/Jr. Software Developer to support automation efforts for it LIMS applications"
	And Confirm that the first suggestion for Automation Tools is "Selenium"

