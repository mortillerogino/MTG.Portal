using MTG.Application.Enums;

namespace MTG.Application.Services.Interfaces
{
    public interface IMtgCardService
    {
        Task AddCardAsync(string cardName, string set, int binderId, int page, IEnumerable<MtgTypes> mtgCardTypes, IEnumerable<MtgColors> mtgColors, CancellationToken cancellationToken);
    }
}
