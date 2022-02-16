using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<List<GetProductDTO>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetProductDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<GetProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.Select(p=>_mapper.Map<GetProductDTO>(p)).ToListAsync();
                if (products == null) return null;

                return products;
            }
        }
    }
}
