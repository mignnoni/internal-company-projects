namespace OurProjects.Api.DTO
{
    public sealed record UpdateProjectDTO(
            Guid Id,
            Guid IdArea,
            Guid IdLeader,
            string Title,
            string Description,
            bool Show,
            bool ShowLeader,
            bool ShowTeam,
            DateTime? StartDate,
            DateTime? EndDate
        );
}
