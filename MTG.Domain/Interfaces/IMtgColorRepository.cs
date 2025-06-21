
using MTG.Domain.Models;

namespace MTG.Domain.Interfaces
{
    public interface IMtgColorRepository : IRepository<MtgColor>
    {
        public Task<IEnumerable<MtgColor>> GetMtgColorsFromIdsAsync(IEnumerable<int> colorIds, CancellationToken cancellationToken);
    }
}
