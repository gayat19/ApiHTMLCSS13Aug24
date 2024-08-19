namespace ShoppingAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Cart  Cart { get; set; }
        public Customer()
        {
            Cart = new Cart();
        }
    }
}
