using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest,
    ILoggableRequest
{
    public string Name { get; set; }
    public string? CacheKey => null;
    public string? CacheGroupKey => "GetBrands";
    public bool ByPassCache => false;

    private class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandsBusinessRules _brandsBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper,
            BrandsBusinessRules brandsBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandsBusinessRules = brandsBusinessRules;
        }

        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandsBusinessRules.BrandNameCannotBeDuplicated(request.Name);

            var brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

            await _brandRepository.AddAsync(brand);

            var response = _mapper.Map<CreatedBrandResponse>(brand);

            return response;
        }
    }
}
