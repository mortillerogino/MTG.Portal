
using MTG.Domain.Models;

namespace MTG.Domain.Interfaces
{
    public interface IMtgTypeRepository : IRepository<MtgType>
    {
        public Task<IEnumerable<MtgType>> GetMtgTypesFromIdsAsync(IEnumerable<int> typeIds, CancellationToken cancellationToken);
    }
}
