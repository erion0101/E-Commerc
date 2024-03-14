namespace E_Commerc.Data
{
    public class CartItemTshirtDTO
    {
        public int Id { get; set; }
        public string CartTshirtName { get; set; }
        public decimal CartTshirtPrice { get; set; }
        public int CartTshirtSum { get; set; }
        public int CartTshirtSize { get; set; }
        public string CartImgUrl { get; set; }
    }
    //   public decimal TotalPrice => CartTshirtSum * CartTshirtPrice;
}

