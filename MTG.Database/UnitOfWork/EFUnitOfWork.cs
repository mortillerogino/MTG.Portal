using MTG.Database.DBContexts;
using MTG.Database.Repositories;
using MTG.Domain.Interfaces;

namespace MTG.Database.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public EFUnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public IBinderRepository BinderRepository => new BinderRepository(context);
        public IMtgCardRepository MtgCardRepository => new MtgCardRepository(context);
        public IMtgTypeRepository MtgTypeRepository => new MtgTypeRepository(context);
        public IMtgColorRepository MtgColorRepository => new MtgColorRepository(context);

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
