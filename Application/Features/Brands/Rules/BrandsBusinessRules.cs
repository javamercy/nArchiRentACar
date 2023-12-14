using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Brands.Rules;

public class BrandsBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandsBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCannotBeDuplicated(string name)
    {
        var result = await _brandRepository.GetAsync(predicate: b => b.Name.ToLower().Equals(name.ToLower()));

        if (result != null)
        {
            throw new BusinessException(BrandsMessages.BrandNameExists);
        }
    }
}
