
namespace DokanyApp.BLL.Interfaces
{
    public interface ITransaction
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
