Feature: ApiPets

Scenario: Getting list of all available pets
	Given I prepare all 'available' Pets under '/pet/findByStatus' endpoint
	When I execute call
	Then I get response code "200"
	Then I get list of pets

Scenario: Add new pet
	Given I prepare 'POST' method under '/pet' endpoint
	When I add Request body with new pet
	Then I get response code "200"

Scenario: Update existing Pet
	Given I prepare 'PUT' method under '/pet' endpoint
	When I add Request body to update pet status
	Then I get response code "200"

Scenario: Remove Pet
	Given I prepare Delete endpoint to remove pet
	When I execute call
	Then I get response code "200"