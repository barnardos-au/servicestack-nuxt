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
code .
```

Open Terminal in VS Code. Navigate to services folder and run `x mix` to generate northwind CRUD services.

```
cd .\ServiceStackNuxt\ServiceStackNuxt
x mix autocrudgen sqlite northwind.sqlite
```

Edit `Configure.Db.cs` and change `:InMemory:` to `northwind.sqlite`.