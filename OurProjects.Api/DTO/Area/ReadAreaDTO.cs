namespace OurProjects.Api.DTO
{
    public sealed record ReadAreaDTO(
            Guid Id,
            string Title,
            DateTime CreatedAt
        );
}
