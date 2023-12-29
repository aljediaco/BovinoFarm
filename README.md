# BovinoFarm

## Tablas de Contenidos

1. [Animal](#animal)

*  IdAnimal: varchar, este dato se autogenera desde c# con codigo guid.
*  Name: varchar.
*  Birthdate: datetime.
*  Sex: varchar.
*  Price: decimal.
*  Status: bit.
*  Comments: varchar.
*  IdBreed: varchar.
* RegistrationDate: datetime.

2. [Breed](#breed)

* IdBreed: varchar, este dato se autogenera desde c# con codigo guid.
* Name: varchar

## BBDD

Este proyecto usa como motor de almacenamiento SQLite, los registros necesarios para probar la aplicacion se encuentran en la siguiente ruta:

BovinoFarm/BovinoFarmWeb.Api/dbBovinoFarm.db

* El motor de BBDD sugerido para visualizar las tablas del archivo es DB Browser.
* La base de datos cuenta con 20 tipos de animales bovinos y 16 tipos de raza para realizar pruebas.

## EndPoints

### Animal
* GetAnimalByID: Optiene la entidad por identificador.
* GetAnimal: Obtiene todas las entidades.
* GetAnimalByGroup: Retorna animales activos agrupados por su raza.
* CreateAnimal:  Crea una entidad nueva de tipo animal.
* UpdateAnimal: Edita una entidad existente.
* DeleteAnimal: Elimina una entidad existente.

### Breed
* GetBreedByID: Optiene la entidad por identificador.
* GetBreed: Obtiene todas las entidades.
* CreateBreed: Crea una entidad nueva de tipo breed.
* UpdateBreed: Edita una entidad existente.
* DeleteBreed: Elimina una entidad existente.