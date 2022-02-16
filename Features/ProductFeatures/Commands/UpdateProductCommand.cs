using AutoMapper;
using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.DTO;
using CQRS_With_MeditR_Demo.Model;
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
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(DataContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<GetProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == request.productDTO.Id);
                if (product == null) return null;
                else
                {
                    product.Name = request.productDTO.Name;
                    product.Description = request.productDTO.Description;
                    product.Rate = request.productDTO.Rate;
                    product.Barcode = request.productDTO.Barcode;
                    await _context.SaveChangesAsync();
                    return _mapper.Map<GetProductDTO>(product);

                }

            }
        }
    }
}
