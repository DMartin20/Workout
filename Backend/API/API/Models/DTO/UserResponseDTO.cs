namespace API.Models.DTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime Created { get; set; }

    }
}
