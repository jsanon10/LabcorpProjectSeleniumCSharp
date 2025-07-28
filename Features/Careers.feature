Feature: Careerss page feature

A short summary of the feature

Scenario: Search and select Careers
	Given user navigates to the the URL
	And user clicks on the Careers link
	When user searches for position "Analyst"
	And user finds the searched position and retreives its details
	And user clicks on the serached position from the list of results
	Then Confirm that position's details from the list of results matches the details on its page 
	And Confirm that the first sentence in the third paragraph is "Ideal candidates will also be versed in the operations of various LIMS systems (Nautilus, Watson, IDBS eWorkbook), however, this is not required and training will be provided based on other skills and experience."
	And Confirm that the second bullet point under header "Other duties include:" is "- Use laboratory equipment appropriate for assigned tasks."
	#And Confirm that the first suggestion for Automation Tools is "Selenium"
	And Start applying for the job and verify the position details
	And Navigate back to the job search