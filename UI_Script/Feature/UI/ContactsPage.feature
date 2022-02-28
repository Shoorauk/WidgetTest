Feature: ContactsPage

Scenario: Generate new email
Given Navigate to yopmail site
When Enter random email address 
Then Email should be generated

Scenario: Fill the form 
Given I am form page
When Enter all mandatory details
And Click on submit button
Then Form submit successfully

