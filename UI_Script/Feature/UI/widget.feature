Feature: widget
	Verfy the different test scenarios on widget 

Scenario: Verify that a valid journey can be planned using the widget
Given Navigate to plan journey widget
When Enter  the from and to location 
| fromLocation                          | toLocation               |
| Birmingham International Rail Station | Camden Road Rail Station |
And Click on plan my journey button
Then Navigate to journey result page
And From and to location should be same same as enter in plan journey page
| from                          | to               |
| Birmingham International Rail Station | Camden Road Rail Station |


Scenario: Verify that the widget is unable to provide results when an invalid journey is
planned
Given Navigate to plan journey widget
When Enter  the from and to location for test 
| fromLocation                          | toLocation               |
| Test | Test |
And Click on plan my journey button
Then Navigate to journey result page
And Validation message should be displayed "We found more than one location matching 'Test'"

Scenario: Verify that the widget is unable to plan a journey if no locations are entered into the
widget
Given Navigate to plan journey widget
When Click on plan my journey button
Then Validation message should be displayed 
| From                        | To                        |
| The From field is required. | The To field is required. |

Scenario: Verify change time link on the journey planner displays “Arriving” option and plan a
journey based on arrival time
Given Navigate to plan journey widget
When Enter  the from and to location 
| fromLocation                          | toLocation               |
| Birmingham International Rail Station | Camden Road Rail Station |
And Change the arrival time
And Click on plan my journey button
Then Validation the arriving time journey result page

Scenario: On the Journey results page, verify that a journey can be amended by using the “Edit
Journey” button.
Given Navigate to plan journey widget
When Enter  the from and to location 
| fromLocation                          | toLocation               |
| Birmingham International Rail Station | Camden Road Rail Station |
And Click on plan my journey button
And Click on edit journey button
And switch the from and to location
And Click on update journey button
Then Validate the switch from and to location
| from                     | to               |
| Camden Road Rail Station | Birmingham International Rail Station |

Scenario: Verify that the “Recents” tab on the widget displays a list of recently planned
journeys
Given Navigate to plan journey widget
When Enter  the from and to location 
| fromLocation                          | toLocation               |
| Birmingham International Rail Station | Camden Road Rail Station |
And Click on plan my journey button
And Click on journey plan and click on recent button
Then Recent search should be displayed