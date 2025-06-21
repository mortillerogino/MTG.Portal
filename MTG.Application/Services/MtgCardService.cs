
using MTG.Application.Enums;
using MTG.Application.Services.Interfaces;
using MTG.Domain.Interfaces;
using MTG.Domain.Models;

namespace MTG.Application.Services
{
    public class MtgCardService : IMtgCardService
    {
        private readonly IUnitOfWork unitOfWork;

        public MtgCardService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task AddCardAsync(string cardName,
            string set,
            int binderId,
            int page,
            IEnumerable<MtgTypes> mtgCardTypes,
            IEnumerable<MtgColors> mtgColors,
            CancellationToken cancellationToken)
        {
            var mtgCard = new MtgCard
            {
                Name = cardName,
                Set = set,
                BinderId = binderId,
                Page = page,
                MtgTypes = mtgCardTypes
                    .Select(type => new MtgType { Name = type.ToString() })
                    .ToList(),
                MtgColors = mtgColors
                    .Select(color => new MtgColor { Name = color.ToString() })
                    .ToList()
            };

            return unitOfWork.MtgCardRepository.AddAsync(mtgCard, cancellationToken);
        }
    }
}
