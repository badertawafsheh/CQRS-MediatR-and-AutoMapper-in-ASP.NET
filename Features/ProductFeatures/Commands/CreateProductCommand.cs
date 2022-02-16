using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
using CQRS_With_MeditR_Demo.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<GetProductDTO>
    {
        public AddProductDTO productDto { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, GetProductDTO>
        {
            private readonly IProductServices _productServices;

            public CreateProductCommandHandler(IProductServices productServices)
            {
                _productServices = productServices;
            }
            public async Task<GetProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                return await _productServices.CreateProduct(request.productDto);
            }
        }
    }
}
