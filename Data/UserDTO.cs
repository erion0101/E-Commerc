namespace E_Commerc.Data
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? GenderId { get; set; }
        //public GenderDTO Gender { get; set; }
        public int RoleId { get; set; }
        //public AdressDTO? Adress { get; set; }
    }
}
