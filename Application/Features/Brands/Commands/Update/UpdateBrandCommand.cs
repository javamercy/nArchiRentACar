using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>, ITransactionalRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? CacheKey => null;
    public string? CacheGroupKey => "GetBrands";
    public bool ByPassCache => false;

    private class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }


        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandToUpdate = await _brandRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken);

            brandToUpdate = _mapper.Map(request, brandToUpdate);

            await _brandRepository.UpdateAsync(brandToUpdate);

            var response = _mapper.Map<UpdatedBrandResponse>(brandToUpdate);

            return response;
        }
    }
}
