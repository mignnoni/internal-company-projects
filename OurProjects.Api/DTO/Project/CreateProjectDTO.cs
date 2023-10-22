namespace OurProjects.Api.DTO
{
    public sealed record CreateProjectDTO(
            Guid IdArea,
            Guid IdLeader,
            Guid IdCompany,
            string Title,
            string Description,
            bool Show,
            bool ShowLeader,
            bool ShowTeam,
            DateTime? StartDate,
            DateTime? EndDate,
            List<Guid>? TechnologiesId,
            List<Guid>? TeamMembersId
        );
}
