using System.Collections.Generic;
using CharacterDevelopment.Models.Project;

namespace CharacterDevelopment.Contracts
{
    public interface IProjectService
    {
        bool CreateProject(ProjectCreate model);
        IEnumerable<ProjectListItem> GetProjects();
        ProjectDetail GetProjectById(int projectId);
        bool UpdateProject(ProjectEdit model);
        bool DeleteProject(int projectId);
    }
}
