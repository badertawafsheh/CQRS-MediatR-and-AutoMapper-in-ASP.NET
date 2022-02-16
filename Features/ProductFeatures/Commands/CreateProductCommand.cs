using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
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
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<GetProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                //var product = new Product();
                //product.Barcode = request.product.Barcode;
                //product.Name = request.product.Name;
                //product.Rate = request.product.Rate;
                //product.Description = request.product.Description;
                //product.IsActive = request.product.IsActive;
                var product = _mapper.Map<Product>(request.productDto);

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetProductDTO>(product);
            }
        }
    }
}
