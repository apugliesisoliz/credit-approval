# credit-approval Solution
API REST application which describes the credit approval process of a fictitious company based on customer ranks

# Environment Steps
For this particular application we need to create the following user:

User: root

ässword: root

The application needs to run the next 2 commands in Package Manager Console:

1.- Add-Migration DbInit

2.- Update-Database

if you want a BD with data, please excecute the scripts in the route "Mysql/*"

# Documentation

Get a specific user

/api/user/get/[{UserId}

Get all Users

/api/user/get

Create a User

/api/user/create

Example

{
    "UserId": "apugliesi4",
    "Password": "a123456*",
    "CanModCredit": true,
    "MaxAmountAuthCredit": 50000
}

Modify a User

/api/user/update/{UserId}

{
    "Password": "a123456*",
    "CanModCredit": true,
    "MaxAmountAuthCredit": 60000
}

Delete a User

/user/delete/{UserId}

create a cliente 

/api/client/create

{
    "Name": "Alejandro",
    "LastName": "Soliz",
    "Adress": "Bolivia",
    "Calification": "buena"
}

Get all clients

/api/client/get

Update a Client

/api/client/update/{ClientId}

{
    "Name": "Alejandro",
    "LastName": "Pugliesi Soliz",
    "Adress": "Bolivia",
    "Calification": "Muy Buena"
}

create a credit

/api/credit/create

{
    "Description": "Credito Vivienda",
    "Amount": 50000,
    "AiIndicator": 6,
    "ClientId":1
}

Get all credits

/api/credit/get

get a specific credit 

/api/client/get/{CreditId}

Modicy a credit

/api/credit/update/{CreditId}

{
    "Description": "Credito Vivienda",
    "Amount": 70000,
    "AiIndicator": 8
}

Delete a credit 

/api/credit/delete/{CreditId}

Approve a Credit 

/api/credit/approve/{CreditId}

{
    "UserAuth": "apugliesi1"
}

Refuse a Credit 

/api/credit/refuse/{CreditId}

{
    "UserAuth": "apugliesi1"
}

Gets credits for auth state

/api/client/getByAuthState/{AuthState} // 0 is created - waiting for response, 1 is approved, 2 is refused






