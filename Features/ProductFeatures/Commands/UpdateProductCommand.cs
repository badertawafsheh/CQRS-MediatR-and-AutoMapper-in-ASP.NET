using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
using CQRS_With_MeditR_Demo.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<GetProductDTO>
    {
        public GetProductDTO productDTO { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, GetProductDTO>
        {
            private readonly IProductServices _productServices;

            public UpdateProductCommandHandler(IProductServices productServices)
            {
                _productServices = productServices;
            }
            public async Task<GetProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                return await _productServices.UpdateProduct(request.productDTO.Id,request.productDTO);

            }
        }
    }
}
