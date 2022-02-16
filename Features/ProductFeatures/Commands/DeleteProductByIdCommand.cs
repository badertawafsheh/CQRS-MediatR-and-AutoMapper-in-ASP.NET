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
    public class DeleteProductByIdCommand : IRequest<GetProductDTO>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, GetProductDTO>
        {
            private readonly IProductServices _productServices;

            public DeleteProductByIdCommandHandler(IProductServices productServices)
            {
                _productServices = productServices;
            }
            public async Task<GetProductDTO> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                return await _productServices.DeleteProduct(request.Id);
            }
        }
    }
}
