var request = require('request');

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
