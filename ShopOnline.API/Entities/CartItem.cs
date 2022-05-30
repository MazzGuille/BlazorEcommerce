namespace ShopOnline.API.Entities
{
    public class CartItem
    {
        public int id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
