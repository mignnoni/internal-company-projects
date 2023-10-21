namespace OurProjects.Api.DTO.Identity
{
    public sealed record ReadUserDTO(
            Guid Id,
            string Name,
            string UserName,
            string Email,
            Guid IdCompany,
            DateTime CreatedAt,
            bool Idle
        );
}
