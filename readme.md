# Four Walls Public API

A public OAuth2 secured JSON API is available for certain limited functions.

You'll need an account with ```AgencyAdmin``` level access and be set up with a ```System Client```. Please contact your Four Walls representative for this access. 

## Overview
Perform an initial POST request to ```/api/v1/token``` get a response containing an access token.

Subsequent API requests should pass in the access token as a Bearer token in the header. eg:
```
Accept: application/json
Content-Type: application/json
Authorization: Bearer {{access_token}}
```

### API Endpoints

```POST /api/v1/token```
Perform a login and retrieve and access token.

Perform a form POST request with the following values
```
'username': '{{your email adddress}}',
'password': '{{your password}}',
'grant_type': 'password',
'client_id': '{{your system client id}}',
'client_secret': '{{your system client secret}}' 
```
A successful login response 
```
{
  "access_token": "long access token string here",
  "token_type": "bearer",
  "expires_in": 1799,
  "refresh_token": "refresh token here",
  "as:client_id": "{{your client id}}",
  "email": "{{your email adddress}}",
  "roles": "Agency",
  ".issued": "Thu, 12 May 2016 04:30:44 GMT",
  ".expires": "Thu, 12 May 2016 05:00:44 GMT"
}
```



```GET /api/v1/agency/listings/agency```

Returns list of Properties/Listings within your Agency.

A valid bearer access_token must be passed in the header.

GET Parameters:
```
PageSize=<int> // defaults to 100
CurrentPage=<int> // defaults to 1. Paging starts at 1
ListingStatus[]=<ListingStatus> // optional filter. 
ModifiedUtcIsoDateTimeFrom=<ISOUTCDateTime> // optional filter.

```
ListingStatus options
```
{
    Appraisal = 0,
    PendingListing = 1, 
    LiveListing = 2,
    Sold = 3,
    OnHold = 4, 
    Withdrawn = 5, 
    AppraisalFailed = 6 
}
```
Example GET requests

Return only Properties/Listings with a ```ListingStatus``` of ```Appraisal```, ```Sold``` or ```PendingListing```
```
/api/v1/agency/listings/agency?ListingStatus[]=Appraisal&ListingStatus[]=Sold&ListingStatus[]=PendingListing
```

Return a max of 50 properties after a given date
```
/api/v1/agency/listings/agency?ModifiedUtcIsoDateTimeFrom=2016-11-15T00:00:00Z&PageSize=500
```


### NodeJS example
This example uses the npm package [request](https://github.com/request/request) to perform a login, retrieve a token and get a list of Properties in an Agency.

```
var request = require('request');

// retrieve a token using your credentials
var getToken = function() {
    request.post(
        'http://localhost:47913/api/v1/token', 
        { 
            form: { 
                'username': '{{your email adddress}}',
                'password': '{{your password}}',
                'grant_type': 'password',
                'client_id': '{{your client id}}',
                'client_secret': '{{your client secret}}' 
            }
        },
        function(error, response, body) {
            var jsonBody = JSON.parse(body);
            getListings(jsonBody);
        }        
    );    
};

// retrieve properties/listings 
var getListings = function(responseToken) {
    //console.log(responseToken.access_token);
    request.get(
        {
           url: 'http://localhost:47913/api/v1/agency/listings/agency',
           headers:  {
               'Accept': 'appliation/json',
               'Content-Type': 'application/json',
               'Authorization': 'Bearer ' + responseToken.access_token
           } 
        },  
        function(error, response, body){
            console.log(body)  
        }
    );
};


getToken();
```



