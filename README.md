dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef

Criar migrations no banco
dotnet ef migrations add InitialCreate

depois 
dotnet ef database update
<!--  trocar para false -- <InvariantGlobalization>false</InvariantGlobalization> -->

alterar id arquivo customer para customerId
remover  email
add  city e state

criar duas classes 
ProductCategory
   atributos
     - ProductCategoryId : int *
     - name : string *

Product
  atributos
    - ProductId : int *
    - ProductCategoryId : int *
    - name: string(50) * 
    - UnitPrice: decimal(11, 5) *