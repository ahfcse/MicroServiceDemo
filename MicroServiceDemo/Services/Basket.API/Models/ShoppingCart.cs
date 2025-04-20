namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public ShoppingCart()
        {
                
        }
        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice
        {
            get {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }

    }
}
