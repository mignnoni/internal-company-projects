namespace OurProjects.Api.DTO.Identity
{
    public sealed record LoginRequestDTO(
            string Email,
            string Password
        );
}
