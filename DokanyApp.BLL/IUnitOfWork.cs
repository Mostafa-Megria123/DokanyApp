using System.Threading.Tasks;

namespace DokanyApp.BLL
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
