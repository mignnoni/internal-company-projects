using OurProjects.Api.DTO.Identity;

namespace OurProjects.Api.DTO
{
    public sealed record ReadProjectDTO(
            Guid Id,
            Guid IdArea,
            Guid IdLeader,
            string Title,
            string Description,
            bool Show,
            bool ShowLeader,
            bool ShowTeam,
            DateTime? StartDate,
            DateTime? EndDate,
            ReadAreaDTO Area,
            ReadUserDTO UserLeader,
            List<ReadProjectTeamMemberDTO> ProjectTeamMembers,
            List<ReadProjectTechnologyDTO> ProjectTechnologies
        );
}
