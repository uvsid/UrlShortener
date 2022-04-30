**URL Shortener**

Ujas Sidapara
Version: Pre-Release


Environment: 
- ASP.Net Core (.Net 6)
- CrossPlatform (Kestrel)
- DB - MongoDB
- Deployment -> Docker
Source code is provided as a Visual Studio 2022 solution. 


Depends on: 
    - first
    - second
    - third
    

Usage:
 ```language
 
 ```


Work Items: 

- Define overall architecture

- ASP.NET Controller
      -   Create Dummy Project
      -   Implement Docker Build
 - FrontEnd for Testing

 - Define API


UserFlow: 

 HappyPath :)


   -  User requests URI using key (https://tinyurl.com/{key})
       - > key exists in DB
        - > Controller returns URI from DB
    
    - > User wants to make a new shortened URI
        - HTTP POST to https://tinyurl.com/shorten 
        - Return the key back.
  
Failure Modes:
   - Invalid Request structure
      - Key not in DB
      -  ~User Not Authorised~






Design Brainstorming:

    

    DB -> good oppurtunity to look into NoSQL dbs, 
        but a SQL Server or SQLite will do just fine (or even having FileSystem based storage of)
        -> lets go for MongoDB
    
    
    Generate Key using either pseudo-random value or hash function. 
        -> lets go for random number because hash has too many got-yas (brithday paradox?)