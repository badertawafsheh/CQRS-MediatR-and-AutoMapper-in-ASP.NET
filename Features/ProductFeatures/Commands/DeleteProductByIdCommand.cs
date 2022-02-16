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
    public class DeleteProductByIdCommand : IRequest<GetProductDTO>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, GetProductDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public DeleteProductByIdCommandHandler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<GetProductDTO> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (product == null) return null;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetProductDTO>(product);
            }
        }
    }
}
