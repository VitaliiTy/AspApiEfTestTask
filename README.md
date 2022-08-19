# AspApiEfTestTask
Test task using Asp .Net core web, Api and entity framework

## Project setup
In order to create local database run migration via Package manager console
```
Update-Database
```  
## Project using
### You can create accounts, contacts and incidents in DB using Api

Use /Account with params name and contactEmail to create account

Use /Contact with params firstname, lastname and email to create contact

Use /Incident with params accountName, firstname, lastname and description to create incident

### It's imposible to create account without contact and incident without account
