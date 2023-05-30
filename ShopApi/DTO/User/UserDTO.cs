namespace ShopApi.DTO
{
    public class UserDTO : IUserDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
