# Edward Lizagny García Ramírez
## Prueba Ténica Posición Developer

En este repositorio se encuentra lo desarrollado para la prueba técnica. 
Solo se llevó a cabo la parte back-end del requerimiento.

## Funcionalidades
- CRUD de Categorías
- CRUD de Productos

## Herramientas

Esta solución se desarrolló en Visual Studio 2022 y Microsoft SQL Server Management Studio 18. 
## Version de Proyectos
- .NET 6.0

## Detalles del aplicativo
Esta solución está compuesta por 4 proyectos:

| Proyecto | Descripción |
| ------ | ------ |
| BravoInventory.API | Este es el proyecto default de la solución. Es un proyecto Web API que cuenta con documentación de swagger para la realización de prueba de sus métodos y está listo para ser consumido.|
| BravoInventory.Data | La finalidad de este proyecto es manejar las migraciones e interacciones con los contextos de bases de datos. Así también, como la comunicación entre el aplicativo y SQL Server. |
| BravoInventory.Model | En este proyecto se encuentran almacenados los modelos de datos definidos a nivel de code-first en la solución representando la estructura y relaciones de entidades que conforman el aplicativo. |
| BravoInventory.Service | Este proyecto sirve como biblioteca de funcionalidades core del aplicativo. Aquí se maneja la lógica correspondiente a cada entidad especificada asegurando la separación y asignación de responsabilidades únicas de cada servicio o clase que requiera el API para llevar a cabo las operaciones de sus métodos. |

## Setup del aplicativo
Al descargar o clonar esta solución y abrir Visual Studio, debe proceder a asignar el proyecto BravoInventory.API como default.

Una vez definido el proyecto default, se debe configurar el connection string definido en el archivo del proyecto BravoInventory.API, appsettings.json. En la coleccón de ConnectionStrings podrá visualizar la conexión de nombre "InventoryDb". En esta conexión deberá definir sus credenciales de instancia de SQL Server (Conservar nombre de la base de datos BravoInventory). Ejemplo:
```sh
  "ConnectionStrings": {
    "InventoryDb": "Server=(local); Database=BravoInventory;Integrated Security=false; User Id=sa; Password=sqladmin"
  }
```

Una vez haya definido su connection string, debe dirigirse al Package Manager Console de Visual Studio:
```sh
Visual Studio > Tools > Nuget Package Manager > Pacakge Manager Console
```
Esto desplegará una consola donde podrá llevar a cabo la migración de la base de datos. Antes de realizar la migración, debe asegurarse de tener corriendo su aplicación de SQL Server.

Para realizar la migración, primero debe seleccionar en el dropdown "Default project" que se encuentra en la consola, el proyecto BravoInventory.Data y ejecutar la siguiente secuencia en la linea de comandos de la consola:
```sh
Update-Database -StartupProject BravoInventory.API -Context InventoryDbContext
```

![image](https://user-images.githubusercontent.com/17075196/182542686-0c86fae6-48bd-4746-bb83-e97a9019c37e.png)

Si este comando resulta en alguna excepción, verifique su connection string y repita la secuencia.

Una vez se haya ejecutado la secuencia mencionada, debe dirigirse a su aplicación de SQL Server y actualizar su carpeta Database para verificar que se haya integrado la base de datos BravoInventory. Esto quiere decir que la migración de la base de datos ha sido exitosa y que usted puede comenzar a probar el aplicativo.
