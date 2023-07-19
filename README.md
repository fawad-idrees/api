
# CRUD Operation By using .Net 6 WebAPI

This project is just a demo of how to implement and deploy the .net 6 WebAPI in  AWS elastic beanstalk, Alos we will deploy this application on Github.




## Tech Stack

**Client:** BuiltIn Swagger UI to test the API OR PostMAN.

**Server:** .NET 6 WEBAPI.

**DataBase:** SQL Server.

**AWS:** AWS toolkti for visual studio.




## Features

- JWT Implementation.
- Encrypted Connection String.
- CRUD Operation For Product.

## Deployment

First pull this repo from blow link https://github.com/fawad-idrees/api.git

TO deploy this project go to AWS and create the Elastic Beanstalk Or you can you Visual studio Elastic Beanstalk tool to deploy the application on AWS.

You can use https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/dotnet-core-tutorial.html#dotnet-core-tutorial-generate to generate the environment and deploy the code.


TO deploy from Visual studio you can click on explorer and click on "Publish to AWS elasticbeanstalk Lagacy".

- Add Credentials of your AWS user to access the AWS account
- Create the new Application Environment.
- Give Name to your Environment.
- Give URL to your Solutions that Client will Access.
- Choose default VPC.
- Click Finish.


- Also Add Launch Amazon RDS Instance form the AWS Explorer 
- chooose the SQL server EnterPrise Edition.
- Give a Name to instane.
- Give a UserName to instane.
- Give a Password to instane.







## API Reference

#### Get JWT TOKEN items

```http
  GET /api/Login
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `userName` | `string` | **Required**. use admin |
| `password` | `string` | **Required**. use 12345 |


#### Login(User)
Takes userName and password and returns token 

#### Get Product

```http
  GET /api/Product/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Id`      | `string` | **Required**. Id of item to fetch |
| `Token`      | `string` | **Required**. Token To get Authorized |

#### GetProductByID(Id)

Takes Product Id and returns the details if it is available.



```http
  GET /api/Product
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Token`      | `string` | **Required**. Token To get Authorized |

#### GetProducts()

Returns  All the Products.


```http
  GET /api/Product
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Token`      | `string` | **Required**. Token To get Authorized |
| `ID`      | `string` | **Required**. Not Required use 0 |
| `ProdName`      | `string` | **Required**. |
| `CategoryName`      | `string` | **Required**. |
| `Price`      | `string` | **Required**. |

#### AddProduct(product)

This will add the Product.



```http
  GET /api/Product
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Token`      | `string` | **Required**. Token To get Authorized |
| `ID`      | `string` | **Required**. Not Required use 0 |
| `ProdName`      | `string` | **Required**. |
| `CategoryName`      | `string` | **Required**. |
| `Price`      | `string` | **Required**. |

#### UpDateProduct(product)

This will Update the Product.



```http
  GET /api/Product
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Token`      | `string` | **Required**. Token To get Authorized |
| `id`      | `string` | **Required**.  |

#### DeleteProduct(id)

This will delete the Product.





## Demo

Below is the link of the application deployed on AWS.


http://crud-test.us-east-1.elasticbeanstalk.com/swagger/index.html

