Feature: ChromeExtInstallation
	As a user
	I Want to Install Extensions in Chrome Browser
	So that I Can Use it

@mytag
Scenario: Verify Extension is downloaded
	Given I have signed in as user with credentials "bestbugtest@gmail.com" and "testbugbest"
	And I have installed "adblock" extension
	When I navigate to extensions page
	Then I should see Chrome Extension installed with Id "gighmmpiobklfepjocnamgkkbiglidom"
