# JwtMicroServices


<ul style="font-size:1.2em;color:green;margin-top:2em;">
    <li style="padding-bottom:0.5em;">
     JWT Server run on port 5000, start this first.
    </li>
    <li style="padding-bottom:0.5em;">
     API1 is a Test API, on port 5001 api/values requires the user to be authenticated.
    </li>
    <li style="padding-bottom:0.5em;">
     Javascript client starts the index page, gets a token from JWT Server, test the values controller on API1.
    </li>
    <li style="padding-bottom:0.5em;">
     Console client, does the same as above without a GUI.
    </li>
    <li style="padding-bottom:0.5em;">
     The Extension project is class library project the startup config is here for all api, where the config can be shared.
    </li>
    <li style="padding-bottom:0.5em;">
     Test - Xunit test project.
    </li>
</ul>

