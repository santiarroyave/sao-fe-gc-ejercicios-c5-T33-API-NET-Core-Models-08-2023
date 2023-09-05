# C5-T33 API .NET Core (Models)

<!-- ## Notas
### Propiedad virtual en Swagger
La propiedad virtual, pese a no generarse en BBDD si que aparece en Swagger y puede ser molesto.

Para evitar que la propiedad virtual aparezca en el *json* de Swagger se puede usar la anotación **\[JsonIgnore\]** desde el propio modelo.

*Se ha usado código del Ejercicio 1 para este ejemplo.*

Ejemplo de uso:
```csharp
using System.Text.Json.Serialization;

namespace ex01.Models
{
    public class Fabricante
    {
        public int codigo { get; set; }
        public string nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Articulo>? v_articulo { get; set; }
    }
}
```

#### Código json en Swagger antes
```json
{
  "codigo": 0,
  "nombre": "string",
  "v_articulo": [
    {
      "codigo": 0,
      "nombre": 0,
      "precio": 0,
      "fk_fabricante": 0
    }
  ]
}
```
#### Código json en Swagger después
```json
{
  "codigo": 0,
  "nombre": "string"
}
``` -->