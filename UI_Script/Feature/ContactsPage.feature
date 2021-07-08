Feature: ContactsPage

Scenario: Add the contracts
Given Navigate to CRM account page
| userid                      | password   |
| vishal.malik-rbkw@force.com | vishal@123 |
When Create a contracts with correct field label and name
| FieldLabel | FieldName |
| Test       | New_Test  |
And Click on contracts save Button
Then contracts customer field should be created