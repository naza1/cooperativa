using FileSystem.Tables;

namespace Cooperativa.FileSystem
{
    public interface IWriteFile
    {
        void SaveProject(Project project);
        void SaveBudjet(Project budject);
        void SaveResource(Project resource);
        void SaveStage(Project stage);
    }
}