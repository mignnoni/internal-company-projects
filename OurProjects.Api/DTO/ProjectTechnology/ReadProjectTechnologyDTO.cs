namespace OurProjects.Api.DTO
{
    public sealed record ReadProjectTechnologyDTO(
            Guid Id,
            Guid IdProject,
            Guid IdTechnology,
            ReadTechnologyDTO Technology
        );
}
