using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery:IRequest<GetProductDTO>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(DataContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<GetProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == request.Id).FirstOrDefault();
                if (product == null) return null;
                
                return _mapper.Map<GetProductDTO>(product); 
            }
        }
    }
}
