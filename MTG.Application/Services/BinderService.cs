using MTG.Application.Models;
using MTG.Application.Services.Interfaces;
using MTG.Domain.Interfaces;
using MTG.Domain.Models;

namespace MTG.Application.Services
{
    public class BinderService : IBinderService
    {
        private readonly IUnitOfWork unitOfWork;

        public BinderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CreateBinderResultDTO> CreateBinderAsync(string name, string description, CancellationToken cancellationToken)
        {
            var result = new CreateBinderResultDTO();

            if (string.IsNullOrEmpty(name))
            {
                result.ErrorMessage = "Binder name cannot be empty.";
                return result;
            }

            var newBinder = await SaveBinderToDbAsync(name, description, cancellationToken);

            result.IsSuccessful = true;
            MapDBBinderToCreateBinderResult(newBinder, result);

            return result;
        }

        private static void MapDBBinderToCreateBinderResult(Binder newBinder, CreateBinderResultDTO result)
        {
            result.Id = newBinder.Id;
            result.Name = newBinder.Name;
            result.Description = newBinder.Description;
            result.CreateDate = newBinder.CreateDate;
        }

        private async Task<Binder> SaveBinderToDbAsync(string name, string description, CancellationToken cancellationToken)
        {
            var binder = new Binder
            {
                Name = name,
                Description = description,
                CreateDate = DateTime.UtcNow
            };

            await unitOfWork.BinderRepository.AddAsync(binder, cancellationToken);
            await unitOfWork.SaveChangesAsync(CancellationToken.None);

            return binder;
        }
    }
}
