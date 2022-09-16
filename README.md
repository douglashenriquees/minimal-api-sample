## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new web -o solution_name.template_project --no-https true```
* ```dotnet sln solution_name.sln add ./solution_name.template_project/solution_name.template_project.csproj```
* ```dotnet new gitignore```
* ```cd MinimalApiSample```
* ```dotnet add package Swashbuckle.AspNetCore```
* ```dotnet add package Swashbuckle.AspNetCore.Annotations```

## Executando o Projeto

* ```dotnet run --project solution_name.template_project```