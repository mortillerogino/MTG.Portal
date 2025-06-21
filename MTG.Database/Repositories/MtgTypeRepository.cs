
using Microsoft.EntityFrameworkCore;
using MTG.Database.Repositories.Base;
using MTG.Domain.Interfaces;
using MTG.Domain.Models;

namespace MTG.Database.Repositories
{
    public class MtgTypeRepository : BaseRepository<MtgType>, IMtgTypeRepository
    {
        public MtgTypeRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MtgType>> GetMtgTypesFromIdsAsync(IEnumerable<int> typeIds, CancellationToken cancellationToken)
        {
            var mtgTypes = await _dbSet
                .Where(type => typeIds.Contains(type.Id))
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return mtgTypes;
        }
    }
}
