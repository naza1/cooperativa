using DbSystem.Tables;

namespace Cooperativa.DbSystem
{
    public interface IWriteFile
    {
        void SaveProject(Project project);
        void SaveBudjet(Project budject);
        void SaveResource(Project resource);
        void SaveStage(Project stage);
    }
}