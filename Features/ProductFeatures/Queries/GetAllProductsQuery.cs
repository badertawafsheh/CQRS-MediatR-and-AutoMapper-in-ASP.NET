using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery:IRequest<List<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
        {
            private readonly DataContext _context;

            public GetAllProductsQueryHandler(DataContext context)
            {
                _context = context;
            }
            public async  Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();
                if (products == null) return null; 

                return products;
            }
        }
    }
}
