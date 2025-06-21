
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
    }
}
