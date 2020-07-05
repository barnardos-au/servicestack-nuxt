# ServiceStack Nuxt.js

## Prerequisites
Install ServiceStack global x tool

```
dotnet tool install --global x
```

or update

```
dotnet tool update --global x
```

## Create Nuxt project

```
cd .\src
x new vue-nuxt ServiceStackNuxt
```

## AutoCRUD

```
cd .\ServiceStackNuxt
code .
```

Open Terminal in VS Code. Navigate to services folder and run `x mix` to generate northwind CRUD services.

```
cd .\ServiceStackNuxt
x mix autocrudgen sqlite northwind.sqlite
```

Edit `Configure.Db.cs` and change `:memory:` to `northwind.sqlite`.

Start ServiceStackNuxt

```
dotnet run
```

## Install ServiceStack Studio
Install ServiceStack global app tool

```
dotnet tool install --global app
```

or update

```
dotnet tool update --global app
```

Run ServiceStack Studio and connect to running service

```
app open studio -connect https://localhost:5001
```