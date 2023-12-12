using Application.Features.Models.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListByDynamic;

public class GetListByDynamicModelQuery : IRequest<GetListResponse<GetListByDynamicModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    private class GetListByDynamicModelQueryHandler : IRequestHandler<GetListByDynamicModelQuery,
        GetListResponse<GetListByDynamicModelListItemDto>>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;

        public GetListByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicModelListItemDto>> Handle(GetListByDynamicModelQuery request,
            CancellationToken cancellationToken)
        {
            var models = await _modelRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: model => model.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            var response = _mapper.Map<GetListResponse<GetListByDynamicModelListItemDto>>(models);

            return response;
        }
    }
}
