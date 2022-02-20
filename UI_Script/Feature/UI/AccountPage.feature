	Feature: AccountPage
User wwill create account 

Scenario: Add Account successfully


Given Navigate to CRM account page

When Sign-in a account with correct field label and name
| userid                      | password   |
| qavishal25@gmail.com        | vishal25 |
And Click on save Button
Then Sign-in successfully