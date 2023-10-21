namespace OurProjects.Api.DTO
{
    public sealed record CreateUserDTO(
            string Name,
            string Email,
            string Password,
            string RePassword,
            Guid IdCompany
        );
}
