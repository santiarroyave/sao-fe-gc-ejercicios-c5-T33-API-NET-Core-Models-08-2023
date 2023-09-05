namespace ex03.Models
{
    public class Caja
    {
        public string numReferencia { get; set; }
        public string contenido { get; set; }
        public int valor { get; set; }
        public int fk_almacen { get; set; }
        public virtual Almacen? v_almacen { get; set; }
    }
}
