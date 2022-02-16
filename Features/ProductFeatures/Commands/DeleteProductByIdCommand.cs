using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Product>
        {
            private readonly DataContext _context;

            public DeleteProductByIdCommandHandler(DataContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (product == null) return null;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
        }
    }
}
