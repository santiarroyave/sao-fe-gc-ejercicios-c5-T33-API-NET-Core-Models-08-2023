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
