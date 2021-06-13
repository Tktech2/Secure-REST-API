## API endpoints details

Please use Postman for sending requests to the secure API in following order:
    
    1.  CreateUser - This is HTTPPOST request to create and register new user.
        a) Refer screenshot under folder ..\TestCases-Screenshots\SuccessRegister.png screenshot
        b) API URL: <localhost>/api/user/createuser
        c) HTTP Verb:      POST API request
        d) Input in JSON format to be provided as follows:

            {	
	            "FirstName": "John",
	            "LastName": "K",
	            "UserName": "JohnK",
	            "Email": "JohnK@gmail.com",
	            "Password" : "Abcd235#"
            }

        e) Prerequisites for registering / creating user:
            Email and Username should be unique
            Password should be strong


    2.  GenerateToken-    This is HTTPPOST request to generate secure JWT token for 
         newly created user.

        a) Refer screenshot under folder ..\TestCases-Screenshots\SuccessTokenGenerated.png screenshot
        b) API URL: <localhost>/api/user/generatetoken
        c) HTTP Verb:      POST API request
        d) Input in JSON format to be provided as follows:

            {
	            "Email": "JohnK@gmail.com",
	            "Password" : "Abcd235#"
            }

        e) Prerequisites for TOKEN Generation:
            Pass the same Email and password used in API #1 for creating user

        f) Copy generated token from Body of Postman for further requests below. See screenshot SuccessTokenGenerated.PNG in red circle

    3.  Create City and Country- This is a SECURE and AUTHORIZED HTTPPOST request to create City
        and Country for above user.

        a) Refer screenshot under folder ..\TestCases-Screenshots\SuccessCreateCityCountry.png
        b) API URL: <localhost>/api/user/CreateCity
        c) HTTP Verb: POST API request
        d) Input in JSON format to be provided as follows:

            {	
	            "Email": "JohnK@gmail.com",
                "City" : "Washington",
                "Country" :"USA",
                "Isfavourite" : true
            }
            This example creates a favourite city. Not mandatory to pass "Isfavourite" parameter . By default its
            value is set to False. So this input is also valid:
            
            {	
	            "Email": "JohnK@gmail.com",
                "City" : "Florida",
                "Country" :"USA" 
            }

        e) Prerequisites for TOKEN Generation:
            i) Copy and pass same token generated API #2 in SuccessTokenGenerated.png for above user. 
            Not doing so will return 401  Unauthorized access error. Refer UnauthorizedCreateCity.png 

            ii) Duplicate cities are not allowed. Response 'Conflict' will be returned if same city for same email created via 
            POST 
            
    4.  PUT- update City and Country. This is a SECURE and AUTHORIZED HTTPPOST request to UPDATE City and Country
         for above user's email.
                a) Refer screenshot under folder ..\TestCases-Screenshots\SuccessPUT-Update.png screenshot
                b) API URL: <localhost>/api/user/UpdateCity
                c) HTTP Verb:      PUT API request
                d) Input in JSON format to be provided as follows:

                    {	
	                    "Email": "JohnK@gmail.com",
                        "City" : "Washington",
                        "Country" :"CANADA",
                        "Isfavourite" : true
                    }
                    This example updates country for that user. See here, USA updated to CANADA  

                e) Prerequisites for TOKEN Generation:
                    i) Copy and pass same token generated API #2 in SuccessTokenGenerated.png for above user. 
                    Not doing so will return 401  Unauthorized access error. Refer UnauthorizedCreateCity.png 

    4.   GET Favorites- List of user's Favourite Cities. This is a SECURE and AUTHORIZED HTTPPOST request. 
            User's email is required in request URL.
        a) Refer screenshot under folder ..\TestCases-Screenshots\Success-FavouriteCities.png screenshot
        b) API URL: <localhost>/api/user/favoritecities?Email=JohnK@gmail.com
        c) HTTP Verb:      GET API request
     
        e) Prerequisites:
            i) Pass the User's email in input request querystring.
            ii) Copy and pass same token generated API #2 in SuccessTokenGenerated.png for above user. 
            Not doing so will return 401  Unauthorized access error. Refer UnauthorizedCreateCity.png 

    5.   GET- List of user's ALL Cities- This is a SECURE and AUTHORIZED HTTPPOST request. 
        User's email is required in request URL.
        a) Refer screenshot under folder ..\TestCases-Screenshots\Success-AllCities.png screenshot
        b) API URL: <localhost>/api/user/allcities?Email=JohnK@gmail.com
        c) HTTP Verb:     GET API request
     
        e) Prerequisites:
            i) Pass the User's email in input request querystring.
            ii) Copy and pass same token generated API #2 in SuccessTokenGenerated.png for above user. 
            Not doing so will return 401  Unauthorized access error. Refer UnauthorizedCreateCity.png