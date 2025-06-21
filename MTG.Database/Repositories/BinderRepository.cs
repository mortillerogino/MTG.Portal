
using Microsoft.EntityFrameworkCore;
using MTG.Database.Repositories.Base;
using MTG.Domain.Interfaces;
using MTG.Domain.Models;

namespace MTG.Database.Repositories
{
    public class BinderRepository : BaseRepository<Binder>, IBinderRepository
    {
        public BinderRepository(DbContext context) : base(context)
        {
        }
    }
}
