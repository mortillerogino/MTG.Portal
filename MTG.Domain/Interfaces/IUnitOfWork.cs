namespace MTG.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBinderRepository BinderRepository { get; }
        IMtgCardRepository MtgCardRepository { get; }
        IMtgColorRepository MtgColorRepository { get; }
        IMtgTypeRepository MtgTypeRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
