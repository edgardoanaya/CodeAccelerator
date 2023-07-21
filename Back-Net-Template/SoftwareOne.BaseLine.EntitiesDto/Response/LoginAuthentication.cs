namespace SoftwareOne.BaseLine.EntitiesDto.Response
{
    public class LoginAuthentication
    {
        public string FullName { get; set; } = null!;

        public string Token { get; set; } = null!;

        public int RoleId { get; set; } = 0!;

        public string RoleName { get; set; } = null!;
    }
}