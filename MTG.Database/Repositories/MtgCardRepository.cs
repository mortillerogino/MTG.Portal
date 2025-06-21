using Microsoft.EntityFrameworkCore;
using MTG.Database.Repositories.Base;
using MTG.Domain.Interfaces;
using MTG.Domain.Models;

namespace MTG.Database.Repositories
{
    public class MtgCardRepository : BaseRepository<MtgCard>, IMtgCardRepository
    {
        public MtgCardRepository(DbContext context) : base(context)
        {
        }
    }
}
