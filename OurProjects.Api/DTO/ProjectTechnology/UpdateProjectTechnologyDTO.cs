namespace OurProjects.Api.DTO
{
    public sealed record UpdateProjectTechnologyDTO(
            Guid IdProject,
            Guid IdTechnology
        );
}
