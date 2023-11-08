namespace OurProjects.Api.DTO
{
    public sealed record UpdateProjectTeamMemberDTO(
            Guid IdProject,
            Guid IdTeamMember
        );
}
