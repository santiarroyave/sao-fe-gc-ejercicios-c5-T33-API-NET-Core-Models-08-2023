using System.Text.Json.Serialization;

namespace ex02.Models
{
    public class Departamento
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int presupuesto { get; set; }

        [JsonIgnore]
        public virtual ICollection<Empleado>? v_empleados { get; set; }
    }
}
