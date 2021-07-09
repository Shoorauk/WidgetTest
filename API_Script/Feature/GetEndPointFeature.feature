Feature: GetEndPointFeature
	

@mytag
Scenario: Verify the demo api data
Given Get ready all the data
When execute the get api
| GetUrl                                            |
| https://www.cheapoair.com/profiles/api/v1/loyalty |
Then Verify the activation point
| Points |
| 500    |
And 200 status code 
