using System.Threading.Tasks;

namespace ApproarchVendas.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
