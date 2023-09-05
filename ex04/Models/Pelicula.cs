namespace ex04.Models
{
    public class Pelicula
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int calificacionEdad { get; set; }

        public virtual ICollection<Sala>? v_sala { get; set; }
    }
}
