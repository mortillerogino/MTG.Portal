using MTG.Application.Models;

namespace MTG.Application.Services.Interfaces
{
    public interface IBinderService
    {
        Task<CreateBinderResultDTO> CreateBinderAsync(string name, string description, CancellationToken cancellationToken);
    }
}
