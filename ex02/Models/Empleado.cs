using System.Text.Json.Serialization;

namespace ex02.Models
{
    public class Empleado
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set;}
        public int fk_departamento { get; set; }

        [JsonIgnore]
        public virtual Departamento? v_departamento { get; set; }
    }
}
