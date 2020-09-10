## DGT - prueba técnica

He creado una API en .NET Core 3.1 utilizando Entity Framework Core 3.1.7.

Para poder ejecutarlo ejecuta el siguiente commando en el directorio del proyecto:

`dotnet run`

Esto creará una base de datos de SQL Server en local basandose en la carpeta Migrations y ejecutará un servidor que atenderá a las siguientes llamadas:

# Conductores

## GET
Recupera todos los conductores

**http://localhost:5000/api/conductores**

RESPONSE:

```
[
    {
        "dni": "12343932W",
        "nombre": "Fracisco",
        "apellidos": "Escobar",
        "puntos": 15,
        "vehiculos": []
    },
    {
        "dni": "12348765M",
        "nombre": "Ernesto",
        "apellidos": "Sevilla Suarez",
        "puntos": 7,
        "vehiculos": [
            {
                "matricula": "1234BBB",
                "marca": "Seat",
                "modelo": "Ibiza",
                "infraccion": null
            },
            {
                "matricula": "13PPY",
                "marca": "Fiat",
                "modelo": "Panda",
                "infraccion": null
            }
        ]
    }
]
```

## GET
Recupera los datos de un conductor por dni

**http://localhost:5000/api/conductores/{dni}**

RESPONSE:

```
[
    {
        "dni": "12348765M",
        "nombre": "Ernesto",
        "apellidos": "Sevilla Suarez",
        "puntos": 7,
        "vehiculos": [
            {
                "matricula": "1234BBB",
                "marca": "Seat",
                "modelo": "Ibiza",
                "infraccion": null
            },
            {
                "matricula": "13PPY",
                "marca": "Fiat",
                "modelo": "Panda",
                "infraccion": null
            }
        ]
    }
]
```

## GET
Recupera el top N de conductores

**http://localhost:5000/api/conductores/top/{N}**

RESPONSE:

```
[
    {
        "dni": "12343932W",
        "nombre": "Fracisco",
        "apellidos": "Escobar",
        "puntos": 15,
        "vehiculos": []
    },
    {
        "dni": "12348765M",
        "nombre": "Ernesto",
        "apellidos": "Sevilla Suarez",
        "puntos": 7,
        "vehiculos": [
            {
                "matricula": "1234BBB",
                "marca": "Seat",
                "modelo": "Ibiza",
                "infraccion": null
            },
            {
                "matricula": "13PPY",
                "marca": "Fiat",
                "modelo": "Panda",
                "infraccion": null
            }
        ]
    }
]
```

## POST
Crea un conductor pasandole un objeto de tipo Conductor

**http://localhost:5000/api/conductores**

REQUEST:

```
Body:
    {
    "dni": "12345678T",
    "nombre" : "Pedro",
    "apellidos" : "Rodriguez"
}
```

RESPONSE:

```
    {
    "dni": "12345678T",
    "nombre": "Pedro",
    "apellidos": "Rodriguez",
    "puntos": 15,
    "vehiculos": []
    }

```

# Vehiculos

## GET
Recupera todos los vehiculos

**http://localhost:5000/api/vehiculos**

RESPONSE:

```
[
    {
        "matricula": "1222PPY",
        "marca": "BMW",
        "modelo": "M3",
        "conductores": [],
        "infraccion": null
    },
    {
        "matricula": "1222WXY",
        "marca": "BMW",
        "modelo": "M3",
        "conductores": [],
        "infraccion": null
    }
]
```

## GET
Recupera un vehiculo por matricula

**http://localhost:5000/api/vehiculos/{matricula}**

RESPONSE:

```
    {
        "matricula": "1222PPY",
        "marca": "BMW",
        "modelo": "M3",
        "conductores": [],
        "infraccion": null
    }

```

## POST
Crea un conductor pasandole un objeto de tipo Conductor

**http://localhost:5000/api/vehiculos**

REQUEST:
```
Body:
    {
    "matricula": "1234BCD",
    "marca": "Fiat",
    "modelo": "Panda"
}
```

RESPONSE:

```{
    "matricula": "1234BCD",
    "marca": "Fiat",
    "modelo": "Panda",
    "conductores": [],
    "infraccion": null
}
```

## POST
Crea una sancion a un vehiculo pasando la matricula y el id de la infraccion

**http://localhost:5000/api/vehiculos/{matricula}/{infraccionId}**

RESPONSE:
```
{
    "matricula": "1234BCD",
    "marca": "Fiat",
    "modelo": "Panda",
    "conductores": [
        {
            "dni": "12345678T",
            "nombre": "Pedro",
            "apellidos": "Rodriguez",
            "puntos": 10
        }
    ],
    "infraccion": {
        "id": 1,
        "descripcion": "Uso telefono móvil",
        "descuentoPuntos": 5
    }
}
```

# Conductores Habituales

Tabla intermedia entre conductores y vehiculos

## GET
Recupera todos los conductores habituales

**http://localhost:5000/api/habituales**

RESPONSE
```
 [
    {
        "dni": "12345678T",
        "matricula": "1234BCD"
    },
    {
        "dni": "12348765M",
        "matricula": "1234BBB"
    },
    {
        "dni": "12348765M",
        "matricula": "13PPY"
    }
 ]
 ```

## GET
Recupera conductores habituales por dni

**http://localhost:5000/api/habituales/{dni}**

RESPONSE
```
[
    {
        "dni": "12345678T",
        "matricula": "1234BCD"
    }
]

```

## GET
Recupera conductores habituales por dni y matricula

**http://localhost:5000/api/habituales/{dni}/{matricula}**

RESPONSE
```
    {
        "dni": "12345678T",
        "matricula": "1234BCD"
    }

```

## POST
Crea un conductor habitual pasandole un objeto de tipo ConductorVehiculo

**http://localhost:5000/api/habituales**

REQUEST:
```
Body:
    {
        "dni": "12345678T",
        "matricula": "1234BCD"
}
```

RESPONSE:
```
{
    "dni": "12345678T",
    "matricula": "1234BCD"
}
```

# Infracciones

## GET
Recupera todas las infracciones

**http://localhost:5000/api/infracciones**

RESPONSE:
```
[
    {
        "id": 1,
        "descripcion": "Uso telefono móvil",
        "descuentoPuntos": 5
    },
    {
        "id": 2,
        "descripcion": "Sin cinturón",
        "descuentoPuntos": 2
    },
    {
        "id": 3,
        "descripcion": "Conducir bajo los efectos del alcohol",
        "descuentoPuntos": 8
    }
]
```

## GET
Recupera las infracciones por id

**http://localhost:5000/api/infracciones/{id}**

RESPONSE:
```
    {
        "id": 1,
        "descripcion": "Uso telefono móvil",
        "descuentoPuntos": 5
    }
```

## POST
Crea infracciones pasandole un objeto de tipo Infraccion

**http://localhost:5000/api/infracciones**

REQUEST:
```
Body:
{
    "descripcion": "Conducción temeraria",
    "descuentoPuntos": 11
}
```

RESPONSE:
```
{
    "id": 7,
    "descripcion": "Conducción temeraria",
    "descuentoPuntos": 11
}
```

# Sanciones

Historico de las infracciones

## GET
Recupera todas las sanciones

**http://localhost:5000/api/sanciones**

RESPONSE:
```
[
    {
        "id": 1,
        "fecha": "2020-09-09T10:47:04.6143458",
        "conductor": {
            "dni": "12345678A",
            "nombre": "Manolo",
            "apellidos": "García Fernandez",
            "puntos": -1
        },
        "vehiculo": {
            "matricula": "8765KKK",
            "marca": "Lamborghini",
            "modelo": "Huracán",
            "infraccion": {
                "id": 3,
                "descripcion": "Conducir bajo los efectos del alcohol",
                "descuentoPuntos": 8
            }
        }
    },
    {
        "id": 2,
        "fecha": "2020-09-09T10:51:02.8591812",
        "conductor": {
            "dni": "12345678A",
            "nombre": "Manolo",
            "apellidos": "García Fernandez",
            "puntos": -1
        },
        "vehiculo": {
            "matricula": "8765KKK",
            "marca": "Lamborghini",
            "modelo": "Huracán",
            "infraccion": {
                "id": 3,
                "descripcion": "Conducir bajo los efectos del alcohol",
                "descuentoPuntos": 8
            }
        }
    }
]
```

## GET
Recupera sancion por id

**http://localhost:5000/api/sanciones/{id}**

RESPONSE:
```
{
        "id": 1,
        "fecha": "2020-09-09T10:47:04.6143458",
        "conductor": {
            "dni": "12345678A",
            "nombre": "Manolo",
            "apellidos": "García Fernandez",
            "puntos": -1
        },
        "vehiculo": {
            "matricula": "8765KKK",
            "marca": "Lamborghini",
            "modelo": "Huracán",
            "infraccion": {
                "id": 3,
                "descripcion": "Conducir bajo los efectos del alcohol",
                "descuentoPuntos": 8
            }
        }
    }
```

## GET
Recupera el numero de sanciones habituales que se le pase en cnt

**http://localhost:5000/api/sanciones/habituales/{cnt}**

RESPONSE: 
```
[
    "Conducir bajo los efectos del alcohol",
    "test"
]
```
