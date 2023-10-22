using OurProjects.Api.DTO.Identity;

namespace OurProjects.Api.DTO
{
    public sealed record ReadProjectTeamMemberDTO(
            Guid Id,
            Guid IdProject,
            Guid IdTeamMember,
            ReadUserDTO TeamMember
        );
}
