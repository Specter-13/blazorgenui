namespace FestivalProject.BL.Models.UserDto
{
    public class UserAuthenticateDto 
    {
        public string Username { get; set; }
       
        public string Password { get; set; } // mozno pozuzit nejaky hash na heslo
    }
}
