# CandidatesApplication.APIs
 >>> App DB_Diagram :

![DB_Diagram](https://github.com/user-attachments/assets/6d9a19b4-767d-4abe-96bf-b92946888237)


---- 
** Db Schema :

* Candidate table:
           Id ,           
           Name ,      
           Nickname ,                  
           Email ,                                              
           YearsOfExperience ,                                                           
           MaxNumSkills 
* Skill table : 
           Id ,                 
           Name    
* CandidateHasSkills table :                                                  
           Candidate_Id      --> FK to Candidates.Id  ,                   
           Skill_Id             --> FK to Skills.Id  ,                   
           GainedDate                        
    
----------------
+-- Setup
1. Clone Repository
2. Apply Migrations: in DAL
     Update-Database


+-- Deployment to IIS
- Publish API:
    dotnet publish -c Release -o ./publish


----------------------
 remaining features:

- frontend  side ( Angular) : [3 Hours]


