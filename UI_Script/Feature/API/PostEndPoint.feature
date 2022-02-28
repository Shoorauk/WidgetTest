Feature: PostEndPoint
	Simple calculator for adding two numbers

Scenario: Verify the Post Demo Endpoint
Given Get ready all the data
When Execute the post API
| PostURL                                            |
| https://www.cheapoair.com/profiles/api/v1/CoTraveler |
Then Status should be 200
