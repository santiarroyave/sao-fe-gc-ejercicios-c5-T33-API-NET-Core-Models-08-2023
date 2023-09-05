using System.Text.Json.Serialization;

namespace ex01.Models
{
    public class Articulo
    {
        public int codigo { get; set; }
        public int nombre { get; set;}
        public int precio { get; set;}
        public int fk_fabricante { get; set;}

        [JsonIgnore]
        public virtual Fabricante? v_fabricante { get; set; }
    }
}
