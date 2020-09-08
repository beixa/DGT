## DGT - prueba técnica

He creado una API en .NET Core 3.1 utilizando Entity Framework Core 3.1.7.

Para poder ejecutarlo ejecuta el siguiente commando en el directorio del proyecto:

`dotnet run`

Esto creará una base de datos de SQL Server en local basandose en la carpeta Migrations y ejecutará un servidor que atenderá a las siguientes llamadas:

# Conductores
## GET 
**http://localhost:5000/api/conductores** 

Recupera todos los conductores

## GET
**http://localhost:5000/api/conductores/{dni}**

Recupera los datos de un conductor por dni

## GET
**http://localhost:5000/api/conductores/top/{N}**

Recupera el top N de conductores

## POST
**http://localhost:5000/api/conductores** 

Crea un conductor pasandole un objeto de tipo Conductor

# Vehiculos

## GET 
**http://localhost:5000/api/vehiculos** 

Recupera todos los vehiculos

## GET
**http://localhost:5000/api/vehiculos/{matricula}**

Recupera un vehiculo por matricula

## POST
**http://localhost:5000/api/vehiculos** 

Crea un conductor pasandole un objeto de tipo Conductor

## POST
**http://localhost:5000/api/vehiculos/{matricula}/{infraccionId}**

Crea una sancion a un vehiculo pasando la matricula y el id de la infraccion

# Conductores Habituales

Tabla intermedia entre conductores y vehiculos

## GET 
**http://localhost:5000/api/habituales** 

Recupera todos los conductores habituales

## GET
**http://localhost:5000/api/habituales/{dni}**

Recupera conductores habituales por dni

## GET
**http://localhost:5000/api/habituales/{dni}/{matricula}**

Recupera conductores habituales por dni y matricula

## POST
**http://localhost:5000/api/habituales** 

Crea un conductor habitual pasandole un objeto de tipo ConductorVehiculo

# Infracciones

## GET
**http://localhost:5000/api/infracciones** 

Recupera todas las infracciones

## GET
**http://localhost:5000/api/infracciones/{id}**

Recupera las infracciones por id

## POST
**http://localhost:5000/api/infracciones** 

Crea infracciones pasandole un objeto de tipo Infraccion

# Sanciones
Historico de las infracciones

## GET
**http://localhost:5000/api/sanciones** 

Recupera todas las sanciones

## GET
**http://localhost:5000/api/sanciones/{id}**

Recupera sancion por id

## GET
**http://localhost:5000/api/sanciones/habituales/{cnt}**

Recupera el numero de sanciones habituales que se le pase en cnt


