	Feature: AccountPage
User wwill create account 

Scenario: Add Account successfully


Given Navigate to CRM account page
When Sign-in a account with correct field label and name
| userid                      | password   |
| qavishal25@gmail.com        | dmlzaGFsMjU= |
And Click on save Button
Then Sign-in successfully

Scenario Outline: Sign-in functionality with different domain
Given Navigate to CRM account page
When Enter <Email> and <Password>
And Click on save Button
Then Sign-in different credentials successfully <Validationtext>
Examples: 
| Email                     | Password | Validationtext |
| aryamalik2112@outlook.com | dmlzaGFsMjU= | Arya    |
| qavishal25@gmail.com | dmlzaGFsMjU= | Oscar1    |



