namespace DeviantPasswordManager.UseCases.Projects;

public record ProjectWithMembersDto(int Id, string Name, List<ProjectMemberDto> Members);
