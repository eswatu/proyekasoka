using System.Threading.Tasks;
namespace serverside.Core
{
    public interface IUnitOfWork {
        Task CompleteAsync();
    }
}