using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
        {
            private readonly DataContext _context;

            public UpdateProductCommandHandler(DataContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (product == null) return null;
                else
                {
                    product.Name = request.Name;
                    product.Description = request.Description;
                    product.Rate = request.Rate;
                    product.Barcode = request.Barcode;
                    product.BuyingPrice = request.BuyingPrice;
                    await _context.SaveChangesAsync();
                    return product;

                }

            }
        }
    }
}
