Feature: Sample functional tests

@mytag
Scenario: Create account and log in
	Given I open test page

	When I click login button
	Then I see CreateAccount section
	
	When I enter "gwahshsyriar@mitakian.com" into email address input
	And I Click on Create Account button
	Then I am redirected to create account form

	When I fill create account form with data as "komar"
	Then I see form is filled

	When I click Register
	Then I see user is registered "komar"