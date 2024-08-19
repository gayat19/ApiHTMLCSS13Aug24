namespace ShoppingAPI.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public int CustId { get; set; }
        
        public Customer Customer { get; set; }
        public Cart()
        {
            Customer = new Customer();
        }

    }
}
