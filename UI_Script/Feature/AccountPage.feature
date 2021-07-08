Feature: AccountPage
User wwill create account 

Scenario: Add Account successfully


Given Navigate to CRM account page
| userid                      | password   |
| vishal.malik-rbkw@force.com | vishal@123 |
When Create a account with correct field label and name
| FieldLabel | FieldName |
| Test       | New_Test  |
And Click on save Button
Then Account customer field should be created