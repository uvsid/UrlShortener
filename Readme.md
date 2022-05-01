**URL Shortener**

Ujas Sidapara
Version: Pre-Release


Environment: 
- ASP.Net Core (.Net 6)
- CrossPlatform (Kestrel)
- DB - MongoDB
- Deployment -> Docker (Linux containers)
Source code is provided as a Visual Studio 2022 solution. 


Depends on: 
    - docker  (ready to go, but upto you really)
	- mongodb (but running the docker-compose will make a mongo container for you :) )
    
    

Usage:
 ```
 To run (on Windows): 
		Set the mongo db path in /publish/ appsettings.json
		Run "UrlShortener.Service.exe"
		
 To run service only in its own docker container:
		Use the dockerfile in the root of this folder structure. 

 To run everything (and make mongodb on the fly)
		Use the docker-compose in the root of this folder structure
 
 To build/ run: 
	 Use VS 2022 if you can. 
	 Otherwise, using the docker-compile.yml file from within the root of the VS sln directory,
	 will copy all your source files to a dockerise build env, compile all code, then run the service, along with a mongodb instance and mongo-express of debugging. 

    default endpoints are:
         localhost->27017 (mongodb instance)
         localhost->8081 (mongo-express for inspecting the state of the db) **DO NOT USE IN PRODUCTION**
         localhost->443 (ASP.Net Kestrel server)
    

    usage: send a post to shorten to get a token back
 ```


Work Items: 

- Define overall architecture

- ASP.NET Controller
      -   Create Dummy Project
      -   Implement Docker Build
      -   Implement MongoDb adapter
      -   Implement Controller

 - FrontEnd for Testing


UserFlow: 

 HappyPath :)


   -  User requests URI using key (https://tinyurl.com/{key})
       - > key exists in DB
        - > Controller returns URI from DB
    
    - > User wants to make a new shortened URI
        - HTTP POST to https://tinyurl.com/shorten 
        ~Return the key back.~
        Redirect straight from the controller
  
Failure Modes:
   - Invalid Request structure
      - Key not in DB
      -  ~User Not Authorised~

    **Circular Redirects!**






Design Brainstorming:

    

    DB -> good oppurtunity to look into NoSQL dbs, 
        but a SQL Server or SQLite will do just fine (or even having FileSystem based storage of)
        -> lets go for MongoDB
    
    
    Generate Key using either pseudo-random value or hash function. 
        -> lets go for random number because hash has too many got-yas (brithday paradox?)
		
	Swagger