namespace ShoppingAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public Cart  Cart { get; set; }
        public Customer()
        {
            //Cart = new Cart();
        }
    }
}
