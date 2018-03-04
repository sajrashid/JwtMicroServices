# JwtMicroServices
JWT Server run on port 5000, start this first. </br>
API1 is the Test API it's on port 5001 api/values controller requires the user to be authenticated. </br>
Javascript client is index page running in webapi, gets a token from JWT Server port 5000, test the values controller on Test API port 5001. </br>
Console client, does the same as above without a GUI. </br>
The Extension project is class library project the startup config is here for all api, where the config can be shared. </br>
Test - Xunit test project
