namespace E_Commerc.Data
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int ZipCode { get; set; }
        public string? Email { get; set; }
        public int Number { get; set; }
        public string? ProductName { get; set; }
        public int ProductSum { get; set; }
        public decimal ProductPrice { get; set; }
        //public List<CartItemTshirtDTO> CartItems { get; set; } = new List<CartItemTshirtDTO>();

        //public decimal CalculateTotal() => CartItems.Sum(item => item.CartTshirtPrice);
    }
}
