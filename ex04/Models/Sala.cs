namespace ex04.Models
{
    public class Sala
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int fk_pelicula { get; set; }

        public virtual Pelicula? v_pelicula { get; set; }
    }
}
