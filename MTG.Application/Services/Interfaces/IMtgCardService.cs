using MTG.Application.Enums;
using MTG.Application.Models;

namespace MTG.Application.Services.Interfaces
{
    public interface IMtgCardService
    {
        Task<CreateCardResultDTO> AddCardAsync(string cardName, string set, int binderId, int page, IEnumerable<MtgTypes> mtgCardTypes, IEnumerable<MtgColors> mtgColors, CancellationToken cancellationToken);
    }
}
