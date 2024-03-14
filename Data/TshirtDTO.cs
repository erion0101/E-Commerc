namespace E_Commerc.Data
{
    public class TshirtDTO
    {
        public int Id { get; set; }
        public string TshirtName { get; set; }
        public string TshirtDescription { get; set; }
        public decimal TshirtPrice { get; set; }
        public string TshirtSize { get; set; }
        public string ImgUrl { get; set; }
        public string ImgUrl2 { get; set; }
        public bool IsActive { get; set; }
    }
}
