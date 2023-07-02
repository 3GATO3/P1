namespace P3.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public Producto? Producto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public DateTime DateTime { get; set; }
    }
}
