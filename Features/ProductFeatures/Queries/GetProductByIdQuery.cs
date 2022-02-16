using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.Model;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,Product>
        {
            private readonly DataContext _context;

            public GetProductByIdQueryHandler(DataContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == request.Id).FirstOrDefault();
                if (product == null) return null;
                
                return product; 
            }
        }
    }
}
