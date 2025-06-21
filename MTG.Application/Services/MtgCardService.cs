
using AutoMapper;
using MTG.Application.Enums;
using MTG.Application.Models;
using MTG.Application.Services.Interfaces;
using MTG.Domain.Interfaces;
using MTG.Domain.Models;

namespace MTG.Application.Services
{
    public class MtgCardService : IMtgCardService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MtgCardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CreateCardResultDTO> AddCardAsync(string cardName,
            string set,
            int binderId,
            int page,
            IEnumerable<MtgTypes> mtgCardTypes,
            IEnumerable<MtgColors> mtgColors,
            CancellationToken cancellationToken)
        {
            var result = new CreateCardResultDTO();

            if (binderId <= 0)
            {
                result.ErrorMessage = "Binder ID must be greater than zero.";
                return result;
            }

            if (page <= 0)
            {
                result.ErrorMessage = "Page number must be greater than zero.";
                return result;
            }

            var typeIds = mtgCardTypes.Select(type => (int)type);
            var colorIds = mtgColors.Select(color => (int)color);
            var cardTypes = await unitOfWork.MtgTypeRepository.GetMtgTypesFromIdsAsync(typeIds, cancellationToken);
            var colors = await unitOfWork.MtgColorRepository.GetMtgColorsFromIdsAsync(colorIds, cancellationToken);
            MtgCard mtgCard = await SaveMtgCardToDBAsync(cardName, set, binderId, page, cardTypes, colors, cancellationToken);

            result = mapper.Map<CreateCardResultDTO>(mtgCard);
            result.IsSuccessful = true;

            return result;
        }

        private async Task<MtgCard> SaveMtgCardToDBAsync(string cardName, string set, int binderId, int page, IEnumerable<MtgType> cardTypes, IEnumerable<MtgColor> colors, CancellationToken cancellationToken)
        {
            var mtgCard = new MtgCard
            {
                Name = cardName,
                Set = set,
                BinderId = binderId,
                Page = page,
                MtgTypes = cardTypes.ToList(),
                MtgColors = colors.ToList()
            };

            await unitOfWork.MtgCardRepository.AddAsync(mtgCard, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mtgCard;
        }
    }
}
