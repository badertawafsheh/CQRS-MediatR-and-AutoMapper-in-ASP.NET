using CQRS_With_MeditR_Demo.Data;
using CQRS_With_MeditR_Demo.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_With_MeditR_Demo.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            private readonly DataContext _context;

            public CreateProductCommandHandler(DataContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Barcode = request.Barcode;
                product.Name = request.Name;
                product.BuyingPrice = request.BuyingPrice;
                product.Rate = request.Rate;
                product.Description = request.Description;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
        }
    }
}
