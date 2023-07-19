
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




