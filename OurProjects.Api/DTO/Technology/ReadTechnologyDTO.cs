namespace OurProjects.Api.DTO
{
    public sealed record ReadTechnologyDTO(
            Guid Id,
            string Title,
            DateTime CreatedAt
        );
}
