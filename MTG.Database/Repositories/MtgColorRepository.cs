
using Microsoft.EntityFrameworkCore;
using MTG.Database.Repositories.Base;
using MTG.Domain.Interfaces;
using MTG.Domain.Models;

namespace MTG.Database.Repositories
{
    public class MtgColorRepository : BaseRepository<MtgColor>, IMtgColorRepository
    {
        public MtgColorRepository(DbContext context) : base(context)
        {
        }
    }
}
