using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
using CQRS_With_MeditR_Demo.Services;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductDTO>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductDTO>
        {
            private readonly IProductServices _productServices;

            public GetProductByIdQueryHandler(IProductServices productServices)
            {
                _productServices = productServices;
            }
            public async Task<GetProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {

                return await _productServices.GetProductById(request.Id);
            }
        }
    }
}
