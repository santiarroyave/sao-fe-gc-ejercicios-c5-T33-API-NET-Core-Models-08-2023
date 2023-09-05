namespace ex03.Models
{
    public class Almacen
    {
        public int codigo { get; set; }
        public string lugar { get; set; }
        public int capacidad { get; set; }
        public virtual ICollection<Caja>? v_caja { get; set; }

    }
}
