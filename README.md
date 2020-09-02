# credit-approval Solution
API REST application which describes the credit approval process of a fictitious company based on customer ranks

# Environment Steps
The application needs to run the next 2 commands in Package Manager Console:

1.- Add-Migration DbInit

2.- Update-Database

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


