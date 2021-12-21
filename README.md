# Sodexo .NET Bootcamp First Homework

### Details
- Deadline: 24 Dec, 23:00
- Steps to follow:
    
    - Creating a new .NET Core WEB API project.
    - Every content about the project should be named like "NameSurname_Homework1_ProjectName".
    - Creating a controller named 'BookController'.
    - Creating a Book class by adding 5 properties such as Id, BookSerialNumber, BookName, Author etc.
    - Creating a list and adding 6 records randomly.
    - List all records with HttpPost request.
    - Using FromRoute and FromQuery with HttpGet to show details of id entered with 2 different url.
    - Adding a new record into list using HttpPost with FromBody.
    - Update existing record with HttpPut.
    - Delete a record from list with HttpDelete.
    - You can code the areas that are not specified in the methods however you want.


### Actions

##### POST - List all book records

<pre>https://localhost:44306/api/Books/GetAll</pre>

##### GET - Get a book record by id from route

<pre>https://localhost:44306/api/Books/<strong>{id}</strong></pre>

##### GET - Get a book record by id from query

<pre>https://localhost:44306/api/Books<strong>?id={id}</strong></pre>

##### POST - Create a new book record

<pre>https://localhost:44306/api/Books

<b>Request Body:</b>

{
  "id": {id},
  "name": {bookName},
  "author": {author},
  "serialNumber": {serialNumber},
  "price": {price}
}
</pre>

##### PUT - Update a book record

<pre>https://localhost:44306/api/Books

<b>Request Body:</b>

{
  "id": {id},
  "name": {bookName},
  "author": {author},
  "serialNumber": {serialNumber},
  "price": {price}
}
</pre>

##### DEL - Delete a book record

<pre>https://localhost:44306/api/Books/<strong>{id}</strong></pre>
