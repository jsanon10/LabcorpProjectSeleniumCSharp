Feature: Careerss page feature

A short summary of the feature

Scenario: Search and select Careers
	Given user navigates to the the URL
	And user clicks on the Careers link
	When user searches for position "Senior Java Engineer - Lead"
	And user finds the searched position and retreives its details
	And user clicks on the serached position from the list of results
	Then Confirm that position's details from the list of results matches the details on its page
	And Confirm that the first sentence in the second intro paragraph is "The prospective candidate will be engaged in a wide variety of work, including but not limited to web applications and web service development, platform development, automation, and coaching/mentoring of teams adopting the platforms."
	And Confirm that the second bullet point under header "Responsibilities:" is "Document and present architectural decisions to the team, peers and management. Provides architectural guidance to the development team."
	And Confirm that the first Benefit offered to the applicant is "Medical"
	#And Start applying for the job and verify the position details
	#And Navigate back to the job search