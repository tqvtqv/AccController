
namespace AccController.Membership
{
    using Serenity.Services;

    public class RegisterRequest : ServiceRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}