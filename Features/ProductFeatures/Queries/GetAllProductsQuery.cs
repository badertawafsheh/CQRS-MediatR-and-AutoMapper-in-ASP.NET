using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
using CQRS_With_MeditR_Demo.Services;
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
            private readonly IProductServices _productServices;

            public GetAllProductsQueryHandler(IProductServices productServices)
            {
                _productServices = productServices;
            }
            public async Task<List<GetProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                return await _productServices.GetAllProducts();
            }
        }
    }
}
